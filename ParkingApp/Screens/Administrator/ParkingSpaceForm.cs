using ParkingApp.Classes;
using ParkingApp.Classes.VisualizationClasses;
using ParkingApp.Properties;
using ParkingApp.Screens.Administrator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ParkingApp
{
    public partial class ParkingSpaceForm : Form
    {
        ParkingFieldClass parkingFieldClass;
        public ParkingSpaceForm()
        {
            InitializeComponent();
            heightBox.Value = Globals.HEIGHT;
            widthBox.Value = Globals.WIDTH;
            modelPanel.Location = new Point(1, 1);

            Globals.calculatePictureBoxSize();
            parkingFieldClass = new ParkingFieldClass();

            if (Globals.isNewParking)
            {
                Globals.pictureBoxes = new List<PictureBox>();
                Globals.patterns = new string[Globals.WIDTH, Globals.HEIGHT];
                Globals.highwayPatterns = new string[Globals.WIDTH, Globals.HEIGHT + 1];
                parkingFieldClass.createField(modelPanel);            
            }
            else
            {
                parkingFieldClass.fillPictureBoxesList();
                parkingFieldClass.loadField(modelPanel);
            }

            foreach (var control in modelPanel.Controls)
            {
                ((PictureBox)control).DragEnter += dragValidationEntranceExit;
                ((PictureBox)control).DragEnter += dragValidationHeavyParking;
            }
            RoadsClass.createRoads(modelPanel);
        }             

        private void dragValidationHeavyParking(object sender, DragEventArgs e)
        {
            Bitmap currentImage = ((DataObject)e.Data).GetImage() as Bitmap;
            if (!ImagesHelper.isImageSame(currentImage, Resources.heavyParkingPlaceSecond))
            {
                return;
            }

            string[] contiguousElements = getContiguousElements(sender as PictureBox);

            bool isMainHeavyPakingNearby = false;
            bool isHeavyParkingSeconAlreadyExist = false;
            foreach (string element in contiguousElements)
            {
                Control[] controls = this.Controls.Find(element, true);
                if (controls.Length == 0) continue;

                PictureBox neabyPictureBox = controls[0] as PictureBox;
                isMainHeavyPakingNearby = ImagesHelper.isImageSame(neabyPictureBox.Image as Bitmap, Resources.heavyParkingPlaceMain);
                if (!isMainHeavyPakingNearby) continue;

                string[] contiguousElementsWithHeavyParking = getContiguousElements(neabyPictureBox);
                foreach (string elementCoordinates in contiguousElementsWithHeavyParking)
                {
                    Control[] nearbyControls = this.Controls.Find(elementCoordinates, true);
                    if (nearbyControls.Length == 0) continue;

                    PictureBox pictureBox = nearbyControls[0] as PictureBox;
                    isHeavyParkingSeconAlreadyExist = ImagesHelper.isImageSame(pictureBox.Image as Bitmap, Resources.heavyParkingPlaceSecond);
                    if (isHeavyParkingSeconAlreadyExist) break;
                }

                break;
            }

            if (!isMainHeavyPakingNearby || isHeavyParkingSeconAlreadyExist)
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private string[] getContiguousElements(PictureBox pictureBox)
        {
            int x = pictureBox.Location.X / pictureBox.Size.Width;
            int y = pictureBox.Location.Y / pictureBox.Size.Height;
            return new string[] { $"{x + 1}_{y}", $"{x - 1}_{y}", $"{x}_{y + 1}", $"{x}_{y - 1}" };
        }

        private void dragValidationEntranceExit(object sender, DragEventArgs e)
        {
            Bitmap currentImage = ((DataObject)e.Data).GetImage() as Bitmap;
            if (!ImagesHelper.isImageSame(currentImage, Resources.entrance) && !ImagesHelper.isImageSame(currentImage, Resources.exit))
            {
                return;
            }

            bool isBottomRow = ((sender as PictureBox).Location.Y / (sender as PictureBox).Size.Height) == Globals.HEIGHT - 1;
            if (!isBottomRow)
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #region button handlers
        private void saveToFile_Click(object sender, EventArgs e)
        {
            parkingFieldClass.fillPatternsArray();
            VerifyParkingClass verifyParking = new VerifyParkingClass();
            if (verifyParking.isCorrectNumberOfTerminals() && verifyParking.isTerminalsAtTheBorder())
            {
                SaveForm saveForm = new SaveForm();
                saveForm.Show();
                return;
            }
            MessageBox.Show("Убедитесь в правильности заполнения пространства парковки", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void refreshParking_Click(object sender, EventArgs e)
        {
            parkingFieldClass.fillPatternsArray();

            int width = (int)widthBox.Value;
            int height = (int)heightBox.Value;

            Globals.isNewParking = false;
            Globals.HEIGHT = height;
            Globals.WIDTH = width;

            Globals.patterns = ResizeArray<string>(Globals.patterns, width, height);
            Globals.highwayPatterns = new string[width, height + 1];

            Globals.downAdjacentRoadLength = height + 1;
            Globals.leftAdjacentRoadLength = width + 1;
            Globals.rightAdjacentRoadLength = 0;
            Globals.upAdjacentRoadLength = 0;

            this.Hide();
            ParkingSpaceForm parkingSpaceForm = new ParkingSpaceForm();
            parkingSpaceForm.Show();
        }

        T[,] ResizeArray<T>(T[,] original, int rows, int cols)
        {
            var newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                {
                    if (cols > original.GetLength(1))
                    {
                        newArray[i, j + cols - original.GetLength(1)] = original[i, j];
                    } else
                    {
                        newArray[i, j] = original[i, j + original.GetLength(1) - cols];
                    }
                }
            return newArray;
        }

        #endregion

        #region parking elements helpers
        private void mouseDownEntrance(object sender, MouseEventArgs e)
        {
            entrance.DoDragDrop(entrance.Image, DragDropEffects.Copy);
        }

        private void mouseDownExit(object sender, MouseEventArgs e)
        {
            exit.DoDragDrop(exit.Image, DragDropEffects.Copy);
        }

        private void mouseDownHeavyParkingPlace(object sender, MouseEventArgs e)
        {
            heavyParkingPlaceMain.DoDragDrop(heavyParkingPlaceMain.Image, DragDropEffects.Copy);
        }

        private void mouseDownLightParkingPlace(object sender, MouseEventArgs e)
        {
            lightParkingPlace.DoDragDrop(lightParkingPlace.Image, DragDropEffects.Copy);
        }

        private void mouseDownRoad(object sender, MouseEventArgs e)
        {
            road.DoDragDrop(road.Image, DragDropEffects.Copy);
        }

        private void mouseDownTree(object sender, MouseEventArgs e)
        {
            tree.DoDragDrop(tree.Image, DragDropEffects.Copy);
        }

        private void mouseDownEmpty(object sender, MouseEventArgs e)
        {
            heavyParkingPlaceSecond.DoDragDrop(heavyParkingPlaceSecond.Image, DragDropEffects.Copy);
        }

        private void mouseEnterPatternsPicBox(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            if (((PictureBox)sender).Name.Equals("lightParkingPlace"))
            {
                t.SetToolTip((PictureBox)sender, "Парковочное место легковой машины");
            }
            if (((PictureBox)sender).Name.Equals("road"))
            {
                t.SetToolTip((PictureBox)sender, "Дорога");
            }
            if (((PictureBox)sender).Name.Equals("entrance"))
            {
                t.SetToolTip((PictureBox)sender, "Въезд");
            }
            if (((PictureBox)sender).Name.Equals("heavyParkingPlaceMain"))
            {
                t.SetToolTip((PictureBox)sender, "Парковочное место грузовой машины");
            }
            if (((PictureBox)sender).Name.Equals("exit"))
            {
                t.SetToolTip((PictureBox)sender, "Выезд");
            }
            if (((PictureBox)sender).Name.Equals("tree"))
            {
                t.SetToolTip((PictureBox)sender, "Дерево");
            }
            if (((PictureBox)sender).Name.Equals("heavyParkingPlaceSecond"))
            {
                t.SetToolTip((PictureBox)sender, "Вторая часть парковочного места грузовой машины");
            }
        }

        #endregion

        #region helpers
        private void backButton_Click(object sender, EventArgs e)
        {
            System.Windows.MessageBoxResult confirmResult = System.Windows.MessageBox.Show(
                "Вы уверены? Несохраненные изменения будут потеряны!", "Подтвердить действие",
                System.Windows.MessageBoxButton.YesNo
            );

            if (confirmResult == System.Windows.MessageBoxResult.Yes)
            {
                this.Hide();
                AdministratorMainScreen administratorMainScreen = new AdministratorMainScreen();
                administratorMainScreen.Show();
            }
        }

        private void validationSize(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Value = ((NumericUpDown)sender).Value;
        }

        private void shutDownApplication(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
