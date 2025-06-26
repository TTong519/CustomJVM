using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class MethodRef : CPInfo
    {
        public ushort classIndex;
        public ushort nameAndTypeIndex;
        public MethodRef()
        {
            tag = Tag.Methodref;
        }
    }
}
