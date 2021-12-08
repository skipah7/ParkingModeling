using ParkingApp.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace ParkingApp.Classes
{
    class AdjacentRoadClass
    {
        //Создать дорогу снизу от паркинга
        public void createDownAdjacentRoad(Panel panel1)
        {
            for (int j = 0; j < Globals.WIDTH; j++)
            {
                PictureBox pictureBox = createRoadPictureBox(Globals.HEIGHT, j);
                panel1.Controls.Add(pictureBox);
                pictureBox.BringToFront();
                Globals.highwayPatterns[Globals.HEIGHT, j] = Globals.HIGHWAY;
            }
        }

        private PictureBox createRoadPictureBox(int i, int j)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(0 + j * Globals.PICTURE_BOX_SIZE, 0 + i * Globals.PICTURE_BOX_SIZE);
            pictureBox.Name = i + "_" + j;
            pictureBox.Size = new Size(Globals.PICTURE_BOX_SIZE, Globals.PICTURE_BOX_SIZE);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = Resources.entrancePic;
            return pictureBox;
        }
    }
}
