using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class Integer : CPInfo
    {
        public uint value;
        public Integer(uint value)
        {
            tag = Tag.Integer;
            this.value = value;
        }
    }
}
