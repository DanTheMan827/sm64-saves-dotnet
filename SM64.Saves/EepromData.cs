using System;
using System.Runtime.InteropServices;

namespace DanTheMan827.SM64.Saves
{
    public struct EepromData
    {
        public GameData GameDataA;
        public GameData GameDataABackup;
        public GameData GameDataB;
        public GameData GameDataBBackup;
        public GameData GameDataC;
        public GameData GameDataCBackup;
        public GameData GameDataD;
        public GameData GameDataDBackup;
        public GlobalData GlobalData;
        public GlobalData GlobalDataBackup;

        public EepromData(bool littleEndian = false)
        {
            GameDataA = new GameData(littleEndian);
            GameDataABackup = new GameData(littleEndian);
            GameDataB = new GameData(littleEndian);
            GameDataBBackup = new GameData(littleEndian);
            GameDataC = new GameData(littleEndian);
            GameDataCBackup = new GameData(littleEndian);
            GameDataD = new GameData(littleEndian);
            GameDataDBackup = new GameData(littleEndian);
            GlobalData = new GlobalData(littleEndian);
            GlobalDataBackup = new GlobalData(littleEndian);

        }

        public byte[] GetBytes()
        {
            int size = Marshal.SizeOf(this);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(this, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }
        public static EepromData Read(byte[] buffer, int pos = 0)
        {
            var size = Marshal.SizeOf(typeof(EepromData));
            if (buffer.Length < pos + size || size == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(buffer, pos, ptr, size);
            var r = (EepromData)Marshal.PtrToStructure(ptr, typeof(EepromData));
            Marshal.FreeHGlobal(ptr);
            return r;
        }


    }
}
