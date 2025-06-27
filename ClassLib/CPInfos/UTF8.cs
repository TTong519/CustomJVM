using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClassLib.CPInfos
{
    public class UTF8 : CPInfo
    {
        public ushort length;
        public byte[] bytes;
        public UTF8(string data)
        {
            tag = Tag.Utf8;
            bytes = Encoding.UTF8.GetBytes(data);
        }
        public UTF8(ReadOnlySpan<byte> data)
        {
            tag = Tag.Utf8;
            length = (ushort)data.Length;
            bytes = data.ToArray();
        }
    }
}
