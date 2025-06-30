using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Attributes
{
    public class ConstantValueAttribute : AttributeInfo
    {
        public ushort ConstantValueIndex { get; }
        public ConstantValueAttribute(uint attributeLength, ushort constantValueIndex)
            : base(attributeLength)
        {
            ConstantValueIndex = constantValueIndex;
            attributeType = AttributeType.ConstantValue;
        }
    }
}
