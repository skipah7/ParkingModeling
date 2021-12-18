using ParkingApp.Classes;
using System;
using System.Windows.Forms;

namespace ParkingApp.Screens.Administrator
{
    public partial class SaveForm : Form
    {
        FileWorkerWithParkingField fileWorker;
        int width;
        int height;
        string[,] patterns;

        public SaveForm(int width, int height, string[,] patterns)
        {
            InitializeComponent();

            this.width = width;
            this.height = height;
            this.patterns = patterns;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (parkingFilePathTextBox.Text.Equals(""))
            {
                return;
            }

            Globals.parkingFileName = parkingFilePathTextBox.Text;
            ParkingField parkingField = new ParkingField(
                this.width, 
                this.height, 
                this.patterns
            );
            fileWorker = new FileWorkerWithParkingField(parkingField, Globals.parkingFileName);
            fileWorker.writeParkingField();

            MessageBox.Show("Файл успешно сохранен по пути: " + Globals.parkingFilePath, "Успешное сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        #region helpers

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void backToParkingSpaceForm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void shutDownApplication(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        #endregion
    }
}
