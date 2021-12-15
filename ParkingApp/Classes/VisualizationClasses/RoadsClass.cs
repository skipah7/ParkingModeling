using ParkingApp.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace ParkingApp.Classes
{
    class RoadsClass
    {
        public static void createRoads(Panel panel)
        {
            for (int x = 0; x < Globals.WIDTH; x++)
            {
                PictureBox pictureBox = createRoadPictureBox(x, Globals.HEIGHT);
                panel.Controls.Add(pictureBox);
                pictureBox.BringToFront();
                Globals.highwayPatterns[x, Globals.HEIGHT] = Globals.HIGHWAY;
            }
        }

        private static PictureBox createRoadPictureBox(int x, int y)
        {
            PictureBox pictureBox = new PictureBox
            {
                Location = new Point(x * Globals.PICTURE_BOX_SIZE, y * Globals.PICTURE_BOX_SIZE),
                Name = x + "_" + y,
                Size = new Size(Globals.PICTURE_BOX_SIZE, Globals.PICTURE_BOX_SIZE),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Resources.road
            };
            return pictureBox;
        }
    }
}
