using System;

namespace ParkingApp
{
    [Serializable]
    class ParkingField
    {
        private int width;
        private int height;
        private string[,] patterns;        

        public ParkingField(int width, int height, string[,] patterns)
        {
            this.width = width;
            this.height = height;
            this.patterns = patterns;
        }

        public string[,] getPatterns()
        {
            return this.patterns;
        }

        public int getWidth()
        {
            return this.width;
        }

        public int getHeight()
        {
            return this.height;
        }
    }
}
