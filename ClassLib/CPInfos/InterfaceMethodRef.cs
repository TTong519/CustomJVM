using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class InterfaceMethodRef : CPInfo
    {
        public ushort classIndex;
        public ushort nameAndTypeIndex;
        public InterfaceMethodRef()
        {
            tag = Tag.InterfaceMethodref;
        }
    }
}
