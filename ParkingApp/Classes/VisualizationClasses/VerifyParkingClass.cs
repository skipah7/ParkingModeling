using System;

namespace ParkingApp.Classes
{
    class VerifyParkingClass
    {
        public bool isParkingLayoutCorrect()
        {
            bool isLightParkingPlaceExists = false;
            int entraceCount = 0;
            int exitCount = 0;
            int heavyParkingMainCount = 0;
            int heavyParkingSecondCount = 0;
            for (int x = 0; x < Globals.patterns.GetLength(0); x++)
                for (int y = 0; y < Globals.patterns.GetLength(1); y++)
                {
                    if (Globals.patterns[x, y] == Globals.LIGHT_PARKING_PLACE) isLightParkingPlaceExists = true;
                    if (Globals.patterns[x, y] == Globals.ENTRANCE) entraceCount++;
                    if (Globals.patterns[x, y] == Globals.EXIT) exitCount++;
                    if (Globals.patterns[x, y] == Globals.HEAVY_PARKING_PLACE_MAIN) heavyParkingMainCount++;
                    if (Globals.patterns[x, y] == Globals.HEAVY_PARKING_PLACE_SECOND) heavyParkingSecondCount++;
                }

            bool isHeavyParkingCorrect = (heavyParkingSecondCount != 0 && heavyParkingMainCount != 0) && (heavyParkingMainCount == heavyParkingSecondCount);
            bool isEntranceAndExitCorrect = exitCount == 1 && entraceCount == 1;
            return isLightParkingPlaceExists && isEntranceAndExitCorrect && isHeavyParkingCorrect;
        }
    }
}
