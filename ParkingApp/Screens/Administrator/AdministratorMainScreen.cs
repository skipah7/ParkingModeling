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
            this.Hide();
            ParkingSpaceForm parkingSpaceForm = new ParkingSpaceForm(5, 5, new DefaultParkings().getDefault_5_5());
            parkingSpaceForm.Show();
        }

        private void loadModelButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Parking files(*.parking) | *.parking";
            openFileDialog1.InitialDirectory = Globals.directory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            Globals.parkingFilePath = openFileDialog1.FileName;
            ParkingField parkingField = loadParkingFromFile();
            if (parkingField != null)
            {
                int width = parkingField.getWidth();
                int height = parkingField.getHeight();
                string[,] patterns = parkingField.getPatterns();

                this.Hide();
                ParkingSpaceForm parkingSpaceForm = new ParkingSpaceForm(width, height, patterns);
                parkingSpaceForm.Show();
            }
            else
            {
                MessageBox.Show("Ошибка. Вероятно, файл был поврежден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
