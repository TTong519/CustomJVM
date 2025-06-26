using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class Long : CPInfo
    {
        public int highHalf;
        public int lowHalf;
        public Long()
        {
            tag = Tag.Long;
        }
    }
}
