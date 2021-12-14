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
                Globals.patterns = new string[Globals.HEIGHT, Globals.WIDTH];
                Globals.highwayPatterns = new string[Globals.HEIGHT + 1, Globals.WIDTH];
                parkingFieldClass.createField(modelPanel);            
            }
            else
            {
                parkingFieldClass.fillPictureBoxesList();
                parkingFieldClass.loadField(modelPanel);
            }

            foreach (var control in modelPanel.Controls)
            {
                ((PictureBox)control).DragEnter += dragValidation;
            }
            RoadsClass.createRoads(modelPanel);
        }             

        private void dragValidation(object sender, DragEventArgs e)
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

        private bool isCorrectField()
        {
            VerifyParkingClass verifyParking = new VerifyParkingClass();
            if (verifyParking.isCorrectNumberOfTerminals() && verifyParking.isTerminalsAtTheBorder())
            {
                return true;
            }
            MessageBox.Show("Убедитесь в правильности заполнения пространства парковки", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }                             

        private void saveToFile_Click(object sender, EventArgs e)
        {
            parkingFieldClass.fillPatternsArray();
            if (isCorrectField())
            {
                SaveForm saveForm = new SaveForm();
                saveForm.Show();
            }
        }

        private void refreshParking_Click(object sender, EventArgs e)
        {
            Globals.isNewParking = true;
            Globals.tariff = null;
            Globals.pictureBoxes = null;
            Globals.patterns = null;

            int width = (int)widthBox.Value;
            int height = (int)heightBox.Value;

            Globals.HEIGHT = height;
            Globals.WIDTH = width;

            Globals.downAdjacentRoadLength = height + 1;
            Globals.leftAdjacentRoadLength = width + 1;
            Globals.rightAdjacentRoadLength = 0;
            Globals.upAdjacentRoadLength = 0;

            this.Hide();
            ParkingSpaceForm parkingSpaceForm = new ParkingSpaceForm();
            parkingSpaceForm.Show();
        }

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
            if (((PictureBox)sender).Name.Equals("heavyParkingPlace"))
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
            if (((PictureBox)sender).Name.Equals("empty"))
            {
                t.SetToolTip((PictureBox)sender, "Пустое место");
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
