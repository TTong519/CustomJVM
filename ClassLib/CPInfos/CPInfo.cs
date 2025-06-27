using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.CPInfos
{
    public enum Tag : byte
    {
        Class = 7,
        Fieldref = 9,
        Methodref = 10,
        InterfaceMethodref = 11,
        String = 8,
        Integer = 3,
        Float = 4,
        Long = 5,
        Double = 6,
        NameAndType = 12,
        Utf8 = 1,
        MethodType = 16
    }
    public abstract class CPInfo
    {
        protected Tag tag;
    }
}
