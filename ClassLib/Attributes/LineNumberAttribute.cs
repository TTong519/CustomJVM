using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Attributes
{
    public class LineNumberAttribute : AttributeInfo
    {
        public List<LineNumberInfo> lineNumberTable;
        public LineNumberAttribute(ushort attributeNameIndex, uint attributeLength, List<LineNumberInfo> lineNumberTable)
            : base(attributeLength)
        {
            attributeType = AttributeType.LineNumberTable;
            this.lineNumberTable = lineNumberTable;
        }
    }
}
