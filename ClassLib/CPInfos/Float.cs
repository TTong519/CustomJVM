using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class Float : CPInfo
    {
        public float value;
        public Float()
        {
            tag = Tag.Float;
        }
    }
}
