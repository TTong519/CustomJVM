using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class StringInfo : CPInfo
    {
        public ushort stringIndex;
        public StringInfo(ushort stringIndex)
        {
            tag = Tag.String;
            this.stringIndex = stringIndex;
        }
    }
}
