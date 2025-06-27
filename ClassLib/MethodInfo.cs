using ClassLib.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    enum AccessFlags : ushort
    {
        Public = 0x0001,
        Private = 0x0002,
        Protected = 0x0004,
        Static = 0x0008,
        Final = 0x0010,
        Synchronized = 0x0020,
        Bridge = 0x0040,
        Varargs = 0x0080,
        Native = 0x0100,
        Abstract = 0x0400,
        Strict = 0x0800,
        Synthetic = 0x1000,
    }
    internal class MethodInfo
    {
        public List<AccessFlags> accessFlags;
        public ushort nameIndex { get; set; }
        public ushort descriptorIndex { get; set; }
        public ushort attributesCount { get; set; }
        public List<AttributeInfo> attributes { get; set; }
        public MethodInfo()
        {
            attributes = new List<AttributeInfo>();
            accessFlags = new List<AccessFlags>();
        }
        public MethodInfo(AccessFlags[] accessFlags, ushort nameIndex, ushort descriptorIndex, ushort attributesCount, List<AttributeInfo> attributes)
        {
            this.accessFlags = new List<AccessFlags>();
            foreach (var flag in accessFlags)
            {
                this.accessFlags.Add(flag);
            }
            this.nameIndex = nameIndex;
            this.descriptorIndex = descriptorIndex;
            this.attributesCount = attributesCount;
            this.attributes = attributes;
        }
    }
}
