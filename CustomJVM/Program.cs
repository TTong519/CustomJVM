using static ClassLib.SpanExtensions;
using ClassLib;
using ClassLib.CPInfos;
namespace CustomJVM
{
    
    internal class Program
    {
        
        static void Main(string[] args)
        {
            byte[] byteCode = File.ReadAllBytes("../../../JVMStuff/JavaFile.class");
            ReadOnlySpan<byte> byteCodeSpan = byteCode.AsSpan();
            ClassFile classFile = new ClassFile();
            classFile.magic = byteCodeSpan.SliceUInt();
            classFile.minorVersion = byteCodeSpan.SliceUShort();
            classFile.majorVersion = byteCodeSpan.SliceUShort();
            classFile.constantPoolCount = byteCodeSpan.SliceUShort();
        }
    }
}
