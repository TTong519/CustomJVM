using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class ClassFile
    {
        public uint magic;
        public ushort minorVersion;
        public ushort majorVersion;
        public ushort constantPoolCount;
    }
}
