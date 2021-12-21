using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ParkingApp
{
    public static class Globals
    {
        // roles
        public static string ADMINISTRATOR = "Administrator";
        public static string MANAGER = "Manager";

        // type of tarif
        public static string DAILY_RATE = "Daily";
        public static string HOURLY_RATE = "Hourly";

        public static int INTERVAL = 20;

        // patterns names, saved at patterns
        // is matrix of parking
        public const string TREE = "TREE";
        public const string HEAVY_PARKING_PLACE_MAIN = "HEAVY_PARKING_PLACE_MAIN";
        public const string HEAVY_PARKING_PLACE_SECOND = "HEAVY_PARKING_PLACE_SECOND";
        public const string LIGHT_PARKING_PLACE = "LIGHT_PARKING_PLACE";
        public const string ENTRANCE = "ENTRANCE";
        public const string EXIT = "EXIT";
        public const string ROAD = "ROAD";
        public const string HIGHWAY = "HIGHWAY";

        // parking file name
        public static string parkingFileName = "";
        // parking file path
        public static string parkingFilePath = "";
        // path to the site
        public static string pathToHtmlFile = "";

        // user directory based on project path
        public static string directory = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();

        //pictureboxes for parking painting
        public static List<PictureBox> pictureBoxes = new List<PictureBox>();

        // matrix pattern, is road
        public static string[,] highwayPatterns;

        // size of parking in pixels
        public static int SCREEN_SIZE = 500;

        public static int PICTURE_BOX_SIZE = 50;

        public static void calculatePictureBoxSize(int height, int width)
        {
            if (height >= width)
            {
                if ((SCREEN_SIZE / height) % 5 != 0)
                {
                    PICTURE_BOX_SIZE = (SCREEN_SIZE / height) - (SCREEN_SIZE / height) % 5;
                }
                else
                {
                    PICTURE_BOX_SIZE = SCREEN_SIZE / height;
                }
            }
            else
            {
                if ((SCREEN_SIZE / width) % 5 != 0)
                {
                    PICTURE_BOX_SIZE = (SCREEN_SIZE / width) - (SCREEN_SIZE / width) % 5;
                }
                else
                {
                    PICTURE_BOX_SIZE = SCREEN_SIZE / width;
                }
            }
        }
    }
}
