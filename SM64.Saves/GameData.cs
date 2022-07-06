using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace DanTheMan827.SM64.Saves
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GameData
    {
        public enum LostCap
        {
            Mario,
            ShiftingSandLand,
            SnowmansLand,
            TallTallMountain
        }

        // Lost Cap Location
        [MarshalAs(UnmanagedType.U1)]
        private byte _LostCapCourse;
        public LostCap LostCapCourse
        {
            get
            {
                switch (_LostCapCourse)
                {
                    case 0x08:
                        return LostCap.ShiftingSandLand;
                    case 0x0A:
                        return LostCap.SnowmansLand;
                    case 0x24:
                        return LostCap.TallTallMountain;
                    default:
                        return LostCap.Mario;
                }
            }
            set
            {
                LostCapOnGround = false;
                LostCapInShiftingSandLand = false;
                LostCapInSnowmansLand = false;
                LostCapInTallTallMountain = false;

                switch (value)
                {
                    case LostCap.Mario:
                        _LostCapCourse = 0x00;
                        break;
                    case LostCap.ShiftingSandLand:
                        _LostCapCourse = 0x08;
                        LostCapInShiftingSandLand = true;
                        break;
                    case LostCap.SnowmansLand:
                        _LostCapCourse = 0x0A;
                        LostCapInShiftingSandLand = true;
                        break;
                    case LostCap.TallTallMountain:
                        _LostCapCourse = 0x24;
                        LostCapInTallTallMountain = true;
                        break;
                }
            }
        }
        [MarshalAs(UnmanagedType.U1)]
        public byte LostCapArea;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] LostCapXCoordinate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] LostCapYCoordinate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] LostCapZCoordinate;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Flags;
        public bool FileExists
        {
            get => Flags.GetBit(LittleEndian ? 0 : 31);
            set => Flags = Flags.SetBit(LittleEndian ? 0 : 31, value);
        }

        public bool HaveWingCap
        {
            get => Flags.GetBit(LittleEndian ? 1 : 30);
            set => Flags = Flags.SetBit(LittleEndian ? 1 : 30, value);
        }
        public bool HaveMetalCap
        {
            get => Flags.GetBit(LittleEndian ? 2 : 29);
            set => Flags = Flags.SetBit(LittleEndian ? 2 : 29, value);
        }
        public bool HaveVanishCap
        {
            get => Flags.GetBit(LittleEndian ? 3 : 28);
            set => Flags = Flags.SetBit(LittleEndian ? 3 : 28, value);
        }
        public bool HaveBasementKey
        {
            get => Flags.GetBit(LittleEndian ? 4 : 27);
            set => Flags = Flags.SetBit(LittleEndian ? 4 : 27, value);
        }
        public bool HaveSecondFloorKey
        {
            get => Flags.GetBit(LittleEndian ? 5 : 26);
            set => Flags = Flags.SetBit(LittleEndian ? 5 : 26, value);
        }
        public bool UnlockedBasementDoor
        {
            get => Flags.GetBit(LittleEndian ? 6 : 25);
            set => Flags = Flags.SetBit(LittleEndian ? 6 : 25, value);
        }
        public bool UnlockedSecondFloorDoor
        {
            get => Flags.GetBit(LittleEndian ? 7 : 24);
            set => Flags = Flags.SetBit(LittleEndian ? 7 : 24, value);
        }

        public bool DireDireDocksMovedBack
        {
            get => Flags.GetBit(LittleEndian ? 8 : 23);
            set => Flags = Flags.SetBit(LittleEndian ? 8 : 23, value);
        }
        public bool MoatDrained
        {
            get => Flags.GetBit(LittleEndian ? 9 : 22);
            set => Flags = Flags.SetBit(LittleEndian ? 9 : 22, value);
        }
        public bool UnlockedPrincessSecretSlideDoor
        {
            get => Flags.GetBit(LittleEndian ? 10 : 21);
            set => Flags = Flags.SetBit(LittleEndian ? 10 : 21, value);
        }
        public bool UnlockedWhompsFortressDoor
        {
            get => Flags.GetBit(LittleEndian ? 11 : 20);
            set => Flags = Flags.SetBit(LittleEndian ? 11 : 20, value);
        }
        public bool UnlockedCoolCoolMountainDoor
        {
            get => Flags.GetBit(LittleEndian ? 12 : 19);
            set => Flags = Flags.SetBit(LittleEndian ? 12 : 19, value);
        }
        public bool UnlockedJollyRogerBayDoor
        {
            get => Flags.GetBit(LittleEndian ? 13 : 18);
            set => Flags = Flags.SetBit(LittleEndian ? 13 : 18, value);
        }
        public bool UnlockedBowserInTheDarkWorldDoor
        {
            get => Flags.GetBit(LittleEndian ? 14 : 17);
            set => Flags = Flags.SetBit(LittleEndian ? 14 : 17, value);
        }
        public bool UnlockedBowserInTheFireSeaDoor
        {
            get => Flags.GetBit(LittleEndian ? 15 : 16);
            set => Flags = Flags.SetBit(LittleEndian ? 15 : 16, value);
        }

        public bool LostCapOnGround
        {
            get => Flags.GetBit(LittleEndian ? 16 : 15);
            set => Flags = Flags.SetBit(LittleEndian ? 16 : 15, value);
        }
        public bool LostCapInShiftingSandLand
        {
            get => Flags.GetBit(LittleEndian ? 17 : 14);
            set => Flags = Flags.SetBit(LittleEndian ? 17 : 14, value);
        }
        public bool LostCapInTallTallMountain
        {
            get => Flags.GetBit(LittleEndian ? 18 : 13);
            set => Flags = Flags.SetBit(LittleEndian ? 18 : 13, value);
        }
        public bool LostCapInSnowmansLand
        {
            get => Flags.GetBit(LittleEndian ? 19 : 12);
            set => Flags = Flags.SetBit(LittleEndian ? 19 : 12, value);
        }
        public bool UnlockedFiftyStarDoor
        {
            get => Flags.GetBit(LittleEndian ? 20 : 11);
            set => Flags = Flags.SetBit(LittleEndian ? 20 : 11, value);
        }

        internal bool Bit21
        {
            get => Flags.GetBit(LittleEndian ? 21 : 10);
            set => Flags = Flags.SetBit(LittleEndian ? 21 : 10, value);
        }

        internal bool Bit22
        {
            get => Flags.GetBit(LittleEndian ? 22 : 9);
            set => Flags = Flags.SetBit(LittleEndian ? 22 : 9, value);
        }

        internal bool Bit23
        {
            get => Flags.GetBit(LittleEndian ? 23 : 8);
            set => Flags = Flags.SetBit(LittleEndian ? 23 : 8, value);
        }

        // Castle Flags

        public bool ExtraStar1
        {
            get => Flags.GetBit(LittleEndian ? 24 : 7);
            set => Flags = Flags.SetBit(LittleEndian ? 24 : 7, value);
        }

        public bool ExtraStar2
        {
            get => Flags.GetBit(LittleEndian ? 25 : 6);
            set => Flags = Flags.SetBit(LittleEndian ? 25 : 6, value);
        }

        public bool ExtraStar3
        {
            get => Flags.GetBit(LittleEndian ? 26 : 5);
            set => Flags = Flags.SetBit(LittleEndian ? 26 : 5, value);
        }

        public bool ExtraStar4MaybeMips2
        {
            get => Flags.GetBit(LittleEndian ? 27 : 4);
            set => Flags = Flags.SetBit(LittleEndian ? 27 : 4, value);
        }

        public bool ExtraStar5MaybeMips1
        {
            get => Flags.GetBit(LittleEndian ? 28 : 3);
            set => Flags = Flags.SetBit(LittleEndian ? 28 : 3, value);
        }

        public bool ExtraStar6
        {
            get => Flags.GetBit(LittleEndian ? 29 : 2);
            set => Flags = Flags.SetBit(LittleEndian ? 29 : 2, value);
        }

        public bool ExtraStar7
        {
            get => Flags.GetBit(LittleEndian ? 30 : 1);
            set => Flags = Flags.SetBit(LittleEndian ? 30 : 1, value);
        }

        public bool Bit31
        {
            get => Flags.GetBit(LittleEndian ? 31 : 0);
            set => Flags = Flags.SetBit(LittleEndian ? 31 : 0, value);
        }


        // Level Flags
        public LevelFlags BobOmbBattlefield;
        public LevelFlags WhompsFortress;
        public LevelFlags JollyRogerBay;
        public LevelFlags CoolCoolMountain;
        public LevelFlags BigBoosHaunt;
        public LevelFlags HazyMazeCave;
        public LevelFlags LethalLavaLand;
        public LevelFlags ShiftingSandLand;
        public LevelFlags DireDireDocks;
        public LevelFlags SnowmansLand;
        public LevelFlags WetDryWorld;
        public LevelFlags TallTallMountain;
        public LevelFlags TinyHugeIsland;
        public LevelFlags TickTockClock;
        public LevelFlags RainbowRide;
        public LevelFlags BowserInTheDarkWorld;
        public LevelFlags BowserInTheFireSea;
        public LevelFlags BowserInTheSky;
        public LevelFlags ThePrincessSecretSlide;
        public LevelFlags CavernOfTheMetalCap;
        public LevelFlags TowerOfTheWingCap;
        public LevelFlags VanishCapUnderTheMoat;
        public LevelFlags WingMarioOverTheRainbow;
        public LevelFlags TheSecretAquarium;
        public LevelFlags TheEnd;

        // Level High Scores (Coins)
        [MarshalAs(UnmanagedType.U1)]
        public byte BobOmbBattlefieldScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte WhompsFortressScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte JollyRogerBayScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte CoolCoolMountainScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte BigBoosHauntScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte HazyMazeCaveScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte LethalLavaLandScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte ShiftingSandLandScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte DireDireDocksScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte SnowmansLandScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte WetDryWorldScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte TallTallMountainScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte TinyHugeIslandScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte TickTockClockScore;
        [MarshalAs(UnmanagedType.U1)]
        public byte RainbowRideScore;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] MagicNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] Checksum;

        public bool LittleEndian
        {
            get
            {
                return BitConverter.ToUInt16(MagicNumber) == (BitConverter.IsLittleEndian ? 0x4441 : 0x4144);
            }
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
            for (var i = 0; i < 54; i++)
            {
                checksum += data[i];
            }



            if ((!LittleEndian && BitConverter.IsLittleEndian) || (LittleEndian && !BitConverter.IsLittleEndian))
            {
                Checksum = BitConverter.GetBytes(checksum).Reverse().ToArray();
            }
            else
            {
                Checksum = BitConverter.GetBytes(checksum);
            }
        }

        public GameData(bool littleEndian = false)
        {
            MagicNumber = littleEndian ? new byte[] { 0x41, 0x44 } : new byte[] { 0x44, 0x41 };
            _LostCapCourse = 0;
            LostCapArea = 0x01;
            LostCapXCoordinate = new byte[] { 0, 00, 0x00 };
            LostCapYCoordinate = new byte[] { 0x00, 0x00 };
            LostCapZCoordinate = new byte[] { 0x00, 0x00 };
            Flags = new byte[] { 0x00, 0x00, 0x00, 0x00 };

            // Level Flags
            BobOmbBattlefield = new LevelFlags();
            WhompsFortress = new LevelFlags();
            JollyRogerBay = new LevelFlags();
            CoolCoolMountain = new LevelFlags();
            BigBoosHaunt = new LevelFlags();
            HazyMazeCave = new LevelFlags();
            LethalLavaLand = new LevelFlags();
            ShiftingSandLand = new LevelFlags();
            DireDireDocks = new LevelFlags();
            SnowmansLand = new LevelFlags();
            WetDryWorld = new LevelFlags();
            TallTallMountain = new LevelFlags();
            TinyHugeIsland = new LevelFlags();
            TickTockClock = new LevelFlags();
            RainbowRide = new LevelFlags();
            BowserInTheDarkWorld = new LevelFlags();
            BowserInTheFireSea = new LevelFlags();
            BowserInTheSky = new LevelFlags();
            ThePrincessSecretSlide = new LevelFlags();
            CavernOfTheMetalCap = new LevelFlags();
            TowerOfTheWingCap = new LevelFlags();
            VanishCapUnderTheMoat = new LevelFlags();
            WingMarioOverTheRainbow = new LevelFlags();
            TheSecretAquarium = new LevelFlags();
            TheEnd = new LevelFlags();

            // Level Scores
            BobOmbBattlefieldScore = 0;
            WhompsFortressScore = 0;
            JollyRogerBayScore = 0;
            CoolCoolMountainScore = 0;
            BigBoosHauntScore = 0;
            HazyMazeCaveScore = 0;
            LethalLavaLandScore = 0;
            ShiftingSandLandScore = 0;
            DireDireDocksScore = 0;
            SnowmansLandScore = 0;
            WetDryWorldScore = 0;
            TallTallMountainScore = 0;
            TinyHugeIslandScore = 0;
            TickTockClockScore = 0;
            RainbowRideScore = 0;

            Checksum = littleEndian ? new byte[] { 0x00, 0x56 } : new byte[] { 0x56, 0x00 };
        }
    }
}
