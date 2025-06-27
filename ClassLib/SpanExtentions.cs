using System;
using System.Buffers.Binary;
namespace ClassLib
{
    public static class SpanExtensions
    {
        public static uint SliceUInt(this ref ReadOnlySpan<byte> span)
        {
            uint toReturn = BitConverter.ToUInt32(span.Slice(0, length: 4));
            toReturn = BinaryPrimitives.ReverseEndianness(toReturn);
            span = span.Slice(4);
            return toReturn;
        }
        public static float SliceFloat(this ref ReadOnlySpan<byte> span)
        {
            float toReturn = BitConverter.ToSingle(span.Slice(0, length: 4));
            toReturn = BinaryPrimitives.ReverseEndianness(BitConverter.SingleToInt32Bits(toReturn));
            span = span.Slice(4);
            return toReturn;
        }
        public static ulong SliceULong(this ref ReadOnlySpan<byte> span)
        {
            ulong toReturn = BitConverter.ToUInt64(span.Slice(0, length: 8));
            toReturn = BinaryPrimitives.ReverseEndianness(toReturn);
            span = span.Slice(8);
            return toReturn;
        }
        public static double SliceDouble(this ref ReadOnlySpan<byte> span)
        {
            double toReturn = BitConverter.ToDouble(span.Slice(0, length: 8));
            toReturn = BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToInt64Bits(toReturn));
            span = span.Slice(8);
            return toReturn;
        }
        public static ushort SliceUShort(this ref ReadOnlySpan<byte> span)
        {
            ushort toReturn = BitConverter.ToUInt16(span.Slice(0, length: 2));
            toReturn = BinaryPrimitives.ReverseEndianness(toReturn);
            span = span.Slice(2);
            return toReturn;
        }
        public static byte SliceByte(this ref ReadOnlySpan<byte> span)
        {
            byte toReturn = span[0];
            toReturn = BinaryPrimitives.ReverseEndianness(toReturn);
            span = span.Slice(1);
            return toReturn;
        }
    }
}
