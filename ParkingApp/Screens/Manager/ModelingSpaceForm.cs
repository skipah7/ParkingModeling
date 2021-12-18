using ParkingApp.Classes;
using ParkingApp.Classes.AlgPathFind;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ParkingApp.Classes.BaseParkingClasses;

namespace ParkingApp.Screens.Manager
{
    public partial class ModelingSpaceForm : Form
    {
        private static System.Timers.Timer VisualizationTimer;

        private ModelingParams modelingParams;
        private int height;
        double systemTimer = 0;
        public ModelingSpaceForm(int height, int width, string[,] patterns, ModelingParams modelingParams)
        {
            InitializeComponent();
            this.clearValues();

            this.height = height;
            this.modelingParams = modelingParams;

            Globals.calculatePictureBoxSize(height, width);
            Globals.highwayPatterns = new string[width, height + 1];
            mainPanel.Location = new Point(0, 0);
            SystemTimeLabel.Location = new Point(height * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE * 2, 0);
            freePlacesCounter.Location = new Point(height * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE * 2, 20);
            dataGridView1.Location = new Point(height * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE * 2, 40);
            dataGridView1.Size = new Size(300, width * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE - 40);

            var parkingField = new ParkingFieldClass();
            parkingField.fillPictureBoxesList(width, height, patterns);
            parkingField.applyPictureBoxes(mainPanel);

            FindPaths.fillParkingMatrix(width, height, patterns);

            mainPanel.Invalidate();

            RoadsClass.createRoads(mainPanel, width, height);
            FindPaths.fillRoadMatrix(width, height);

            configureTimers();
        }

        private Car moveToEntrance(Car car)
        {
            car.currPos = FindPaths.roadStart;
            car.carPath.AddRange(car.getPathList(FindPaths.roadStart, FindPaths.roadBeforeEntrance, FindPaths.roadMatrix));
            Action action = () =>
            {
                mainPanel.Controls.Add(car.carPicBox);
                car.timer.Start();
                car.currPos = FindPaths.roadBeforeEntrance;
            };

            if (InvokeRequired) Invoke(action);
            else action();

            return car;
        }

        private void moveFromRoadToEntrance(Car car)
        {
            car.currPos = FindPaths.roadBeforeEntrance;
            car.carPath.AddRange(car.getBetweenTwoPointRoadPark(FindPaths.roadBeforeEntrance, FindPaths.parkingEntrance));
            car.currPos = FindPaths.parkingEntrance;
        }

        private void moveFromEntranceToParkingPlace(Car car)
        {
            PathPoint parkPoint = FindPaths.getParkPoint(car);
            car.currPos = FindPaths.parkingEntrance;
            car.carPath.AddRange(car.getPathList(FindPaths.parkingEntrance, parkPoint, FindPaths.parkingMatrix));
            car.currPos = parkPoint;
        }

        private void moveAwayFromEntrance(Car car)
        {
            car.currPos = FindPaths.roadBeforeEntrance;
            car.carPath.AddRange(car.getPathList(FindPaths.roadBeforeEntrance, FindPaths.roadEnd, FindPaths.roadMatrix));
            car.currPos = FindPaths.roadEnd;
        }

        private void addToTablo(Car car)
        {
            car.tabloItem = new TableItem(
                this.modelingParams.parkingInterval, 
                car.parkingPlaceNumber, 
                Convert.ToInt32(Globals.tariff.carPrice * this.modelingParams.parkingInterval)
            );
            Globals.tabloItems.Add(car.tabloItem);
        }

        private void stayOnParking(Car car)
        {
            car.timeStay = this.modelingParams.parkingInterval * 50 * Globals.INTERVAL;
        }

        private void VisualizationTimer_Tick(object sender, EventArgs e)
        {
            VisualizationTimer.Interval = this.modelingParams.appearanceInterval * 50 * Globals.INTERVAL;

            var car = new Car(this.height);
            car.rotateCarBeforeStart();
            moveToEntrance(car);
            if (car.probability <= this.modelingParams.lightCarProbability && FindPaths.parkPoints.Count != 0)
            {
                moveFromRoadToEntrance(car);
                moveFromEntranceToParkingPlace(car);
                stayOnParking(car);

                addToTablo(car);
            }
            else
            {
                moveAwayFromEntrance(car);
            }
            refreshTablo();
        }

        private void refreshTablo()
        {
            Action action = () =>
            {
                freePlacesCounter.Text = "Свободных парковочных мест: " + FindPaths.parkPoints.Count;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Globals.tabloItems;
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void SystemTime_Tick1(object sender, EventArgs e)
        {
            systemTimer += 0.5;
            SystemTimeLabel.Text = "Системное время: " + systemTimer;
        }

        private void configureTimers()
        {
            VisualizationTimer = new System.Timers.Timer();
            // fixme :question_mark:
            VisualizationTimer.Interval = this.modelingParams.appearanceInterval * 50 * Globals.INTERVAL;
            VisualizationTimer.Elapsed += VisualizationTimer_Tick;
            VisualizationTimer.Start();

            SystemTime.Start();
            SystemTime.Interval = 50 * Globals.INTERVAL;
            SystemTime.Tick += SystemTime_Tick1;
        }

        private void clearValues()
        {
            FindPaths.parkingEntrance = null;
            FindPaths.parkingExit = null;
            FindPaths.roadStart = null;
            FindPaths.roadEnd = null;
            FindPaths.roadBeforeEntrance = null;
            FindPaths.roadBeforeExit = null;
            FindPaths.parkPoints = new List<PathPoint>();
            FindPaths.carPoints = new List<PathPoint>();
            FindPaths.parkingMatrix = null;
            FindPaths.roadMatrix = null;
            Globals.tabloItems = new List<TableItem>();
        }

        private void setPlaySpeed()
        {
            if (1 == 1)
            {
                Globals.INTERVAL = 40;
            }
            else if (2 == 2)
            {
                Globals.INTERVAL = 20;
            }
            else if (3 == 3)
            {
                Globals.INTERVAL = 10;
            }
            else
            {
                Globals.INTERVAL = 5;
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            /*
            try
            {
                e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
                e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/
        }

        #region helpers

        private void exit(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                this.Hide();
                VisualizationTimer.Stop();
                SystemTime.Stop();
                ConfigureModelingParamsForm configureModelingParams = new ConfigureModelingParamsForm();
                configureModelingParams.Show();
            }
        }

        private void shutDownApplication(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}