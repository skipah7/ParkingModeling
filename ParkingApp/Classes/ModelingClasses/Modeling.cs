using ParkingApp.Classes.AlgPathFind;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ParkingApp.Classes
{
    class Modeling
    {
        public static Point getLocationFromPathPoint(PathPoint pathPoint)
        {
            return new Point(pathPoint.X * Globals.PICTURE_BOX_SIZE, pathPoint.Y * Globals.PICTURE_BOX_SIZE);
        }
    }
}
