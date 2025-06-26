using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class Integer : CPInfo
    {
        public int value;
        public Integer()
        {
            tag = Tag.Integer;
        }
    }
}
