namespace CustomJVM
{
    internal class Program
    {
        class ClassFile
        {
            public uint magic;
            public ushort minorVersion;
            public ushort majorVersion;
            public ushort constantPoolCount;
        }
        static void Main(string[] args)
        {
            byte[] byteCode = File.ReadAllBytes("../../../JVMStuff/JavaFile.class");
            ClassFile classFile = new ClassFile();
            classFile.magic = BitConverter.ToUInt32(byteCode, 0);
            if (classFile.magic != 0xCAFEBABE)
            {
                throw new InvalidDataException("Invalid class file format. Expected magic number 0xCAFEBABE.");
            }
            classFile.minorVersion = BitConverter.ToUInt16(byteCode, 4);
            classFile.majorVersion = BitConverter.ToUInt16(byteCode, 6);
            classFile.constantPoolCount = BitConverter.ToUInt16(byteCode, 8);
        }
    }
}
