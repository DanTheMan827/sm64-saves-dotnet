using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace DanTheMan827.SM64.Saves
{
    public struct GlobalData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] CoinTieBreaker;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] SoundSetting;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] LanguageSetting;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] Unknown;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] MagicNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] Checksum;

        public bool LittleEndian
        {
            get
            {
                return BitConverter.ToUInt16(MagicNumber) == (BitConverter.IsLittleEndian ? 0x4849 : 0x4948);
            }
        }

        public GlobalData(bool littleEndian = false)
        {
            CoinTieBreaker = new byte[16];
            SoundSetting = new byte[2];
            LanguageSetting = new byte[2];
            Unknown = new byte[8];
            MagicNumber = littleEndian ? new byte[] { 0x49, 0x48 } : new byte[] { 0x48, 0x49 };
            Checksum = littleEndian ? new byte[] { 0x91, 0x00 } : new byte[] { 0x00, 0x91 };
        }

        public void CalculateChecksum()
        {
            int size = Marshal.SizeOf(this);
            byte[] data = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(this, ptr, true);
            Marshal.Copy(ptr, data, 0, size);
            Marshal.FreeHGlobal(ptr);

            UInt16 checksum = 0;
            for (var i = 0; i < size - 2; i++)
            {
                checksum += data[i];
            }

            Checksum = BitConverter.GetBytes(checksum);

            if ((!LittleEndian && BitConverter.IsLittleEndian) || (LittleEndian && !BitConverter.IsLittleEndian))
            {
                Checksum = Checksum.Reverse().ToArray();
            }
        }
    }
}
