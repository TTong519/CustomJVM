namespace ClassLib
{
    public static class SpanExtensions
    {
        public static uint SliceUInt(this ref ReadOnlySpan<byte> span)
        {
            uint toReturn = BitConverter.ToUInt32(span.Slice(0, length: 4));
            span = span.Slice(4);
            return toReturn;
        }
        public static ushort SliceUShort(this ref ReadOnlySpan<byte> span)
        {
            ushort toReturn = BitConverter.ToUInt16(span.Slice(0, length: 2));
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
