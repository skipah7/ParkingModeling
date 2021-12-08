namespace ParkingApp
{
    partial class ManagerMainScreen
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
            this.backToMainScreenBtn = new System.Windows.Forms.Button();
            this.startModelingBtn = new System.Windows.Forms.Button();
            this.configureModellingParamsBtn = new System.Windows.Forms.Button();
            this.loadparkingBtn = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.aboutSystemButton = new System.Windows.Forms.Button();
            this.aboutDevelopersButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backToMainScreenBtn
            // 
            this.backToMainScreenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToMainScreenBtn.Location = new System.Drawing.Point(63, 280);
            this.backToMainScreenBtn.Margin = new System.Windows.Forms.Padding(2);
            this.backToMainScreenBtn.Name = "backToMainScreenBtn";
            this.backToMainScreenBtn.Size = new System.Drawing.Size(128, 30);
            this.backToMainScreenBtn.TabIndex = 20;
            this.backToMainScreenBtn.Text = "Выйти";
            this.backToMainScreenBtn.UseVisualStyleBackColor = true;
            this.backToMainScreenBtn.Click += new System.EventHandler(this.backToMainScreenBtn_Click);
            // 
            // startModelingBtn
            // 
            this.startModelingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startModelingBtn.Location = new System.Drawing.Point(34, 28);
            this.startModelingBtn.Name = "startModelingBtn";
            this.startModelingBtn.Size = new System.Drawing.Size(193, 40);
            this.startModelingBtn.TabIndex = 21;
            this.startModelingBtn.Text = "Запустить моделирование";
            this.startModelingBtn.UseVisualStyleBackColor = true;
            this.startModelingBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // configureModellingParamsBtn
            // 
            this.configureModellingParamsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.configureModellingParamsBtn.Location = new System.Drawing.Point(34, 74);
            this.configureModellingParamsBtn.Name = "configureModellingParamsBtn";
            this.configureModellingParamsBtn.Size = new System.Drawing.Size(193, 40);
            this.configureModellingParamsBtn.TabIndex = 22;
            this.configureModellingParamsBtn.Text = "Настроить параметры моделирования";
            this.configureModellingParamsBtn.UseVisualStyleBackColor = true;
            this.configureModellingParamsBtn.Click += new System.EventHandler(this.configureModellingParamsBtn_Click);
            // 
            // loadparkingBtn
            // 
            this.loadparkingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadparkingBtn.Location = new System.Drawing.Point(34, 120);
            this.loadparkingBtn.Name = "loadparkingBtn";
            this.loadparkingBtn.Size = new System.Drawing.Size(193, 40);
            this.loadparkingBtn.TabIndex = 23;
            this.loadparkingBtn.Text = "Загрузить топологию";
            this.loadparkingBtn.UseVisualStyleBackColor = true;
            this.loadparkingBtn.Click += new System.EventHandler(this.loadparkingBtn_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.loginLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.loginLabel.Location = new System.Drawing.Point(183, 9);
            this.loginLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(62, 16);
            this.loginLabel.TabIndex = 24;
            this.loginLabel.Text = "Manager";
            // 
            // aboutSystemButton
            // 
            this.aboutSystemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutSystemButton.Location = new System.Drawing.Point(34, 209);
            this.aboutSystemButton.Margin = new System.Windows.Forms.Padding(2);
            this.aboutSystemButton.Name = "aboutSystemButton";
            this.aboutSystemButton.Size = new System.Drawing.Size(193, 40);
            this.aboutSystemButton.TabIndex = 26;
            this.aboutSystemButton.Text = "О системе";
            this.aboutSystemButton.UseVisualStyleBackColor = true;
            // 
            // aboutDevelopersButton
            // 
            this.aboutDevelopersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutDevelopersButton.Location = new System.Drawing.Point(34, 165);
            this.aboutDevelopersButton.Margin = new System.Windows.Forms.Padding(2);
            this.aboutDevelopersButton.Name = "aboutDevelopersButton";
            this.aboutDevelopersButton.Size = new System.Drawing.Size(193, 40);
            this.aboutDevelopersButton.TabIndex = 25;
            this.aboutDevelopersButton.Text = "О разработчиках";
            this.aboutDevelopersButton.UseVisualStyleBackColor = true;
            this.aboutDevelopersButton.Click += new System.EventHandler(this.aboutDevelopersButton_Click);
            // 
            // ManagerMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(256, 321);
            this.Controls.Add(this.aboutSystemButton);
            this.Controls.Add(this.aboutDevelopersButton);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.loadparkingBtn);
            this.Controls.Add(this.configureModellingParamsBtn);
            this.Controls.Add(this.startModelingBtn);
            this.Controls.Add(this.backToMainScreenBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagerMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.shutDownApplication);
            this.Resize += new System.EventHandler(this.preventResize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backToMainScreenBtn;
        private System.Windows.Forms.Button startModelingBtn;
        private System.Windows.Forms.Button configureModellingParamsBtn;
        private System.Windows.Forms.Button loadparkingBtn;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Button aboutSystemButton;
        private System.Windows.Forms.Button aboutDevelopersButton;
    }
}