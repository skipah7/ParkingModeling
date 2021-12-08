namespace ParkingApp
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.administratorBtn = new System.Windows.Forms.Button();
            this.managerBtn = new System.Windows.Forms.Button();
            this.aboutDevelopersButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.aboutSystemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // administratorBtn
            // 
            this.administratorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.administratorBtn.Location = new System.Drawing.Point(50, 28);
            this.administratorBtn.Margin = new System.Windows.Forms.Padding(2);
            this.administratorBtn.Name = "administratorBtn";
            this.administratorBtn.Size = new System.Drawing.Size(156, 31);
            this.administratorBtn.TabIndex = 2;
            this.administratorBtn.Text = "Администратор";
            this.administratorBtn.UseVisualStyleBackColor = true;
            this.administratorBtn.Click += new System.EventHandler(this.administratorBtn_Click);
            // 
            // managerBtn
            // 
            this.managerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.managerBtn.Location = new System.Drawing.Point(50, 63);
            this.managerBtn.Margin = new System.Windows.Forms.Padding(2);
            this.managerBtn.Name = "managerBtn";
            this.managerBtn.Size = new System.Drawing.Size(156, 31);
            this.managerBtn.TabIndex = 3;
            this.managerBtn.Text = "Менеджер";
            this.managerBtn.UseVisualStyleBackColor = true;
            this.managerBtn.Click += new System.EventHandler(this.managerBtn_Click);
            // 
            // aboutDevelopersButton
            // 
            this.aboutDevelopersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutDevelopersButton.Location = new System.Drawing.Point(50, 98);
            this.aboutDevelopersButton.Margin = new System.Windows.Forms.Padding(2);
            this.aboutDevelopersButton.Name = "aboutDevelopersButton";
            this.aboutDevelopersButton.Size = new System.Drawing.Size(156, 31);
            this.aboutDevelopersButton.TabIndex = 4;
            this.aboutDevelopersButton.Text = "О разработчиках";
            this.aboutDevelopersButton.UseVisualStyleBackColor = true;
            this.aboutDevelopersButton.Click += new System.EventHandler(this.aboutDevelopersButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(80, 195);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(96, 31);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Выйти";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // aboutSystemButton
            // 
            this.aboutSystemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutSystemButton.Location = new System.Drawing.Point(50, 133);
            this.aboutSystemButton.Margin = new System.Windows.Forms.Padding(2);
            this.aboutSystemButton.Name = "aboutSystemButton";
            this.aboutSystemButton.Size = new System.Drawing.Size(156, 31);
            this.aboutSystemButton.TabIndex = 6;
            this.aboutSystemButton.Text = "О системе";
            this.aboutSystemButton.UseVisualStyleBackColor = true;
            this.aboutSystemButton.Click += new System.EventHandler(this.aboutSystemButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(257, 237);
            this.Controls.Add(this.aboutSystemButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.aboutDevelopersButton);
            this.Controls.Add(this.managerBtn);
            this.Controls.Add(this.administratorBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.shutDownApplication);
            this.Resize += new System.EventHandler(this.preventResize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button administratorBtn;
        private System.Windows.Forms.Button managerBtn;
        private System.Windows.Forms.Button aboutDevelopersButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button aboutSystemButton;
    }
}

