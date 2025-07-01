using Microsoft.Win32.SafeHandles;
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
        Stack<byte> stack = new Stack<byte>();
        byte[] locals;
        uint code_length;
        List<byte> code;
        ushort attributes_count;
        List<AttributeInfo> attributes;

        public CodeAttribute(ushort max_stack, ushort max_locals, uint code_length, List<byte> code, ushort attributes_count, List<AttributeInfo> attributes, uint attributeLength)
            : base(attributeLength)
        {
            this.max_stack = max_stack;
            this.max_locals = max_locals;
            this.code_length = code_length;
            this.code = code;
            this.attributes_count = attributes_count;
            this.attributes = attributes;
            locals = new byte[max_locals];
        }
        public void runCode()
        {
            ReadOnlySpan<byte> code = this.code.ToArray();
            while (code.Length > 0)
            {
                byte opcode = code.SliceByte();
                switch (opcode)
                {
                    case 8:
                        stack.Push(5);
                        break;
                    case 5:
                        stack.Push(2);
                        break;
                    case 0x3C:
                        locals[1] = stack.Pop();
                        break;
                    case 0x3D:
                        locals[2] = stack.Pop();
                        break;
                    case 0x3E:
                        locals[3] = stack.Pop();
                        break;
                    case 0x1B:
                        stack.Push(locals[1]);
                        break;
                    case 0x1C:
                        stack.Push(locals[2]);
                        break;
                    case 0x60:
                        byte b1 = stack.Pop();
                        byte b2 = stack.Pop();
                        stack.Push((byte)(b1 + b2));
                        break;
                    case 0xB1:
                        return;
                    default:
                        throw new NotSupportedException($"Unsupported opcode: {opcode:X2}");
                }
            }
        }
    }
}
