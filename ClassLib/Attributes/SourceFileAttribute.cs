using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Attributes
{
    public class SourceFileAttribute : AttributeInfo
    {
        public ushort sourceFileIndex;
        public SourceFileAttribute(ushort attributeNameIndex, uint attributeLength, ushort sourceFileIndex)
            : base(attributeLength)
        {
            attributeType = AttributeType.SourceFile;
            this.sourceFileIndex = sourceFileIndex;
        }
    }
}
