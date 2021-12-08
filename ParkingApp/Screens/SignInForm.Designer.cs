namespace ParkingApp
{
    partial class SignInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInForm));
            this.backToMainMenuButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.signInLabel = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // backToMainMenuButton
            // 
            resources.ApplyResources(this.backToMainMenuButton, "backToMainMenuButton");
            this.backToMainMenuButton.Name = "backToMainMenuButton";
            this.backToMainMenuButton.UseVisualStyleBackColor = true;
            this.backToMainMenuButton.Click += new System.EventHandler(this.backToMainMenuButton_Click);
            // 
            // loginButton
            // 
            resources.ApplyResources(this.loginButton, "loginButton");
            this.loginButton.Name = "loginButton";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // signInLabel
            // 
            resources.ApplyResources(this.signInLabel, "signInLabel");
            this.signInLabel.Name = "signInLabel";
            // 
            // signInButton
            // 
            resources.ApplyResources(this.signInButton, "signInButton");
            this.signInButton.Name = "signInButton";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // loginLabel
            // 
            resources.ApplyResources(this.loginLabel, "loginLabel");
            this.loginLabel.Name = "loginLabel";
            // 
            // passwordTextBox
            // 
            resources.ApplyResources(this.passwordTextBox, "passwordTextBox");
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validation);
            // 
            // loginTextBox
            // 
            resources.ApplyResources(this.loginTextBox, "loginTextBox");
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validation);
            // 
            // SignInForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.backToMainMenuButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.signInLabel);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignInForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.shutDownApplication);
            this.Resize += new System.EventHandler(this.preventResize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button backToMainMenuButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label signInLabel;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
    }
}