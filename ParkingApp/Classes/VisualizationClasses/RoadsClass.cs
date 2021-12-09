using ParkingApp.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace ParkingApp.Classes
{
    class RoadsClass
    {
        public static void createRoads(Panel panel)
        {
            for (int j = 0; j < Globals.WIDTH; j++)
            {
                PictureBox pictureBox = createRoadPictureBox(Globals.HEIGHT, j);
                panel.Controls.Add(pictureBox);
                pictureBox.BringToFront();
                Globals.highwayPatterns[Globals.HEIGHT, j] = Globals.HIGHWAY;
            }
        }

        private static PictureBox createRoadPictureBox(int i, int j)
        {
            PictureBox pictureBox = new PictureBox
            {
                Location = new Point(j * Globals.PICTURE_BOX_SIZE, i * Globals.PICTURE_BOX_SIZE),
                Name = i + "_" + j,
                Size = new Size(Globals.PICTURE_BOX_SIZE, Globals.PICTURE_BOX_SIZE),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Resources.highway
            };
            return pictureBox;
        }
    }
}
