using ParkingApp.Classes;
using System;
using System.Windows.Forms;
using ParkingApp.Screens;

namespace ParkingApp
{
    public partial class AdministratorMainScreen : Form
    {
        public AdministratorMainScreen()
        {
            InitializeComponent();
        }

        private void createModelButton_Click(object sender, EventArgs e)
        {
            Globals.isNewParking = false;

            Globals.WIDTH = 5;
            Globals.HEIGHT = 5;
            Globals.patterns = new DefaultParkings().getDefault_5_5();
            Globals.highwayPatterns = new string[Globals.HEIGHT + 1, Globals.WIDTH];

            this.Hide();
            ParkingSpaceForm parkingSpaceForm = new ParkingSpaceForm();
            parkingSpaceForm.Show();
        }

        private void loadModelButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Parking files(*.parking) | *.parking";
            openFileDialog1.InitialDirectory = Globals.directory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Globals.IS_CORRECT_PARKING = false;
                Globals.parkingFilePath = openFileDialog1.FileName;
                ParkingField parkingField = loadParkingFromFile();
                if (parkingField != null)
                {
                    Globals.patterns = parkingField.getPatterns();
                    Globals.tariff = parkingField.getTariff();
                    Globals.WIDTH = parkingField.getWidth();
                    Globals.HEIGHT = parkingField.getHeight();
                    Globals.isNewParking = false;
                    Globals.leftAdjacentRoadLength = parkingField.getLeftRoadLength();
                    Globals.rightAdjacentRoadLength = parkingField.getRigthRoadLength();
                    Globals.upAdjacentRoadLength = parkingField.getUpRoadLength();
                    Globals.downAdjacentRoadLength = parkingField.getDownRoadLength();
                    Globals.IS_CORRECT_PARKING = true;

                    MessageBox.Show("Парковка загружена", "Статус загрузки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка. Вероятно, файл был поврежден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Show();
        }

        // load parking from file
        private ParkingField loadParkingFromFile()
        {
            FileWorkerWithParkingField fileWorker = new FileWorkerWithParkingField();
            if (fileWorker.readParkingField() != null)
            {
                return fileWorker.readParkingField();
            }
            else return null;
        }

        #region helpers
        private void backToMainScreenBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainScreenForm = new MainMenu();
            mainScreenForm.Show();
        }

        private void shutDownApplication(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void aboutDevelopersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutDevelopers aboutDevelopersForm = new AboutDevelopers("admin");
            aboutDevelopersForm.Show();
        }
        #endregion
    }
}
