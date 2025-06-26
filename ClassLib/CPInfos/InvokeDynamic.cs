using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class InvokeDynamic : CPInfo
    {
        public ushort bootstrapMethodAttrIndex;
        public ushort nameAndTypeIndex;
        public InvokeDynamic()
        {
            tag = Tag.InvokeDynamic;
        }
    }
}
