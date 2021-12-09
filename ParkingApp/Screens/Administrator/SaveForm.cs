using ParkingApp.Classes;
using System;
using System.Windows.Forms;

namespace ParkingApp.Screens.Administrator
{
    public partial class SaveForm : Form
    {
        FileWorkerWithParkingField fileWorker;
        public SaveForm()
        {
            InitializeComponent();
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!parkingFilePathTextBox.Text.Equals(""))
            {
                Globals.parkingFileName = parkingFilePathTextBox.Text;
                fileWorker = new FileWorkerWithParkingField(new ParkingField(Globals.WIDTH, Globals.HEIGHT, Globals.patterns, Globals.tariff, Globals.leftAdjacentRoadLength, Globals.rightAdjacentRoadLength, Globals.upAdjacentRoadLength, Globals.downAdjacentRoadLength), Globals.parkingFileName);
                fileWorker.writeParkingField();
                MessageBox.Show("Файл успешно сохранен по пути: " + Globals.parkingFilePath, "Успешное сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
        }

        private void backToParkingSpaceForm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void shutDownApplication(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
