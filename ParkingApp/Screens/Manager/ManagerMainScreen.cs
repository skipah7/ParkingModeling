using ParkingApp.Classes;
using ParkingApp.Screens.Manager;
using System;
using System.Windows.Forms;
using ParkingApp.Screens;
using ParkingApp.Classes.BaseParkingClasses;

namespace ParkingApp
{
    public partial class ManagerMainScreen : Form
    {
        ModelingParams modelingParams;

        bool isParkingCorrect = false;

        int width;
        int height;
        string[,] patterns;
        public ManagerMainScreen()
        {
            InitializeComponent();          
            recheckLaunchingButton();
        }

        private void loadParking()
        {            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Parking files(*.parking) | *.parking";
            openFileDialog1.InitialDirectory = Globals.directory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;

            this.isParkingCorrect = false;
            Globals.parkingFilePath = openFileDialog1.FileName;
            ParkingField parkingField = loadParkingFromFile();
            if (parkingField != null)
            {
                this.patterns = parkingField.getPatterns();
                this.width = parkingField.getWidth();
                this.height = parkingField.getHeight();

                // hope we can get over it x2
                //Globals.tariff = parkingField.getTariff();
                //Globals.leftAdjacentRoadLength = parkingField.getLeftRoadLength();
                //Globals.rightAdjacentRoadLength = parkingField.getRigthRoadLength();
                //Globals.upAdjacentRoadLength = parkingField.getUpRoadLength();
                //Globals.downAdjacentRoadLength = parkingField.getDownRoadLength();

                this.isParkingCorrect = true;
                MessageBox.Show("Парковка загружена", "Статус загрузки", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка. Вероятно, файл поврежден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            recheckLaunchingButton();
            this.Show();
        }

        private ParkingField loadParkingFromFile()
        {
            FileWorkerWithParkingField fileWorker = new FileWorkerWithParkingField();
            if (fileWorker.readParkingField() != null)
            {
                return fileWorker.readParkingField();
            }
            else return null;
        }

        private void recheckLaunchingButton()
        {
            startModelingBtn.Enabled = this.isParkingCorrect && (this.modelingParams != null);
        }
        private void recheckLaunchingButton(object sender, EventArgs e)
        {
            this.modelingParams = (sender as ConfigureModelingParamsForm).modelingParams;
            this.recheckLaunchingButton();
        }

        #region button handlers

        private void launchModelling(object sender, EventArgs e)
        {
            ModelingSpaceForm modelingSpaceForm = new ModelingSpaceForm(this.height, this.width, this.patterns, this.modelingParams);
            modelingSpaceForm.Show();
            this.Hide();
        }

        private void configureModellingParamsBtn_Click(object sender, EventArgs e)
        {
            ConfigureModelingParamsForm paramsForm = new ConfigureModelingParamsForm();
            paramsForm.Closed += recheckLaunchingButton;
            paramsForm.Show();
        }

        private void loadTopologyClick(object sender, EventArgs e)
        {
            loadParking();
        }

        private void aboutDevelopersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutDevelopers aboutDevelopersForm = new AboutDevelopers("manager");
            aboutDevelopersForm.Show();
        }


        private void aboutSystemClick(object sender, EventArgs e)
        {

        }

        private void backToMainScreenBtn_Click(object sender, EventArgs e)
        {
            MainMenu mainScreenForm = new MainMenu();
            mainScreenForm.Show();
            this.Hide();
        }

        private void shutDownApplication(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
