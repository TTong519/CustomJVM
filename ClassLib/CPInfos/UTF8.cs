using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class UTF8 : CPInfo
    {
        public ushort length;
        public byte[] bytes;
        public UTF8()
        {
            tag = Tag.Utf8;
        }
    }
}
