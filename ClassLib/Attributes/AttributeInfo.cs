using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Attributes
{
    public abstract class AttributeInfo
    {
        string attributeNameIndex;
        uint attributeLength;
        public AttributeInfo(string attributeNameIndex, uint attributeLength)
        {
            this.attributeNameIndex = attributeNameIndex;
            this.attributeLength = attributeLength;
        }
    }
}
