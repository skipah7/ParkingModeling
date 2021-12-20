using System;
using System.Windows.Forms;

namespace ParkingApp
{
    public partial class SignInForm : Form
    {
        public SignInForm(string currentUserType)
        {
            InitializeComponent();

            if (currentUserType == Globals.ADMINISTRATOR)
            {
                loginTextBox.Text = "admin";
                passwordTextBox.Text = "admin";
                this.registrationPanel.Visible = false;
            }
            if (currentUserType == Globals.MANAGER)
            {
                loginTextBox.Text = "manager";
                passwordTextBox.Text = "manager";
            }
            if (currentUserType == "new")
            {
                loginTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }

        private void validation(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
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

        private void signInButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signInForm = new SignIn();
            signInForm.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;
            UserValidator userValidator = new UserValidator();

            if (userValidator.isExisted(login, password) == Globals.ADMINISTRATOR)
            {
                this.Hide();
                AdministratorMainScreen administratorMainScreen = new AdministratorMainScreen();
                administratorMainScreen.Show();
            } else if (userValidator.isExisted(login, password) == Globals.MANAGER)
            {
                this.Hide();
                ManagerMainScreen managerMainScreen = new ManagerMainScreen();
                managerMainScreen.Show();
            } else
            {
                MessageBox.Show("Такого пользователя не существует", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainScreenForm = new MainMenu();
            mainScreenForm.Show();
        }
    }
}
