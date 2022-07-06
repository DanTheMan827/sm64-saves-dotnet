namespace DanTheMan827.SM64.Saves
{
    internal static class ByteExtensions
    {
        public static byte SetBit(this byte self, int bitIndex, bool value)
        {
            byte mask = (byte)(1 << bitIndex);

            self = (byte)(value ? (self | mask) : (self & ~mask));
            return self;
        }

        public static byte ToggleBit(this byte self, int bitIndex)
        {
            byte mask = (byte)(1 << bitIndex);

            self ^= mask;
            return self;
        }

        public static bool GetBit(this byte self, int bitIndex)
        {
            byte mask = (byte)(1 << bitIndex);

            return (self & mask) != 0;
        }

        public static byte[] SetBit(this byte[] self, int index, bool value)
        {
            int byteIndex = index / 8;
            int bitIndex = index % 8;

            self[byteIndex] = self[byteIndex].SetBit(bitIndex, value);
            return self;
        }

        public static byte[] ToggleBit(this byte[] self, int index)
        {
            int byteIndex = index / 8;
            int bitIndex = index % 8;

            self[byteIndex] = self[byteIndex].ToggleBit(bitIndex);
            return self;
        }

        public static bool GetBit(this byte[] self, int index)
        {
            int byteIndex = index / 8;
            int bitIndex = index % 8;

            return self[byteIndex].GetBit(bitIndex);
        }
    }
}
