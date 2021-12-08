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
        public static String ADMINISTRATOR = "Administrator";
        public static String MANAGER = "Manager";

        // type of tarif
        public static String DAILY_RATE = "Daily";
        public static String HOURLY_RATE = "Hourly";

        // height and width
        public static int WIDTH = 0;
        public static int HEIGHT = 0;
        public static int MAX_SIZE = 10;
        public static int MIN_SIZE = 5;

        public static int INTERVAL = 20;

        public static int z = 0;

        public static double delta;

        // tariff
        public static Tariff tariff;

        public static ModelingParams modelingParams;

        public static List<TabloItem> tabloItems = new List<TabloItem>();

        public static bool isNewParking = true;

        // patterns names, saved at patterns
        // is matrix of parking
        public const String TREE = "Tree";
        public const String CASH_BOX = "Cash box";
        public const String PARKING_PLACE = "Auto";
        public const String GRASS = "Grass";
        public const String ENTRANCE = "Entrance";
        public const String EXIT = "Exit";
        public const String ROAD = "Road";
        public const String HIGHWAY = "Highway";

        // parking file name
        public static String parkingFileName = "";
        // parking file path
        public static String parkingFilePath = "";
        // path to the site
        public static string pathToHtmlFile = "";

        // user directory based on project path
        public static String directory = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();

        // matrix pattern, is parking space
        public static String[,] patterns = new String[WIDTH, HEIGHT];
        //pictureboxes for parking painting
        public static List<PictureBox> pictureBoxes = new List<PictureBox>();

        // matrix pattern, is road
        public static String[,] highwayPatterns = new String[WIDTH + 1, HEIGHT + 1];

        // size of parking in pixels
        public static int SCREEN_SIZE = 500;

        public static int PICTURE_BOX_SIZE = 50;

        public static int leftAdjacentRoadLength = 0;
        public static int rightAdjacentRoadLength = 0;
        public static int downAdjacentRoadLength = 0;
        public static int upAdjacentRoadLength = 0;

        public static bool IS_CORRECT_PARKING;

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

        public static void calculatePictureBoxSize()
        {
            if (HEIGHT >= WIDTH)
            {
                if ((SCREEN_SIZE / HEIGHT) % 5 != 0)
                {
                    PICTURE_BOX_SIZE = (SCREEN_SIZE / HEIGHT) - (SCREEN_SIZE / HEIGHT) % 5;
                }
                else
                {
                    PICTURE_BOX_SIZE = SCREEN_SIZE / HEIGHT;
                }
            }
            else
            {
                if ((SCREEN_SIZE / WIDTH) % 5 != 0)
                {
                    PICTURE_BOX_SIZE = (SCREEN_SIZE / WIDTH) - (SCREEN_SIZE / WIDTH) % 5;
                }
                else
                {
                    PICTURE_BOX_SIZE = SCREEN_SIZE / WIDTH;
                }
            }
        }
    }
}
