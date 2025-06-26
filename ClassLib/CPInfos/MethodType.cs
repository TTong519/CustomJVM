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
        public ushort parameterCount;
        public MethodType()
        {
            tag = Tag.MethodType;
        }
    }
}
