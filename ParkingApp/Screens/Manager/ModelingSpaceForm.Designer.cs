namespace ParkingApp.Screens.Manager
{
    partial class ModelingSpaceForm
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.leftAdjacentRoad = new System.Windows.Forms.Panel();
            this.rightAdjacentRoad = new System.Windows.Forms.Panel();
            this.upAdjacentRoad = new System.Windows.Forms.Panel();
            this.downAdjacentRoad = new System.Windows.Forms.Panel();
            this.freePlacesCounter = new System.Windows.Forms.Label();
            this.SystemTime = new System.Windows.Forms.Timer(this.components);
            this.SystemTimeLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(0, 0);
            this.mainPanel.TabIndex = 0;
            // 
            // leftAdjacentRoad
            // 
            this.leftAdjacentRoad.AutoSize = true;
            this.leftAdjacentRoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.leftAdjacentRoad.Location = new System.Drawing.Point(0, 0);
            this.leftAdjacentRoad.Margin = new System.Windows.Forms.Padding(0);
            this.leftAdjacentRoad.Name = "leftAdjacentRoad";
            this.leftAdjacentRoad.Size = new System.Drawing.Size(0, 0);
            this.leftAdjacentRoad.TabIndex = 15;
            // 
            // rightAdjacentRoad
            // 
            this.rightAdjacentRoad.AutoSize = true;
            this.rightAdjacentRoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rightAdjacentRoad.Location = new System.Drawing.Point(0, 0);
            this.rightAdjacentRoad.Margin = new System.Windows.Forms.Padding(0);
            this.rightAdjacentRoad.Name = "rightAdjacentRoad";
            this.rightAdjacentRoad.Size = new System.Drawing.Size(0, 0);
            this.rightAdjacentRoad.TabIndex = 16;
            // 
            // upAdjacentRoad
            // 
            this.upAdjacentRoad.AutoSize = true;
            this.upAdjacentRoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.upAdjacentRoad.Location = new System.Drawing.Point(0, 0);
            this.upAdjacentRoad.Margin = new System.Windows.Forms.Padding(0);
            this.upAdjacentRoad.Name = "upAdjacentRoad";
            this.upAdjacentRoad.Size = new System.Drawing.Size(0, 0);
            this.upAdjacentRoad.TabIndex = 17;
            // 
            // downAdjacentRoad
            // 
            this.downAdjacentRoad.AutoSize = true;
            this.downAdjacentRoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.downAdjacentRoad.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.downAdjacentRoad.Location = new System.Drawing.Point(0, 0);
            this.downAdjacentRoad.Margin = new System.Windows.Forms.Padding(0);
            this.downAdjacentRoad.Name = "downAdjacentRoad";
            this.downAdjacentRoad.Size = new System.Drawing.Size(0, 0);
            this.downAdjacentRoad.TabIndex = 18;
            // 
            // freePlacesCounter
            // 
            this.freePlacesCounter.AutoSize = true;
            this.freePlacesCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.freePlacesCounter.Location = new System.Drawing.Point(308, 23);
            this.freePlacesCounter.Name = "freePlacesCounter";
            this.freePlacesCounter.Size = new System.Drawing.Size(209, 16);
            this.freePlacesCounter.TabIndex = 19;
            this.freePlacesCounter.Text = "Свободных парковочных мест: ";
            // 
            // SystemTime
            // 
            this.SystemTime.Interval = 1000;
            this.SystemTime.Tick += new System.EventHandler(this.SystemTime_Tick1);
            // 
            // SystemTimeLabel
            // 
            this.SystemTimeLabel.AutoSize = true;
            this.SystemTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SystemTimeLabel.Location = new System.Drawing.Point(59, 23);
            this.SystemTimeLabel.Name = "SystemTimeLabel";
            this.SystemTimeLabel.Size = new System.Drawing.Size(129, 16);
            this.SystemTimeLabel.TabIndex = 20;
            this.SystemTimeLabel.Text = "Системное время: ";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView.GridColor = System.Drawing.Color.Ivory;
            this.dataGridView.Location = new System.Drawing.Point(711, 98);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 81;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.Size = new System.Drawing.Size(300, 550);
            this.dataGridView.TabIndex = 21;
            this.dataGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            this.dataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.exit);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "placeNumber";
            this.Column1.HeaderText = "№ места";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "arrivalTime";
            this.Column2.HeaderText = "Время приезда";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "parkingTime";
            this.Column3.HeaderText = "Время стоянки";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "totalPrice";
            this.Column4.HeaderText = "Стоимость, руб";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // ModelingSpaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(931, 539);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.SystemTimeLabel);
            this.Controls.Add(this.freePlacesCounter);
            this.Controls.Add(this.downAdjacentRoad);
            this.Controls.Add(this.upAdjacentRoad);
            this.Controls.Add(this.rightAdjacentRoad);
            this.Controls.Add(this.leftAdjacentRoad);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModelingSpaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Моделирование";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.shutDownApplication);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.exit);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel leftAdjacentRoad;
        private System.Windows.Forms.Panel rightAdjacentRoad;
        private System.Windows.Forms.Panel upAdjacentRoad;
        private System.Windows.Forms.Panel downAdjacentRoad;
        private System.Windows.Forms.Label freePlacesCounter;
        private System.Windows.Forms.Timer SystemTime;
        private System.Windows.Forms.Label SystemTimeLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}