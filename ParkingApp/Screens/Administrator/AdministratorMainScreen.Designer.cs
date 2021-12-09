namespace ParkingApp
{
    partial class AdministratorMainScreen
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
            this.createBtn = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.backToMainScreenBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.aboutSystemButton = new System.Windows.Forms.Button();
            this.aboutDevelopersButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createBtn
            // 
            this.createBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createBtn.Location = new System.Drawing.Point(35, 28);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(193, 40);
            this.createBtn.TabIndex = 0;
            this.createBtn.Text = "Создать модель";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton.Location = new System.Drawing.Point(35, 74);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(193, 40);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Загрузить/редактировать";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // backToMainScreenBtn
            // 
            this.backToMainScreenBtn.Location = new System.Drawing.Point(63, 280);
            this.backToMainScreenBtn.Margin = new System.Windows.Forms.Padding(2);
            this.backToMainScreenBtn.Name = "backToMainScreenBtn";
            this.backToMainScreenBtn.Size = new System.Drawing.Size(128, 30);
            this.backToMainScreenBtn.TabIndex = 19;
            this.backToMainScreenBtn.Text = "Выйти";
            this.backToMainScreenBtn.UseVisualStyleBackColor = true;
            this.backToMainScreenBtn.Click += new System.EventHandler(this.backToMainScreenBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(199, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Admin";
            // 
            // aboutSystemButton
            // 
            this.aboutSystemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutSystemButton.Location = new System.Drawing.Point(35, 163);
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
            this.aboutDevelopersButton.Location = new System.Drawing.Point(35, 119);
            this.aboutDevelopersButton.Margin = new System.Windows.Forms.Padding(2);
            this.aboutDevelopersButton.Name = "aboutDevelopersButton";
            this.aboutDevelopersButton.Size = new System.Drawing.Size(193, 40);
            this.aboutDevelopersButton.TabIndex = 25;
            this.aboutDevelopersButton.Text = "О разработчиках";
            this.aboutDevelopersButton.UseVisualStyleBackColor = true;
            this.aboutDevelopersButton.Click += new System.EventHandler(this.aboutDevelopersButton_Click);
            // 
            // AdministratorMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(256, 321);
            this.Controls.Add(this.aboutSystemButton);
            this.Controls.Add(this.aboutDevelopersButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backToMainScreenBtn);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.createBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdministratorMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.shutDownApplication);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button backToMainScreenBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button aboutSystemButton;
        private System.Windows.Forms.Button aboutDevelopersButton;
    }
}