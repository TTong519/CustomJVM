using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class Class : CPInfo
    {
        public ushort nameIndex;
        public Class(ushort nameIndex)
        {
            tag = Tag.Class;
            this.nameIndex = nameIndex;
        }
    }
}
