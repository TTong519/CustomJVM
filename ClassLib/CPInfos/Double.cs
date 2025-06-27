using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class Double : CPInfo
    {
        public double value;
        public Double(double value)
        {
            tag = Tag.Double;
            this.value = value;
        }
    }
}
