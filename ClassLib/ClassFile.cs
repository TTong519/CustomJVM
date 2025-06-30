using ClassLib.Attributes;
using ClassLib.CPInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Flags]
    public enum AccessFlags : ushort
    {
        Public = 0x0001,
        Final = 0x0010,
        Super = 0x0020,
        Interface = 0x0200,
        Abstract = 0x0400,
        Synthetic = 0x1000,
        Annotation = 0x2000,
        Enum = 0x4000,
    }
    public class ClassFile
    {
        public uint magic;
        public ushort minorVersion;
        public ushort majorVersion;
        public ushort constantPoolCount;
        public List<CPInfo> constantPool = new List<CPInfo>();
        public AccessFlags accessFlags;
        public ushort methodsCount;
        public List<MethodInfo> methods = new List<MethodInfo>();
        public ushort attributesCount;
        public List<AttributeInfo> attributes = new List<AttributeInfo>();
    }
}
