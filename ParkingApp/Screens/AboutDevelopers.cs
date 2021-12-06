using System;
using System.Windows.Forms;

namespace ParkingApp.Screens
{
    public partial class AboutDevelopers : Form
    {
        public AboutDevelopers()
        {
            InitializeComponent();
        }

        private void preventResize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void backToMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainScreenForm = new MainMenu();
            mainScreenForm.Show();
        }
    }
}
