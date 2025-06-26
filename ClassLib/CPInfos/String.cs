using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class String : CPInfo
    {
        public ushort stringIndex;
        public String()
        {
            tag = Tag.String;
        }
    }
}
