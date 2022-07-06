using System.Runtime.InteropServices;

namespace DanTheMan827.SM64.Saves
{
    public struct LevelFlags
    {
        [MarshalAs(UnmanagedType.U1)]
        private byte RawData;

        public bool Star1
        {
            get => RawData.GetBit(0);
            set => RawData = RawData.SetBit(0, value);
        }
        public bool Star2
        {
            get => RawData.GetBit(1);
            set => RawData = RawData.SetBit(1, value);
        }
        public bool Star3
        {
            get => RawData.GetBit(2);
            set => RawData = RawData.SetBit(2, value);
        }
        public bool Star4
        {
            get => RawData.GetBit(3);
            set => RawData = RawData.SetBit(3, value);
        }
        public bool Star5
        {
            get => RawData.GetBit(4);
            set => RawData = RawData.SetBit(4, value);
        }
        public bool Star6
        {
            get => RawData.GetBit(5);
            set => RawData = RawData.SetBit(5, value);
        }
        public bool Star7
        {
            get => RawData.GetBit(6);
            set => RawData = RawData.SetBit(6, value);
        }
        public bool CannonUnlocked
        {
            get => RawData.GetBit(7);
            set => RawData = RawData.SetBit(7, value);
        }
    }
}
