using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class NameAndType : CPInfo
    {
        public ushort nameIndex;
        public ushort descriptorIndex;
        public NameAndType(ushort nameIndex, ushort descriptorIndex)
        {
            tag = Tag.NameAndType;
            this.nameIndex = nameIndex;
            this.descriptorIndex = descriptorIndex;
        }
    }
}
