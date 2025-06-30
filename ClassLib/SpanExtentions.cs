using System;
using System.Buffers.Binary;
namespace ClassLib
{
    public static class SpanExtensions
    {
        public static uint SliceUInt(this ref ReadOnlySpan<byte> span)
        {
            ReadOnlySpan<byte> temp = span.Slice(0, length: 4);
            uint toReturn = (uint)((temp[0] << 24) + (temp[1] << 16) + (temp[2] << 8) + temp[3]);
            span = span.Slice(4);
            return toReturn;
        }
        public static float SliceFloat(this ref ReadOnlySpan<byte> span)
        {
            float toReturn = BitConverter.ToSingle(span.Slice(0, length: 4));
            toReturn = BitConverter.Int32BitsToSingle(BinaryPrimitives.ReverseEndianness(BitConverter.SingleToInt32Bits(toReturn)));
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
            toReturn = BitConverter.Int64BitsToDouble(BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToInt64Bits(toReturn)));
            span = span.Slice(8);
            return toReturn;
        }
        public static ushort SliceUShort(this ref ReadOnlySpan<byte> span)
        {
            ReadOnlySpan<byte> temp = span.Slice(0, length: 2);
            ushort toReturn = (ushort)((temp[0] << 8) + temp[1]);
            span = span.Slice(2);
            return toReturn;
        }
        public static byte SliceByte(this ref ReadOnlySpan<byte> span)
        {
            byte toReturn = span[0];
            span = span.Slice(1);
            return toReturn;
        }
    }
}
