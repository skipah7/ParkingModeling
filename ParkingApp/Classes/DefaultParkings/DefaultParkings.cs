using System;

namespace ParkingApp.Classes
{
    class DefaultParkings
    {
        private string[,] default_5_5 = new String[5,5];

        private void setDefault_5_5()
        {
            default_5_5[0, 0] = Globals.TREE;
            default_5_5[0, 1] = Globals.LIGHT_PARKING_PLACE;
            default_5_5[0, 2] = Globals.LIGHT_PARKING_PLACE;
            default_5_5[0, 3] = Globals.LIGHT_PARKING_PLACE;
            default_5_5[0, 4] = Globals.TREE;

            default_5_5[1, 0] = Globals.LIGHT_PARKING_PLACE;
            default_5_5[1, 1] = Globals.ROAD;
            default_5_5[1, 2] = Globals.ROAD;
            default_5_5[1, 3] = Globals.ROAD;
            default_5_5[1, 4] = Globals.EXIT;

            default_5_5[2, 0] = Globals.LIGHT_PARKING_PLACE;
            default_5_5[2, 1] = Globals.ROAD;
            default_5_5[2, 2] = Globals.LIGHT_PARKING_PLACE;
            default_5_5[2, 3] = Globals.LIGHT_PARKING_PLACE;
            default_5_5[2, 4] = Globals.TREE;

            default_5_5[3, 0] = Globals.LIGHT_PARKING_PLACE;
            default_5_5[3, 1] = Globals.ROAD;
            default_5_5[3, 2] = Globals.ROAD;
            default_5_5[3, 3] = Globals.ROAD;
            default_5_5[3, 4] = Globals.ENTRANCE;

            default_5_5[4, 0] = Globals.TREE;
            default_5_5[4, 1] = Globals.LIGHT_PARKING_PLACE;
            default_5_5[4, 2] = Globals.LIGHT_PARKING_PLACE;
            default_5_5[4, 3] = Globals.LIGHT_PARKING_PLACE;
            default_5_5[4, 4] = Globals.TREE;
        }

        public string[,] getDefault_5_5()
        {
            setDefault_5_5();
            return this.default_5_5;
        }

    }
}
