using DanTheMan827.SM64.Saves;
using System;
using System.IO;

namespace SM64_Save_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new EepromData(true);

            MakeBeyondPerfectSave(ref data.GameDataA);
            data.GameDataA.FileExists = true;
            data.GameDataA.BobOmbBattlefieldScore = 100;
            data.GameDataA.WhompsFortressScore = 100;
            data.GameDataA.JollyRogerBayScore = 100;
            data.GameDataA.CoolCoolMountainScore = 100;
            data.GameDataA.BigBoosHauntScore = 100;
            data.GameDataA.HazyMazeCaveScore = 100;
            data.GameDataA.LethalLavaLandScore = 100;
            data.GameDataA.ShiftingSandLandScore = 100;
            data.GameDataA.DireDireDocksScore = 100;
            data.GameDataA.SnowmansLandScore = 100;
            data.GameDataA.WetDryWorldScore = 100;
            data.GameDataA.TallTallMountainScore = 100;
            data.GameDataA.TinyHugeIslandScore = 100;
            data.GameDataA.TickTockClockScore = 100;
            data.GameDataA.RainbowRideScore = 100;

            data.GameDataA.ExtraStar1 = true;
            data.GameDataA.ExtraStar2 = true;
            data.GameDataA.ExtraStar3 = true;
            data.GameDataA.ExtraStar4MaybeMips2 = true;
            data.GameDataA.ExtraStar5MaybeMips1 = true;
            data.GameDataA.ExtraStar6 = true;
            data.GameDataA.ExtraStar7 = true;
            data.GameDataA.CalculateChecksum();
            data.GameDataABackup = data.GameDataA;
            File.WriteAllBytes("modified_save.eep", data.GetBytes());
        }

        static void MakeBeyondPerfectSave(ref GameData data)
        {
            AllStars(ref data.BobOmbBattlefield);
            AllStars(ref data.WhompsFortress);
            AllStars(ref data.JollyRogerBay);
            AllStars(ref data.CoolCoolMountain);
            AllStars(ref data.BigBoosHaunt);
            AllStars(ref data.HazyMazeCave);
            AllStars(ref data.LethalLavaLand);
            AllStars(ref data.ShiftingSandLand);
            AllStars(ref data.DireDireDocks);
            AllStars(ref data.SnowmansLand);
            AllStars(ref data.WetDryWorld);
            AllStars(ref data.TallTallMountain);
            AllStars(ref data.TinyHugeIsland);
            AllStars(ref data.TickTockClock);
            AllStars(ref data.RainbowRide);

            AllStars(ref data.BowserInTheDarkWorld);
            AllStars(ref data.BowserInTheFireSea);
            AllStars(ref data.BowserInTheSky);
            AllStars(ref data.ThePrincessSecretSlide);
            AllStars(ref data.CavernOfTheMetalCap);
            AllStars(ref data.TowerOfTheWingCap);
            AllStars(ref data.VanishCapUnderTheMoat);
            AllStars(ref data.WingMarioOverTheRainbow);
            AllStars(ref data.TheSecretAquarium);
            AllStars(ref data.TheEnd);

            data.DireDireDocksMovedBack = true;
            data.HaveMetalCap = true;
            data.HaveVanishCap = true;
            data.HaveWingCap = true;
            data.MoatDrained = true;
            data.UnlockedBasementDoor = true;
            data.UnlockedBowserInTheDarkWorldDoor = true;
            data.UnlockedBowserInTheFireSeaDoor = true;
            data.UnlockedCoolCoolMountainDoor = true;
            data.UnlockedFiftyStarDoor = true;
            data.UnlockedJollyRogerBayDoor = true;
            data.UnlockedPrincessSecretSlideDoor = true;
            data.UnlockedSecondFloorDoor = true;
            data.UnlockedWhompsFortressDoor = true;
        }

        static void PrintStars(ref LevelFlags level)
        {
            if (level.Star1)
                Console.WriteLine($"{nameof(level)} - Star 1");

            if (level.Star2)
                Console.WriteLine($"{nameof(level)} - Star 2");

            if (level.Star3)
                Console.WriteLine($"{nameof(level)} - Star 3");

            if (level.Star4)
                Console.WriteLine($"{nameof(level)} - Star 4");

            if (level.Star5)
                Console.WriteLine($"{nameof(level)} - Star 5");

            if (level.Star6)
                Console.WriteLine($"{nameof(level)} - Star 6");

            if (level.Star7)
                Console.WriteLine($"{nameof(level)} - Star 7");

            if (level.CannonUnlocked)
                Console.WriteLine($"{nameof(level)} - Cannon Unlocked");
        }

        static void AllStars(ref LevelFlags level)
        {
            level.Star1 = true;
            level.Star2 = true;
            level.Star3 = true;
            level.Star4 = true;
            level.Star5 = true;
            level.Star6 = true;
            level.Star7 = true;
            level.CannonUnlocked = true;
        }
    }
}
