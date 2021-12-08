namespace ParkingApp.Screens.Manager
{
    partial class ConfigureModelingParamsForm
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
            this.backToAdminMainScreen = new System.Windows.Forms.Button();
            this.exponTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.bLabel = new System.Windows.Forms.Label();
            this.aLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.typeOfDistributionLowComboBox = new System.Windows.Forms.ComboBox();
            this.onParkingIntervalTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.HazardFlowRadioBtn = new System.Windows.Forms.RadioButton();
            this.determinisicFlowButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.RandomFlowLabel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.DXonParkingIntervalTB = new System.Windows.Forms.TextBox();
            this.MXonParkingIntervalTB = new System.Windows.Forms.TextBox();
            this.lambdaOnParkingIntervalTB = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.bOnParkingIntervalTB = new System.Windows.Forms.TextBox();
            this.aOnParkingIntervalTB = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timeStartLabel = new System.Windows.Forms.Label();
            this.lightCarProbability = new System.Windows.Forms.TrackBar();
            this.lightCarLabel = new System.Windows.Forms.Label();
            this.heavyCarLabel = new System.Windows.Forms.Label();
            this.heavyCarProbability = new System.Windows.Forms.TrackBar();
            this.lightToHeavyRationLabel = new System.Windows.Forms.Label();
            this.lightToHeavyRatio = new System.Windows.Forms.TrackBar();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.deterministicAppearanceInterval = new System.Windows.Forms.TrackBar();
            this.deterministicLabel = new System.Windows.Forms.Label();
            this.startTimeHours = new System.Windows.Forms.NumericUpDown();
            this.startTimeMinutes = new System.Windows.Forms.NumericUpDown();
            this.aValue = new System.Windows.Forms.TrackBar();
            this.bValue = new System.Windows.Forms.TrackBar();
            this.uniformPanel = new System.Windows.Forms.Panel();
            this.normalPanel = new System.Windows.Forms.Panel();
            this.DXValue = new System.Windows.Forms.TrackBar();
            this.MXValue = new System.Windows.Forms.TrackBar();
            this.MXLabel = new System.Windows.Forms.Label();
            this.DXLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightCarProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heavyCarProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightToHeavyRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deterministicAppearanceInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTimeHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTimeMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bValue)).BeginInit();
            this.uniformPanel.SuspendLayout();
            this.normalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DXValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MXValue)).BeginInit();
            this.SuspendLayout();
            // 
            // backToAdminMainScreen
            // 
            this.backToAdminMainScreen.Location = new System.Drawing.Point(83, 494);
            this.backToAdminMainScreen.Margin = new System.Windows.Forms.Padding(2);
            this.backToAdminMainScreen.Name = "backToAdminMainScreen";
            this.backToAdminMainScreen.Size = new System.Drawing.Size(75, 23);
            this.backToAdminMainScreen.TabIndex = 14;
            this.backToAdminMainScreen.Text = "Назад";
            this.backToAdminMainScreen.UseVisualStyleBackColor = true;
            this.backToAdminMainScreen.Click += new System.EventHandler(this.backToAdminMainScreen_Click);
            // 
            // exponTextBox
            // 
            this.exponTextBox.Location = new System.Drawing.Point(368, 346);
            this.exponTextBox.Name = "exponTextBox";
            this.exponTextBox.Size = new System.Drawing.Size(50, 20);
            this.exponTextBox.TabIndex = 58;
            this.exponTextBox.Text = "0,28";
            this.exponTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.probabilityTextBox_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(347, 349);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 13);
            this.label15.TabIndex = 57;
            this.label15.Text = " λ";
            // 
            // bLabel
            // 
            this.bLabel.AutoSize = true;
            this.bLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bLabel.Location = new System.Drawing.Point(10, 43);
            this.bLabel.Name = "bLabel";
            this.bLabel.Size = new System.Drawing.Size(16, 16);
            this.bLabel.TabIndex = 56;
            this.bLabel.Text = "b";
            // 
            // aLabel
            // 
            this.aLabel.AutoSize = true;
            this.aLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aLabel.Location = new System.Drawing.Point(10, 14);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(16, 16);
            this.aLabel.TabIndex = 55;
            this.aLabel.Text = "a";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(167, 453);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(125, 453);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(80, 453);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 453);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "0.5";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(30, 421);
            this.trackBar1.Maximum = 4;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(159, 45);
            this.trackBar1.TabIndex = 48;
            this.trackBar1.Value = 1;
            this.trackBar1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 405);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Скорость воспроизведения:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 46;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // typeOfDistributionLowComboBox
            // 
            this.typeOfDistributionLowComboBox.FormattingEnabled = true;
            this.typeOfDistributionLowComboBox.Items.AddRange(new object[] {
            "Равномерный",
            "Экспоненциальный",
            "Нормальный"});
            this.typeOfDistributionLowComboBox.Location = new System.Drawing.Point(210, 199);
            this.typeOfDistributionLowComboBox.Name = "typeOfDistributionLowComboBox";
            this.typeOfDistributionLowComboBox.Size = new System.Drawing.Size(134, 21);
            this.typeOfDistributionLowComboBox.TabIndex = 45;
            this.typeOfDistributionLowComboBox.Text = "Закон распределения";
            this.typeOfDistributionLowComboBox.Visible = false;
            this.typeOfDistributionLowComboBox.SelectionChangeCommitted += new System.EventHandler(this.typeOfDistributionLowComboBox_SelectionChangeCommitted);
            // 
            // onParkingIntervalTextBox
            // 
            this.onParkingIntervalTextBox.Location = new System.Drawing.Point(142, 378);
            this.onParkingIntervalTextBox.Name = "onParkingIntervalTextBox";
            this.onParkingIntervalTextBox.Size = new System.Drawing.Size(50, 20);
            this.onParkingIntervalTextBox.TabIndex = 44;
            this.onParkingIntervalTextBox.Text = "5";
            this.onParkingIntervalTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.appearanceIntervalTextBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Интервал стоянки";
            // 
            // HazardFlowRadioBtn
            // 
            this.HazardFlowRadioBtn.AutoSize = true;
            this.HazardFlowRadioBtn.Location = new System.Drawing.Point(281, 168);
            this.HazardFlowRadioBtn.Name = "HazardFlowRadioBtn";
            this.HazardFlowRadioBtn.Size = new System.Drawing.Size(112, 17);
            this.HazardFlowRadioBtn.TabIndex = 35;
            this.HazardFlowRadioBtn.Text = "Случайный поток";
            this.HazardFlowRadioBtn.UseVisualStyleBackColor = true;
            this.HazardFlowRadioBtn.CheckedChanged += new System.EventHandler(this.randomFlowSelected);
            // 
            // determinisicFlowButton
            // 
            this.determinisicFlowButton.AutoSize = true;
            this.determinisicFlowButton.Checked = true;
            this.determinisicFlowButton.Location = new System.Drawing.Point(24, 168);
            this.determinisicFlowButton.Name = "determinisicFlowButton";
            this.determinisicFlowButton.Size = new System.Drawing.Size(165, 17);
            this.determinisicFlowButton.TabIndex = 34;
            this.determinisicFlowButton.TabStop = true;
            this.determinisicFlowButton.Text = "Детерминированный поток";
            this.determinisicFlowButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Вероятность заезда";
            // 
            // RandomFlowLabel
            // 
            this.RandomFlowLabel.AutoSize = true;
            this.RandomFlowLabel.Location = new System.Drawing.Point(21, 202);
            this.RandomFlowLabel.Name = "RandomFlowLabel";
            this.RandomFlowLabel.Size = new System.Drawing.Size(160, 13);
            this.RandomFlowLabel.TabIndex = 63;
            this.RandomFlowLabel.Text = "Выбор закона распределения";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(256, 390);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 13);
            this.label19.TabIndex = 64;
            this.label19.Text = "Стоянка автомобиля";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(264, 462);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 13);
            this.label20.TabIndex = 74;
            this.label20.Text = "DX";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(265, 436);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 13);
            this.label21.TabIndex = 73;
            this.label21.Text = "MX";
            // 
            // DXonParkingIntervalTB
            // 
            this.DXonParkingIntervalTB.Location = new System.Drawing.Point(294, 459);
            this.DXonParkingIntervalTB.Name = "DXonParkingIntervalTB";
            this.DXonParkingIntervalTB.Size = new System.Drawing.Size(50, 20);
            this.DXonParkingIntervalTB.TabIndex = 72;
            this.DXonParkingIntervalTB.Text = "0,1";
            // 
            // MXonParkingIntervalTB
            // 
            this.MXonParkingIntervalTB.Location = new System.Drawing.Point(294, 433);
            this.MXonParkingIntervalTB.Name = "MXonParkingIntervalTB";
            this.MXonParkingIntervalTB.Size = new System.Drawing.Size(50, 20);
            this.MXonParkingIntervalTB.TabIndex = 71;
            this.MXonParkingIntervalTB.Text = "4";
            // 
            // lambdaOnParkingIntervalTB
            // 
            this.lambdaOnParkingIntervalTB.Location = new System.Drawing.Point(294, 445);
            this.lambdaOnParkingIntervalTB.Name = "lambdaOnParkingIntervalTB";
            this.lambdaOnParkingIntervalTB.Size = new System.Drawing.Size(50, 20);
            this.lambdaOnParkingIntervalTB.TabIndex = 70;
            this.lambdaOnParkingIntervalTB.Text = "0,28";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(271, 448);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(15, 13);
            this.label22.TabIndex = 69;
            this.label22.Text = " λ";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(273, 462);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(13, 13);
            this.label23.TabIndex = 68;
            this.label23.Text = "b";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(273, 436);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(13, 13);
            this.label24.TabIndex = 67;
            this.label24.Text = "a";
            // 
            // bOnParkingIntervalTB
            // 
            this.bOnParkingIntervalTB.Location = new System.Drawing.Point(294, 459);
            this.bOnParkingIntervalTB.Name = "bOnParkingIntervalTB";
            this.bOnParkingIntervalTB.Size = new System.Drawing.Size(50, 20);
            this.bOnParkingIntervalTB.TabIndex = 66;
            this.bOnParkingIntervalTB.Text = "120";
            // 
            // aOnParkingIntervalTB
            // 
            this.aOnParkingIntervalTB.Location = new System.Drawing.Point(294, 433);
            this.aOnParkingIntervalTB.Name = "aOnParkingIntervalTB";
            this.aOnParkingIntervalTB.Size = new System.Drawing.Size(50, 20);
            this.aOnParkingIntervalTB.TabIndex = 65;
            this.aOnParkingIntervalTB.Text = "0,5";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Равномерный",
            "Экспоненциальный",
            "Нормальный"});
            this.comboBox1.Location = new System.Drawing.Point(284, 406);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(134, 21);
            this.comboBox1.TabIndex = 75;
            this.comboBox1.Text = "Закон распределения";
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.onParkingIntervalCB);
            // 
            // timeStartLabel
            // 
            this.timeStartLabel.AutoSize = true;
            this.timeStartLabel.Location = new System.Drawing.Point(12, 9);
            this.timeStartLabel.Name = "timeStartLabel";
            this.timeStartLabel.Size = new System.Drawing.Size(161, 13);
            this.timeStartLabel.TabIndex = 76;
            this.timeStartLabel.Text = "Время начала моделирования";
            // 
            // lightCarProbability
            // 
            this.lightCarProbability.Location = new System.Drawing.Point(21, 74);
            this.lightCarProbability.Maximum = 100;
            this.lightCarProbability.Name = "lightCarProbability";
            this.lightCarProbability.Size = new System.Drawing.Size(168, 45);
            this.lightCarProbability.TabIndex = 80;
            this.lightCarProbability.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lightCarProbability.Value = 50;
            // 
            // lightCarLabel
            // 
            this.lightCarLabel.AutoSize = true;
            this.lightCarLabel.Location = new System.Drawing.Point(42, 58);
            this.lightCarLabel.Name = "lightCarLabel";
            this.lightCarLabel.Size = new System.Drawing.Size(122, 13);
            this.lightCarLabel.TabIndex = 81;
            this.lightCarLabel.Text = "Легковые автомобили";
            // 
            // heavyCarLabel
            // 
            this.heavyCarLabel.AutoSize = true;
            this.heavyCarLabel.Location = new System.Drawing.Point(271, 58);
            this.heavyCarLabel.Name = "heavyCarLabel";
            this.heavyCarLabel.Size = new System.Drawing.Size(122, 13);
            this.heavyCarLabel.TabIndex = 83;
            this.heavyCarLabel.Text = "Легковые автомобили";
            // 
            // heavyCarProbability
            // 
            this.heavyCarProbability.Location = new System.Drawing.Point(250, 74);
            this.heavyCarProbability.Maximum = 100;
            this.heavyCarProbability.Name = "heavyCarProbability";
            this.heavyCarProbability.Size = new System.Drawing.Size(168, 45);
            this.heavyCarProbability.TabIndex = 82;
            this.heavyCarProbability.TickStyle = System.Windows.Forms.TickStyle.None;
            this.heavyCarProbability.Value = 50;
            // 
            // lightToHeavyRationLabel
            // 
            this.lightToHeavyRationLabel.AutoSize = true;
            this.lightToHeavyRationLabel.Location = new System.Drawing.Point(96, 99);
            this.lightToHeavyRationLabel.Name = "lightToHeavyRationLabel";
            this.lightToHeavyRationLabel.Size = new System.Drawing.Size(248, 13);
            this.lightToHeavyRationLabel.TabIndex = 85;
            this.lightToHeavyRationLabel.Text = "Соотношение легковых/грузовых автомобилей";
            // 
            // lightToHeavyRatio
            // 
            this.lightToHeavyRatio.Location = new System.Drawing.Point(137, 115);
            this.lightToHeavyRatio.Maximum = 100;
            this.lightToHeavyRatio.Name = "lightToHeavyRatio";
            this.lightToHeavyRatio.Size = new System.Drawing.Size(168, 45);
            this.lightToHeavyRatio.TabIndex = 84;
            this.lightToHeavyRatio.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lightToHeavyRatio.Value = 50;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(-60, 136);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(589, 13);
            this.label25.TabIndex = 86;
            this.label25.Text = "_________________________________________________________________________________" +
    "________________";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 152);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(204, 13);
            this.label26.TabIndex = 87;
            this.label26.Text = "Блок настройки транспортного потока";
            // 
            // deterministicAppearanceInterval
            // 
            this.deterministicAppearanceInterval.Location = new System.Drawing.Point(24, 202);
            this.deterministicAppearanceInterval.Maximum = 20;
            this.deterministicAppearanceInterval.Minimum = 1;
            this.deterministicAppearanceInterval.Name = "deterministicAppearanceInterval";
            this.deterministicAppearanceInterval.Size = new System.Drawing.Size(168, 45);
            this.deterministicAppearanceInterval.TabIndex = 88;
            this.deterministicAppearanceInterval.TickStyle = System.Windows.Forms.TickStyle.None;
            this.deterministicAppearanceInterval.Value = 10;
            // 
            // deterministicLabel
            // 
            this.deterministicLabel.AutoSize = true;
            this.deterministicLabel.Location = new System.Drawing.Point(31, 189);
            this.deterministicLabel.Name = "deterministicLabel";
            this.deterministicLabel.Size = new System.Drawing.Size(142, 13);
            this.deterministicLabel.TabIndex = 89;
            this.deterministicLabel.Text = "Интервал появления (мин)";
            // 
            // startTimeHours
            // 
            this.startTimeHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startTimeHours.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.startTimeHours.Location = new System.Drawing.Point(179, 5);
            this.startTimeHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.startTimeHours.Name = "startTimeHours";
            this.startTimeHours.Size = new System.Drawing.Size(37, 22);
            this.startTimeHours.TabIndex = 90;
            // 
            // startTimeMinutes
            // 
            this.startTimeMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startTimeMinutes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.startTimeMinutes.Location = new System.Drawing.Point(222, 5);
            this.startTimeMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.startTimeMinutes.Name = "startTimeMinutes";
            this.startTimeMinutes.Size = new System.Drawing.Size(37, 22);
            this.startTimeMinutes.TabIndex = 91;
            // 
            // aValue
            // 
            this.aValue.Location = new System.Drawing.Point(29, 14);
            this.aValue.Minimum = 1;
            this.aValue.Name = "aValue";
            this.aValue.Size = new System.Drawing.Size(168, 45);
            this.aValue.TabIndex = 92;
            this.aValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.aValue.Value = 5;
            // 
            // bValue
            // 
            this.bValue.BackColor = System.Drawing.SystemColors.Window;
            this.bValue.Location = new System.Drawing.Point(29, 42);
            this.bValue.Maximum = 20;
            this.bValue.Minimum = 2;
            this.bValue.Name = "bValue";
            this.bValue.Size = new System.Drawing.Size(168, 45);
            this.bValue.TabIndex = 93;
            this.bValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.bValue.Value = 10;
            // 
            // uniformPanel
            // 
            this.uniformPanel.Controls.Add(this.bValue);
            this.uniformPanel.Controls.Add(this.aValue);
            this.uniformPanel.Controls.Add(this.aLabel);
            this.uniformPanel.Controls.Add(this.bLabel);
            this.uniformPanel.Location = new System.Drawing.Point(183, 221);
            this.uniformPanel.Name = "uniformPanel";
            this.uniformPanel.Size = new System.Drawing.Size(200, 78);
            this.uniformPanel.TabIndex = 94;
            // 
            // normalPanel
            // 
            this.normalPanel.Controls.Add(this.DXValue);
            this.normalPanel.Controls.Add(this.MXValue);
            this.normalPanel.Controls.Add(this.MXLabel);
            this.normalPanel.Controls.Add(this.DXLabel);
            this.normalPanel.Location = new System.Drawing.Point(183, 221);
            this.normalPanel.Name = "normalPanel";
            this.normalPanel.Size = new System.Drawing.Size(200, 78);
            this.normalPanel.TabIndex = 95;
            // 
            // DXValue
            // 
            this.DXValue.BackColor = System.Drawing.SystemColors.Window;
            this.DXValue.Location = new System.Drawing.Point(29, 42);
            this.DXValue.Maximum = 50;
            this.DXValue.Name = "DXValue";
            this.DXValue.Size = new System.Drawing.Size(168, 45);
            this.DXValue.TabIndex = 93;
            this.DXValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.DXValue.Value = 25;
            // 
            // MXValue
            // 
            this.MXValue.Location = new System.Drawing.Point(29, 14);
            this.MXValue.Maximum = 50;
            this.MXValue.Minimum = 10;
            this.MXValue.Name = "MXValue";
            this.MXValue.Size = new System.Drawing.Size(168, 45);
            this.MXValue.TabIndex = 92;
            this.MXValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.MXValue.Value = 25;
            // 
            // MXLabel
            // 
            this.MXLabel.AutoSize = true;
            this.MXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MXLabel.Location = new System.Drawing.Point(3, 14);
            this.MXLabel.Name = "MXLabel";
            this.MXLabel.Size = new System.Drawing.Size(27, 16);
            this.MXLabel.TabIndex = 55;
            this.MXLabel.Text = "MX";
            // 
            // DXLabel
            // 
            this.DXLabel.AutoSize = true;
            this.DXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DXLabel.Location = new System.Drawing.Point(4, 42);
            this.DXLabel.Name = "DXLabel";
            this.DXLabel.Size = new System.Drawing.Size(26, 16);
            this.DXLabel.TabIndex = 56;
            this.DXLabel.Text = "DX";
            // 
            // ConfigureModelingParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(446, 528);
            this.Controls.Add(this.normalPanel);
            this.Controls.Add(this.uniformPanel);
            this.Controls.Add(this.startTimeMinutes);
            this.Controls.Add(this.startTimeHours);
            this.Controls.Add(this.deterministicLabel);
            this.Controls.Add(this.deterministicAppearanceInterval);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.lightToHeavyRationLabel);
            this.Controls.Add(this.lightToHeavyRatio);
            this.Controls.Add(this.heavyCarLabel);
            this.Controls.Add(this.heavyCarProbability);
            this.Controls.Add(this.lightCarLabel);
            this.Controls.Add(this.lightCarProbability);
            this.Controls.Add(this.timeStartLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.DXonParkingIntervalTB);
            this.Controls.Add(this.MXonParkingIntervalTB);
            this.Controls.Add(this.lambdaOnParkingIntervalTB);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.bOnParkingIntervalTB);
            this.Controls.Add(this.aOnParkingIntervalTB);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.RandomFlowLabel);
            this.Controls.Add(this.exponTextBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.typeOfDistributionLowComboBox);
            this.Controls.Add(this.onParkingIntervalTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.HazardFlowRadioBtn);
            this.Controls.Add(this.determinisicFlowButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backToAdminMainScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigureModelingParamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка параметров моделирования";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.shutDownApplication);
            this.Resize += new System.EventHandler(this.preventResize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightCarProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heavyCarProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightToHeavyRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deterministicAppearanceInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTimeHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTimeMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bValue)).EndInit();
            this.uniformPanel.ResumeLayout(false);
            this.uniformPanel.PerformLayout();
            this.normalPanel.ResumeLayout(false);
            this.normalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DXValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MXValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button backToAdminMainScreen;
        private System.Windows.Forms.TextBox exponTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label bLabel;
        private System.Windows.Forms.Label aLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox typeOfDistributionLowComboBox;
        private System.Windows.Forms.TextBox onParkingIntervalTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton HazardFlowRadioBtn;
        private System.Windows.Forms.RadioButton determinisicFlowButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RandomFlowLabel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox DXonParkingIntervalTB;
        private System.Windows.Forms.TextBox MXonParkingIntervalTB;
        private System.Windows.Forms.TextBox lambdaOnParkingIntervalTB;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox bOnParkingIntervalTB;
        private System.Windows.Forms.TextBox aOnParkingIntervalTB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label timeStartLabel;
        private System.Windows.Forms.TrackBar lightCarProbability;
        private System.Windows.Forms.Label lightCarLabel;
        private System.Windows.Forms.Label heavyCarLabel;
        private System.Windows.Forms.TrackBar heavyCarProbability;
        private System.Windows.Forms.Label lightToHeavyRationLabel;
        private System.Windows.Forms.TrackBar lightToHeavyRatio;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TrackBar deterministicAppearanceInterval;
        private System.Windows.Forms.Label deterministicLabel;
        private System.Windows.Forms.NumericUpDown startTimeHours;
        private System.Windows.Forms.NumericUpDown startTimeMinutes;
        private System.Windows.Forms.TrackBar aValue;
        private System.Windows.Forms.TrackBar bValue;
        private System.Windows.Forms.Panel uniformPanel;
        private System.Windows.Forms.Panel normalPanel;
        private System.Windows.Forms.TrackBar DXValue;
        private System.Windows.Forms.TrackBar MXValue;
        private System.Windows.Forms.Label MXLabel;
        private System.Windows.Forms.Label DXLabel;
    }
}