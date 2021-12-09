using ParkingApp.Classes.VisualizationClasses;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ParkingApp.Classes
{
    class ParkingFieldClass
    {
        ProcessImagesClass processImages;

        public ParkingFieldClass()
        {
            processImages = new ProcessImagesClass();
        }

        public void loadField(Panel panel1)
        {
            Globals.pictureBoxes.ForEach((pic) => panel1.Controls.Add(pic));
        }

        public void fillPatternsArray()
        {
            int z = 0;
            int k = Globals.pictureBoxes.Count;
            for (int i = 0; i < Globals.WIDTH; i++)
            {
                for (int j = 0; j < Globals.HEIGHT; j++)
                {
                    if (z < k)
                    {
                        Globals.patterns[i, j] = processImages.getNameOfImage(Globals.pictureBoxes.ElementAt(z).Image);
                        z++;
                    }
                }
            }
        }

        public void fillPictureBoxesList()
        {
            Globals.pictureBoxes = new List<PictureBox>();

            for (int i = 0; i < Globals.HEIGHT; i++)
            {
                for (int j = 0; j < Globals.WIDTH; j++)
                {
                    Image image = processImages.getImageByName(Globals.patterns[i, j]);
                    Globals.pictureBoxes.Add(createPictureBox(image, i, j));
                }
            }
        }        

        public void createField(Panel panel)
        {
            for (int i = 0; i < Globals.HEIGHT; i++)
            {
                for (int j = 0; j < Globals.WIDTH; j++)
                {
                    Image image = processImages.getImageByName(Globals.EMPTY);
                    PictureBox pictureBox = createPictureBox(image, i, j);

                    Globals.pictureBoxes.Add(pictureBox);
                    panel.Controls.Add(pictureBox);
                }
            }
        }

        public PictureBox createPictureBox(Image image, int i, int j)
        {
            PictureBox pictureBox = new PictureBox
            {
                Location = new Point(j * Globals.PICTURE_BOX_SIZE, i * Globals.PICTURE_BOX_SIZE),
                Name = i + "_" + j,
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
            PictureBox p = sender as PictureBox;
            p.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        void pictureBoxDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }
    }
}
