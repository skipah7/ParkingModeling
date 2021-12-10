using ParkingApp.Properties;
using System;
using System.Drawing;

namespace ParkingApp.Classes.VisualizationClasses
{
    class ImagesHelper
    {
        public static Image getImageByName(string name)
        {
            if (name.Equals(Globals.ENTRANCE))
            {
                return Resources.entrance;
            }
            if (name.Equals(Globals.EXIT))
            {
                return Resources.exit;
            }
            if (name.Equals(Globals.LIGHT_PARKING_PLACE))
            {
                return Resources.lightParkingPlace;
            }
            if (name.Equals(Globals.HEAVY_PARKING_PLACE))
            {
                return Resources.heavyParkingPlace;
            }
            if (name.Equals(Globals.ROAD))
            {
                return Resources.road;
            }
            if (name.Equals(Globals.HIGHWAY))
            {
                return Resources.highway;
            }
            if (name.Equals(Globals.TREE))
            {
                return Resources.tree;
            }
            if (name.Equals(Globals.EMPTY))
            {
                return Resources.empty;
            }

            return Resources.road;
        }

        public static string getNameOfImage(Image image)
        {
            if (image == null) return Globals.ROAD;

            Bitmap bitmap = new Bitmap(image);
            if (isImageSame(bitmap, Resources.entrance))
            {
                return Globals.ENTRANCE;
            }
            if (isImageSame(bitmap, Resources.exit))
            {
                return Globals.EXIT;
            }
            if (isImageSame(bitmap, Resources.lightParkingPlace))
            {
                return Globals.LIGHT_PARKING_PLACE;
            }
            if (isImageSame(bitmap, Resources.heavyParkingPlace))
            {
                return Globals.HEAVY_PARKING_PLACE;
            }
            if (isImageSame(bitmap, Resources.road))
            {
                return Globals.ROAD;
            }
            if (isImageSame(bitmap, Resources.highway))
            {
                return Globals.HIGHWAY;
            }
            if (isImageSame(bitmap, Resources.tree))
            {
                return Globals.TREE;
            }
            if (isImageSame(bitmap, Resources.empty))
            {
                return Globals.EMPTY;
            }

            return Globals.ROAD;
        }

        public static bool isImageSame(Bitmap bmp1, Bitmap bmp2)
        {
            if (!bmp1.Size.Equals(bmp2.Size))
            {
                return false;
            }
            for (int x = 0; x < bmp1.Width; x++)
            {
                for (int y = 0; y < bmp2.Height; y++)
                {
                    if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
