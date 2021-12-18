using ParkingApp.Classes.BaseParkingClasses;
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

        // height and width
        public static int WIDTH = 0;
        public static int HEIGHT = 0;

        public static int INTERVAL = 20;

        public static int z = 0;

        public static double delta;

        // modelling params
        public static Tariff tariff;

        public static ModelingParams modelingParams;

        public static List<TableItem> tabloItems = new List<TableItem>();

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

        // matrix pattern, is parking space
        public static string[,] patterns = new string[WIDTH, HEIGHT];
        //pictureboxes for parking painting
        public static List<PictureBox> pictureBoxes = new List<PictureBox>();

        // matrix pattern, is road
        public static string[,] highwayPatterns = new string[WIDTH + 1, HEIGHT + 1];

        // size of parking in pixels
        public static int SCREEN_SIZE = 500;

        public static int PICTURE_BOX_SIZE = 50;

        public static int leftAdjacentRoadLength = 0;
        public static int rightAdjacentRoadLength = 0;
        public static int downAdjacentRoadLength = 0;
        public static int upAdjacentRoadLength = 0;


        // its useless, right?
        public static void calculateDelta()
        {
            // second х1
            if(INTERVAL == 20)
            {
                delta = 1.65;
            } 
            // half a second х2
            else if(INTERVAL == 10)
            {
                delta = 3.2;
            }
            // quarter second х4
            else if (INTERVAL == 5)
            {
                delta = 3.7;
            }
            // two seconds х1/2
            else
            {
                delta = 1.05;
            }
        }

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
