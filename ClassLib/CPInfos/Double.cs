using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class Double : CPInfo
    {
        public int highHalf;
        public int lowHalf;
        public Double()
        {
            tag = Tag.Double;
        }
    }
}
