using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class Long : CPInfo
    {
        public ulong data;
        public Long(ulong data)
        {
            tag = Tag.Long;
            this.data = data;
        }
    }
}
