using System;

namespace ParkingApp.Classes
{
    class VerifyParkingClass
    {
        public bool isParkingLayoutCorrect(string[,] patterns)
        {
            bool isLightParkingPlaceExists = false;
            int entraceCount = 0;
            int exitCount = 0;
            int heavyParkingMainCount = 0;
            int heavyParkingSecondCount = 0;
            for (int x = 0; x < patterns.GetLength(0); x++)
                for (int y = 0; y < patterns.GetLength(1); y++)
                {
                    if (patterns[x, y] == Globals.LIGHT_PARKING_PLACE) isLightParkingPlaceExists = true;
                    if (patterns[x, y] == Globals.ENTRANCE) entraceCount++;
                    if (patterns[x, y] == Globals.EXIT) exitCount++;
                    if (patterns[x, y] == Globals.HEAVY_PARKING_PLACE_MAIN) heavyParkingMainCount++;
                    if (patterns[x, y] == Globals.HEAVY_PARKING_PLACE_SECOND) heavyParkingSecondCount++;
                }

            bool isHeavyParkingCorrect = (heavyParkingSecondCount != 0 && heavyParkingMainCount != 0) && (heavyParkingMainCount == heavyParkingSecondCount);
            bool isEntranceAndExitCorrect = exitCount == 1 && entraceCount == 1;
            return isLightParkingPlaceExists && isEntranceAndExitCorrect && isHeavyParkingCorrect;
        }
    }
}
