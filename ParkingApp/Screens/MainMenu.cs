using System;
using System.Windows.Forms;
using ParkingApp.Screens;

namespace ParkingApp
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void aboutDevelopersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutDevelopers aboutDevelopersForm = new AboutDevelopers();
            aboutDevelopersForm.Show();
        }

        private void administratorBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignInForm signInForm = new SignInForm(Globals.ADMINISTRATOR);
            signInForm.Show();
        }

        private void managerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignInForm signInForm = new SignInForm(Globals.MANAGER);
            signInForm.Show();
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

        private void aboutSystemButton_Click(object sender, EventArgs e)
        {
            //string pathToHtmlFile = Globals.directory + '\\' + "aboutParking" + '.' + "html";
            //System.Diagnostics.Process.Start(pathToHtmlFile);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
