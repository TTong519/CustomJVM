using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public class MethodHandle : CPInfo
    {
        public byte referenceKind;
        public ushort referenceIndex;
        public MethodHandle()
        {
            tag = Tag.MethodHandle;
        }
    }
}
