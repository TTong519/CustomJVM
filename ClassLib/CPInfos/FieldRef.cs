using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class FieldRef : CPInfo
    {
        ushort classIndex;
        ushort nameAndTypeIndex;
        public FieldRef(ushort classIndex, ushort nameTypeIndex)
        {
            tag = Tag.Fieldref;
            this.classIndex = classIndex;
            nameAndTypeIndex = nameTypeIndex;
        }
    }
}
