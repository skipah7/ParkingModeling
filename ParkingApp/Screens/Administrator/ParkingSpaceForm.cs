using ParkingApp.Classes;
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

            Globals.calculatePictureBoxSize();

            parkingFieldClass = new ParkingFieldClass();

            panel1.Location = new Point(0, 0);
            heightTextBox.Text = Globals.HEIGHT.ToString();
            widthTextBox.Text = Globals.WIDTH.ToString();

            if (Globals.isNewParking)
            {
                Globals.pictureBoxes = new List<PictureBox>();
                Globals.patterns = new string[Globals.HEIGHT, Globals.WIDTH];
                Globals.highwayPatterns = new string[Globals.HEIGHT + 1, Globals.WIDTH];
                parkingFieldClass.createField(panel1, Globals.WIDTH, Globals.HEIGHT);              
            }
            else
            {
                parkingFieldClass.fillPictureBoxesList();
                parkingFieldClass.loadField(panel1);
            }
            new RoadsClass().createRoads(panel1);
        }             

        private bool isCorrectField()
        {
            VerifyParkingClass verifyParking = new VerifyParkingClass();
            if (verifyParking.isCorrectNumberOfTerminals() && verifyParking.isTerminalsAtTheBorder())
            {
                System.Windows.Forms.MessageBox.Show("Парковка заполнена корректно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            System.Windows.Forms.MessageBox.Show("Убедитесь в правильности заполнения пространства парковки", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }                             

        private void saveBtn_Click(object sender, EventArgs e)
        {
            parkingFieldClass.fillPatternsArray();

            if (isCorrectField())
            {
                Globals.isNewParking = false;

            }
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

        private void createNewParkingBtn_Click(object sender, EventArgs e)
        {
            Globals.isNewParking = true;
            Globals.tariff = null;
            Globals.pictureBoxes = null;
            Globals.patterns = null;
            Globals.rightAdjacentRoadLength = 0;
            Globals.leftAdjacentRoadLength = 0;
            Globals.upAdjacentRoadLength = 0;
            Globals.downAdjacentRoadLength = 0;

            if (isCorrectValues())
            {
                this.Hide();
                ParkingSpaceForm parkingSpaceForm = new ParkingSpaceForm();
                parkingSpaceForm.Show();
            }
        }

        private bool isCorrectValues()
        {
            int width = int.Parse(widthTextBox.Text);
            int height = int.Parse(heightTextBox.Text);
            if (width >= Globals.MIN_SIZE && width <= Globals.MAX_SIZE && height >= Globals.MIN_SIZE && height <= Globals.MAX_SIZE)
            {
                Globals.HEIGHT = height;
                Globals.WIDTH = width;
                Globals.downAdjacentRoadLength = height + 1;
                Globals.leftAdjacentRoadLength = width + 1;
                return true;
            }
            else
            {
                MessageBox.Show("Минимальное значение 5, максимальное 10", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.MessageBoxResult confirmResult = System.Windows.MessageBox.Show("Вы уверены? Несохраненные изменения будут потеряны!", "Подтвердить действие", System.Windows.MessageBoxButton.YesNo);

            if (confirmResult == System.Windows.MessageBoxResult.Yes)
            {
                this.Hide();
                AdministratorMainScreen administratorMainScreen = new AdministratorMainScreen();
                administratorMainScreen.Show();
            }
        }

        private void mouseDownEntrancePic(object sender, MouseEventArgs e)
        {
            entrancePic.DoDragDrop(entrancePic.Image, DragDropEffects.Copy);
        }

        private void mouseDownExitPic(object sender, MouseEventArgs e)
        {
            exitPic.DoDragDrop(exitPic.Image, DragDropEffects.Copy);
        }

        private void dollarDown(object sender, MouseEventArgs e)
        {
            dollarPic.DoDragDrop(dollarPic.Image, DragDropEffects.Copy);
        }

        private void mouseDownCar(object sender, MouseEventArgs e)
        {
            parkingPlacePicBox.DoDragDrop(parkingPlacePicBox.Image, DragDropEffects.Copy);
        }

        private void mouseDownRoad(object sender, MouseEventArgs e)
        {
            roadPic.DoDragDrop(roadPic.Image, DragDropEffects.Copy);
        }

        private void mouseDownTree(object sender, MouseEventArgs e)
        {
            treePic.DoDragDrop(treePic.Image, DragDropEffects.Copy);
        }

        private void mouseDownGrass(object sender, MouseEventArgs e)
        {
            grassPic.DoDragDrop(grassPic.Image, DragDropEffects.Copy);
        }

        private void mouseEnterPatternsPicBox(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            if (((PictureBox)sender).Name.Equals("parkingPlacePicBox"))
            {
                t.SetToolTip((PictureBox)sender, "Парковочное место");
            }
            else if (((PictureBox)sender).Name.Equals("roadPic"))
            {
                t.SetToolTip((PictureBox)sender, "Дорога");
            }
            else if (((PictureBox)sender).Name.Equals("entrancePic"))
            {
                t.SetToolTip((PictureBox)sender, "Въезд");
            }
            else if (((PictureBox)sender).Name.Equals("dollarPic"))
            {
                t.SetToolTip((PictureBox)sender, "Касса");
            }
            else if (((PictureBox)sender).Name.Equals("exitPic"))
            {
                t.SetToolTip((PictureBox)sender, "Выезд");
            }
            else if (((PictureBox)sender).Name.Equals("treePic"))
            {
                t.SetToolTip((PictureBox)sender, "Дерево");
            }
            else 
            {
                t.SetToolTip((PictureBox)sender, "Трава");
            }
        }

        #region helpers
        private void validation(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void preventResize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void shutDownApplication(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
