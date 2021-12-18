using ParkingApp.Classes.VisualizationClasses;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ParkingApp.Classes
{
    class ParkingFieldClass
    {
        public void loadField(Panel panel)
        {
            Globals.pictureBoxes.ForEach((pic) => panel.Controls.Add(pic));
        }

        public string[,] fillPatternsArray(int width, int height)
        {
            string[,] patterns = new string[width, height];
            int z = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    patterns[x, y] = ImagesHelper.getNameOfImage(Globals.pictureBoxes.ElementAt(z).Image);
                    z++;
                }
            }

            return patterns;
        }

        public void fillPictureBoxesList(int width, int height, string[,] patterns)
        {
            Globals.pictureBoxes = new List<PictureBox>();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Image image = ImagesHelper.getImageByName(patterns[x, y]);
                    Globals.pictureBoxes.Add(createPictureBox(image, x, y));
                }
            }
        }        

        public void createField(Panel panel, int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Image image = ImagesHelper.getImageByName(Globals.ROAD);
                    PictureBox pictureBox = createPictureBox(image, x, y);

                    Globals.pictureBoxes.Add(pictureBox);
                    panel.Controls.Add(pictureBox);
                }
            }
        }

        #region main picture box creator + DragNDrop handlers
        public PictureBox createPictureBox(Image image, int x, int y)
        {
            PictureBox pictureBox = new PictureBox
            {
                Location = new Point(x * Globals.PICTURE_BOX_SIZE, y * Globals.PICTURE_BOX_SIZE),
                Name = x + "_" + y,
                Size = new Size(Globals.PICTURE_BOX_SIZE, Globals.PICTURE_BOX_SIZE),
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = true
            };
            pictureBox.DragEnter += pictureBoxDragEnter;
            pictureBox.DragDrop += pictureBoxDragDrop;
            pictureBox.Image = image;
            return pictureBox;
        }

        void pictureBoxDragDrop(object sender, DragEventArgs e)
        {
            ((PictureBox)sender).Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        void pictureBoxDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        #endregion
    }
}
