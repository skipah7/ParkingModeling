using ParkingApp.Classes;
using ParkingApp.Screens.Manager;
using System;
using System.Windows.Forms;
using ParkingApp.Screens;
using ParkingApp.Classes.BaseParkingClasses;
using System.IO;

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
            var fileWorker = new FileWorkerWithParkingField();
            if (fileWorker.readParkingField() == null) return null;
            return fileWorker.readParkingField();
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
            string pathToHtmlFile = Globals.directory + '\\' + "help" + '.' + "html";
            if (File.Exists(pathToHtmlFile))
            {
                System.Diagnostics.Process.Start(pathToHtmlFile);
                return;
            }
            MessageBox.Show("Отсутствует файл справки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
