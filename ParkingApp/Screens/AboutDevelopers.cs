using System;
using System.Windows.Forms;

namespace ParkingApp.Screens
{
    public partial class AboutDevelopers : Form
    {
        string origin;
        public AboutDevelopers(string origin)
        {
            InitializeComponent();
            this.origin = origin;
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
            if (origin == "admin")
            {
                AdministratorMainScreen adminScreen = new AdministratorMainScreen();
                adminScreen.Show();
            }
            if (origin == "manager")
            {
                ManagerMainScreen managerScreen = new ManagerMainScreen();
                managerScreen.Show();
            }
            if (origin == "main")
            {
                MainMenu mainScreenForm = new MainMenu();
                mainScreenForm.Show();
            }
        }
    }
}
