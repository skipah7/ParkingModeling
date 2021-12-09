namespace ParkingApp
{
    partial class ParkingSpaceForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.empty = new System.Windows.Forms.PictureBox();
            this.entrance = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.PictureBox();
            this.heavyParkingPlace = new System.Windows.Forms.PictureBox();
            this.lightParkingPlace = new System.Windows.Forms.PictureBox();
            this.tree = new System.Windows.Forms.PictureBox();
            this.road = new System.Windows.Forms.PictureBox();
            this.saveToFile = new System.Windows.Forms.Button();
            this.refreshParking = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.leftAdjacentRoad = new System.Windows.Forms.Panel();
            this.rightAdjacentRoad = new System.Windows.Forms.Panel();
            this.upAdjacentRoad = new System.Windows.Forms.Panel();
            this.downAdjacentRoad = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.heightBox = new System.Windows.Forms.NumericUpDown();
            this.widthBox = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.empty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entrance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heavyParkingPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightParkingPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.road)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Location = new System.Drawing.Point(762, 387);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 11;
            // 
            // empty
            // 
            this.empty.Location = new System.Drawing.Point(153, 74);
            this.empty.Name = "empty";
            this.empty.Size = new System.Drawing.Size(69, 65);
            this.empty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.empty.TabIndex = 9;
            this.empty.TabStop = false;
            this.empty.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownGrass);
            this.empty.MouseEnter += new System.EventHandler(this.mouseEnterPatternsPicBox);
            // 
            // entrance
            // 
            this.entrance.Image = global::ParkingApp.Properties.Resources.entrance;
            this.entrance.Location = new System.Drawing.Point(3, 3);
            this.entrance.Name = "entrance";
            this.entrance.Size = new System.Drawing.Size(69, 65);
            this.entrance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.entrance.TabIndex = 1;
            this.entrance.TabStop = false;
            this.entrance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownEntrancePic);
            this.entrance.MouseEnter += new System.EventHandler(this.mouseEnterPatternsPicBox);
            // 
            // exit
            // 
            this.exit.Image = global::ParkingApp.Properties.Resources.exit;
            this.exit.Location = new System.Drawing.Point(3, 74);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(69, 65);
            this.exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit.TabIndex = 2;
            this.exit.TabStop = false;
            this.exit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownExitPic);
            this.exit.MouseEnter += new System.EventHandler(this.mouseEnterPatternsPicBox);
            // 
            // heavyParkingPlace
            // 
            this.heavyParkingPlace.Image = global::ParkingApp.Properties.Resources.parkingCar6Pic;
            this.heavyParkingPlace.Location = new System.Drawing.Point(78, 74);
            this.heavyParkingPlace.Name = "heavyParkingPlace";
            this.heavyParkingPlace.Size = new System.Drawing.Size(69, 65);
            this.heavyParkingPlace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.heavyParkingPlace.TabIndex = 5;
            this.heavyParkingPlace.TabStop = false;
            this.heavyParkingPlace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dollarDown);
            this.heavyParkingPlace.MouseEnter += new System.EventHandler(this.mouseEnterPatternsPicBox);
            // 
            // lightParkingPlace
            // 
            this.lightParkingPlace.Image = global::ParkingApp.Properties.Resources.parkingPlace;
            this.lightParkingPlace.Location = new System.Drawing.Point(78, 3);
            this.lightParkingPlace.Name = "lightParkingPlace";
            this.lightParkingPlace.Size = new System.Drawing.Size(69, 65);
            this.lightParkingPlace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lightParkingPlace.TabIndex = 7;
            this.lightParkingPlace.TabStop = false;
            this.lightParkingPlace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownCar);
            this.lightParkingPlace.MouseEnter += new System.EventHandler(this.mouseEnterPatternsPicBox);
            // 
            // tree
            // 
            this.tree.Image = global::ParkingApp.Properties.Resources.tree;
            this.tree.Location = new System.Drawing.Point(153, 3);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(69, 65);
            this.tree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tree.TabIndex = 4;
            this.tree.TabStop = false;
            this.tree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownTree);
            this.tree.MouseEnter += new System.EventHandler(this.mouseEnterPatternsPicBox);
            // 
            // road
            // 
            this.road.Image = global::ParkingApp.Properties.Resources.road;
            this.road.Location = new System.Drawing.Point(228, 3);
            this.road.Name = "road";
            this.road.Size = new System.Drawing.Size(69, 65);
            this.road.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.road.TabIndex = 6;
            this.road.TabStop = false;
            this.road.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownRoad);
            this.road.MouseEnter += new System.EventHandler(this.mouseEnterPatternsPicBox);
            // 
            // saveToFile
            // 
            this.saveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveToFile.Location = new System.Drawing.Point(723, 506);
            this.saveToFile.Name = "saveToFile";
            this.saveToFile.Size = new System.Drawing.Size(89, 30);
            this.saveToFile.TabIndex = 13;
            this.saveToFile.Text = "Сохранить";
            this.saveToFile.UseVisualStyleBackColor = true;
            this.saveToFile.Click += new System.EventHandler(this.saveToFile_Click);
            // 
            // refreshParking
            // 
            this.refreshParking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshParking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refreshParking.Location = new System.Drawing.Point(628, 506);
            this.refreshParking.Name = "refreshParking";
            this.refreshParking.Size = new System.Drawing.Size(89, 30);
            this.refreshParking.TabIndex = 14;
            this.refreshParking.Text = "Обновить";
            this.refreshParking.UseVisualStyleBackColor = true;
            this.refreshParking.Click += new System.EventHandler(this.refreshParking_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 0);
            this.panel3.TabIndex = 16;
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(533, 506);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(89, 30);
            this.backButton.TabIndex = 15;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // leftAdjacentRoad
            // 
            this.leftAdjacentRoad.AutoSize = true;
            this.leftAdjacentRoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.leftAdjacentRoad.Location = new System.Drawing.Point(375, 254);
            this.leftAdjacentRoad.Margin = new System.Windows.Forms.Padding(0);
            this.leftAdjacentRoad.Name = "leftAdjacentRoad";
            this.leftAdjacentRoad.Size = new System.Drawing.Size(0, 0);
            this.leftAdjacentRoad.TabIndex = 18;
            // 
            // rightAdjacentRoad
            // 
            this.rightAdjacentRoad.AutoSize = true;
            this.rightAdjacentRoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rightAdjacentRoad.Location = new System.Drawing.Point(338, 282);
            this.rightAdjacentRoad.Margin = new System.Windows.Forms.Padding(0);
            this.rightAdjacentRoad.Name = "rightAdjacentRoad";
            this.rightAdjacentRoad.Size = new System.Drawing.Size(0, 0);
            this.rightAdjacentRoad.TabIndex = 19;
            // 
            // upAdjacentRoad
            // 
            this.upAdjacentRoad.AutoSize = true;
            this.upAdjacentRoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.upAdjacentRoad.Location = new System.Drawing.Point(0, 0);
            this.upAdjacentRoad.Margin = new System.Windows.Forms.Padding(0);
            this.upAdjacentRoad.Name = "upAdjacentRoad";
            this.upAdjacentRoad.Size = new System.Drawing.Size(0, 0);
            this.upAdjacentRoad.TabIndex = 20;
            // 
            // downAdjacentRoad
            // 
            this.downAdjacentRoad.AutoSize = true;
            this.downAdjacentRoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.downAdjacentRoad.Location = new System.Drawing.Point(-23, -46);
            this.downAdjacentRoad.Margin = new System.Windows.Forms.Padding(0);
            this.downAdjacentRoad.Name = "downAdjacentRoad";
            this.downAdjacentRoad.Size = new System.Drawing.Size(0, 0);
            this.downAdjacentRoad.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(533, 475);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ширина";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(533, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Высота";
            // 
            // heightBox
            // 
            this.heightBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.heightBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heightBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.heightBox.Location = new System.Drawing.Point(595, 448);
            this.heightBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(37, 22);
            this.heightBox.TabIndex = 92;
            this.heightBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.heightBox.ValueChanged += new System.EventHandler(this.validationSize);
            // 
            // widthBox
            // 
            this.widthBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.widthBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.widthBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.widthBox.Location = new System.Drawing.Point(595, 473);
            this.widthBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.widthBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(37, 22);
            this.widthBox.TabIndex = 93;
            this.widthBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.widthBox.ValueChanged += new System.EventHandler(this.validationSize);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.entrance);
            this.panel4.Controls.Add(this.heavyParkingPlace);
            this.panel4.Controls.Add(this.exit);
            this.panel4.Controls.Add(this.empty);
            this.panel4.Controls.Add(this.lightParkingPlace);
            this.panel4.Controls.Add(this.tree);
            this.panel4.Controls.Add(this.road);
            this.panel4.Location = new System.Drawing.Point(523, 183);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 144);
            this.panel4.TabIndex = 94;
            // 
            // ParkingSpaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(824, 548);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshParking);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.saveToFile);
            this.Controls.Add(this.downAdjacentRoad);
            this.Controls.Add(this.upAdjacentRoad);
            this.Controls.Add(this.rightAdjacentRoad);
            this.Controls.Add(this.leftAdjacentRoad);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParkingSpaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигурирование пространства парковки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.shutDownApplication);
            ((System.ComponentModel.ISupportInitialize)(this.empty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entrance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heavyParkingPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightParkingPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.road)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox entrance;
        private System.Windows.Forms.PictureBox exit;
        private System.Windows.Forms.PictureBox road;
        private System.Windows.Forms.PictureBox heavyParkingPlace;
        private System.Windows.Forms.PictureBox tree;
        private System.Windows.Forms.PictureBox empty;
        private System.Windows.Forms.PictureBox lightParkingPlace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button saveToFile;
        private System.Windows.Forms.Button refreshParking;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel leftAdjacentRoad;
        private System.Windows.Forms.Panel rightAdjacentRoad;
        private System.Windows.Forms.Panel upAdjacentRoad;
        private System.Windows.Forms.Panel downAdjacentRoad;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown heightBox;
        private System.Windows.Forms.NumericUpDown widthBox;
        private System.Windows.Forms.Panel panel4;
    }
}