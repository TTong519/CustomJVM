using ClassLib;
using ClassLib.Attributes;
using ClassLib.CPInfos;
using System.Buffers.Binary;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using static ClassLib.SpanExtensions;
using MethodInfo = ClassLib.MethodInfo;
namespace CustomJVM
{

    internal class Program
    {
        public static string ParseingHelper(ushort index, ClassFile cf)
        {
            if (cf.constantPool[index] is not UTF8 utf8info) throw new Exception("oof");
            string result = Encoding.UTF8.GetString(utf8info.bytes);
            return result;
        }
        public static List<AttributeInfo> ParseAttributes(ref ReadOnlySpan<byte> byteCodeSpan, ClassFile classFile)
        {
            ushort attributesCount = byteCodeSpan.SliceUShort();
            List<AttributeInfo> attributes = new List<AttributeInfo>();
            for (int k = 0; k < attributesCount; k++)
            {
                ushort attributeNameIndex = (ushort)(byteCodeSpan.SliceUShort() - 1);
                uint attributeLength = byteCodeSpan.SliceUInt();

                switch (ParseingHelper(attributeNameIndex, classFile))
                {
                    case "Code":
                        ushort maxStack = byteCodeSpan.SliceUShort();
                        ushort maxLocals = byteCodeSpan.SliceUShort();
                        uint codeLength = byteCodeSpan.SliceUInt();
                        byte[] code = byteCodeSpan.Slice(0, (int)codeLength).ToArray();
                        byteCodeSpan = byteCodeSpan.Slice((int)codeLength);
                        byteCodeSpan.SliceUShort(); // slice out the exception table length
                        var codeAttributes = ParseAttributes(ref byteCodeSpan, classFile);
                        attributes.Add(new CodeAttribute(maxStack, maxLocals, codeLength, code.ToList(), (ushort)codeAttributes.Count, codeAttributes, attributeLength));
                        break;
                    case "SourceFile":
                        ushort sourceFileIndex = byteCodeSpan.SliceUShort();
                        attributes.Add(new SourceFileAttribute(attributeNameIndex, attributeLength, sourceFileIndex));
                        break;
                    case "LineNumberTable":
                        ushort lineNumberTableLength = byteCodeSpan.SliceUShort();
                        List<LineNumberInfo> lineNumberTable = new List<LineNumberInfo>();
                        for (int i = 0; i < lineNumberTableLength; i++)
                        {
                            ushort startPc = byteCodeSpan.SliceUShort();
                            ushort lineNumber = byteCodeSpan.SliceUShort();
                            lineNumberTable.Add(new LineNumberInfo(startPc, lineNumber));
                        }
                        attributes.Add(new LineNumberAttribute(attributeNameIndex, attributeLength, lineNumberTable));
                        break;
                    default:
                        throw new NotSupportedException($"Unsupported attribute: {ParseingHelper(attributeNameIndex, classFile)}");
                }
            }
            return attributes;
        }
        static void Main(string[] args)
        {
            int mainIndex = 0;
            byte[] byteCode = File.ReadAllBytes("../../../../JVMStuff/JavaFile.class");
            ReadOnlySpan<byte> byteCodeSpan = byteCode.AsSpan();
            ClassFile classFile = new ClassFile();
            classFile.magic = byteCodeSpan.SliceUInt();
            if (classFile.magic != 0xCAFEBABE)
            {
                throw new Exception("Invalid class file magic number.");
            }
            classFile.minorVersion = byteCodeSpan.SliceUShort();
            classFile.majorVersion = byteCodeSpan.SliceUShort();
            classFile.constantPoolCount = byteCodeSpan.SliceUShort();
            for (int i = 1; i < classFile.constantPoolCount; i++)
            {
                byte tag = byteCodeSpan.SliceByte();
                switch (tag)
                {
                    case 7: // CONSTANT_Class
                        classFile.constantPool.Add(new Class(byteCodeSpan.SliceUShort()));
                        break;
                    case 9: // CONSTANT_Fieldref
                        classFile.constantPool.Add(new FieldRef(byteCodeSpan.SliceUShort(), byteCodeSpan.SliceUShort()));
                        break;
                    case 10: // CONSTANT_Methodref
                        classFile.constantPool.Add(new MethodRef(byteCodeSpan.SliceUShort(), byteCodeSpan.SliceUShort()));
                        break;
                    case 11: // CONSTANT_InterfaceMethodref
                        classFile.constantPool.Add(new InterfaceMethodRef(byteCodeSpan.SliceUShort(), byteCodeSpan.SliceUShort()));
                        break;
                    case 8: // CONSTANT_String
                        classFile.constantPool.Add(new StringInfo(byteCodeSpan.SliceUShort()));
                        break;
                    case 3: // CONSTANT_Integer
                        classFile.constantPool.Add(new Integer(byteCodeSpan.SliceUInt()));
                        break;
                    case 4: // CONSTANT_Float
                        classFile.constantPool.Add(new Float(byteCodeSpan.SliceFloat()));
                        break;
                    case 5: // CONSTANT_Long
                        classFile.constantPool.Add(new Long(byteCodeSpan.SliceULong()));
                        break;
                    case 6: // CONSTANT_Double
                        classFile.constantPool.Add(new ClassLib.CPInfos.Double(byteCodeSpan.SliceDouble()));
                        break;
                    case 12: // CONSTANT_NameAndType
                        classFile.constantPool.Add(new NameAndType(byteCodeSpan.SliceUShort(), byteCodeSpan.SliceUShort()));
                        break;
                    case 1: // CONSTANT_Utf8
                        ushort length = byteCodeSpan.SliceUShort();
                        classFile.constantPool.Add(new UTF8(byteCodeSpan.Slice(0, length)));
                        byteCodeSpan = byteCodeSpan.Slice(length);
                        break;
                    case 16: // CONSTANT_MethodType
                        classFile.constantPool.Add(new MethodType(byteCodeSpan.SliceUShort(), byteCodeSpan.SliceUShort()));
                        break;
                    default:
                        throw new NotSupportedException($"Unsupported constant pool tag: {tag}");
                }
                ;
            }
            classFile.accessFlags = (AccessFlags)byteCodeSpan.SliceUShort();
            byteCodeSpan.SliceUShort();
            byteCodeSpan.SliceUShort();
            ushort interfacesCount = byteCodeSpan.SliceUShort();
            for (int j = 0; j < interfacesCount; j++)
            {
                byteCodeSpan.SliceUShort();
            }
            ushort fieldsCount = byteCodeSpan.SliceUShort();
            for (int j = 0; j < fieldsCount; j++)
            {
                byteCodeSpan.SliceUShort();
            }
            classFile.methodsCount = byteCodeSpan.SliceUShort();
            for (int j = 0; j < classFile.methodsCount; j++)
            {
                MethodInfo methodInfo = new MethodInfo();
                methodInfo.accessFlags = (MethodAccessFlags)byteCodeSpan.SliceUShort();
                methodInfo.nameIndex = byteCodeSpan.SliceUShort();
                methodInfo.descriptorIndex = byteCodeSpan.SliceUShort();
                methodInfo.attributes = ParseAttributes(ref byteCodeSpan, classFile);
                classFile.methods.Add(methodInfo);
                mainIndex = classFile.methods.LastIndexOf(methodInfo);
            }
            classFile.attributes = ParseAttributes(ref byteCodeSpan, classFile);
            foreach(var thing in classFile.methods[mainIndex].attributes)
            {
                if (thing is CodeAttribute codeAttribute)
                {
                    codeAttribute.runCode();
                }
            }
        }
    }
}
