using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class MethodType : CPInfo
    {
        public ushort descriptorIndex;
        public ushort paramaterCount;
        public MethodType(ushort descriptorIndex, ushort paramaterCount)
        {
            tag = Tag.MethodType;
            this.descriptorIndex = descriptorIndex;
            this.paramaterCount = paramaterCount;
        }
    }
}
