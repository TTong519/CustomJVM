using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Attributes
{
    public class CodeAttribute : AttributeInfo
    {
        ushort max_stack;
        ushort max_locals;
        uint code_length;
        List<byte> code;
        ushort attributes_count;
        List<AttributeInfo> attributes;
        public CodeAttribute(ushort max_stack, ushort max_locals, uint code_length, List<byte> code, ushort attributes_count, List<AttributeInfo> attributes, uint attributeLength) : base(attributeLength)
        {
            this.max_stack = max_stack;
            this.max_locals = max_locals;
            this.code_length = code_length;
            this.code = code;
            this.attributes_count = attributes_count;
            this.attributes = attributes;
        }
    }
}
