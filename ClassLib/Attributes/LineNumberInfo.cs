using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Attributes
{
    public class LineNumberInfo
    {
        public ushort start_pc;
        public ushort line_number;
        public LineNumberInfo(ushort start_pc, ushort line_number)
        {
            this.start_pc = start_pc;
            this.line_number = line_number;
        }
    }
}
