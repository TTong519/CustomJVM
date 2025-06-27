using static ClassLib.SpanExtensions;
using ClassLib;
using ClassLib.CPInfos;
using System.Buffers.Binary;
namespace CustomJVM
{
    
    internal class Program
    {
        
        static void Main(string[] args)
        {
            byte[] byteCode = File.ReadAllBytes("../../../../JVMStuff/JavaFile.class");
            ReadOnlySpan<byte> byteCodeSpan = byteCode.AsSpan();
            ClassFile classFile = new ClassFile();
            classFile.magic = byteCodeSpan.SliceUInt();
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
            }
        }
    }
}
