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

            FindPaths.fillParkMatr(width, height, patterns);

            mainPanel.Invalidate();

            RoadsClass.createRoads(mainPanel, width, height);
            FindPaths.fillRoadMatr(width, height);

            configureTimer();
            SystemTime.Start();
            SystemTime.Interval = 50 * Globals.INTERVAL;
            SystemTime.Tick += SystemTime_Tick1;
        }

        private void clearValues()
        {
            FindPaths.parkingEntrance = null;
            FindPaths.parkingExit = null;
            FindPaths.startRoad = null;
            FindPaths.endRoad = null;
            FindPaths.roadBeforeEntrance = null;
            FindPaths.roadBeforeExit = null;
            FindPaths.parkPoints = new List<PathPoint>();
            FindPaths.carPoints = new List<PathPoint>();
            Globals.tabloItems = new List<TableItem>();
            FindPaths.parkingMatrix = null;
            FindPaths.roadMatr = null;
        }

        double systemTimer = 0;
        private void SystemTime_Tick1(object sender, EventArgs e)
        {
            systemTimer+=0.5;
            SystemTimeLabel.Text = "Системное время: " + systemTimer;
        }

        private void configureTimer()
        {
            VisualizationTimer = new System.Timers.Timer();

            VisualizationTimer.Interval = this.modelingParams.appearanceInterval * 50 * Globals.INTERVAL;

            VisualizationTimer.Elapsed += VisualizationTimer_Tick;
            VisualizationTimer.Start();
        }

        private Car startRoad(Car car)
        {
            car.currPos = FindPaths.startRoad;
            car.onParking.AddRange(car.getBetweenTwoPointRoad(FindPaths.startRoad, FindPaths.roadBeforeEntrance));
            Action action = () =>
            {
                mainPanel.Controls.Add(car.carPicBox);
                car.timer.Start();
                car.currPos = FindPaths.roadBeforeEntrance;
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
            return car;
        }
        private void outRoadToPark(Car car)
        {
            car.currPos = FindPaths.roadBeforeEntrance;
            car.onParking.AddRange(car.getBetweenTwoPointRoadPark(FindPaths.roadBeforeEntrance, FindPaths.parkingEntrance));
            car.currPos = FindPaths.parkingEntrance;
        }
        private void preStartParkToEndRoad(Car car)
        {
            car.currPos = FindPaths.roadBeforeEntrance;
            car.onParking.AddRange(car.getBetweenTwoPointRoad(FindPaths.roadBeforeEntrance, FindPaths.endRoad));
            car.currPos = FindPaths.endRoad;
        }

        private void preStartParkToParkPoint(Car car)
        {
            PathPoint parkPoint = FindPaths.getParkPoint(car);
            car.onParking.AddRange(car.getBetweenTwoPointPark(FindPaths.parkingEntrance, parkPoint));
            car.currPos = FindPaths.parkingEntrance;
            car.currPos = parkPoint;
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

        private Car stayOnParking(Car car)
        {
            car.timeStay = this.modelingParams.parkingInterval * 50 * Globals.INTERVAL;
            return car;
        }

        private void VisualizationTimer_Tick(object sender, EventArgs e)
        {
            timerIntervalStep();
            Car car = new Car(this.height);
            car.rotateCarBeforeStart();
            startRoad(car);
            if (car.probability <= this.modelingParams.lightCarProbability && FindPaths.parkPoints.Count != 0)
            {
                outRoadToPark(car);
                preStartParkToParkPoint(car);
                stayOnParking(car);

                addToTablo(car);
            }
            else
            {
                preStartParkToEndRoad(car);
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

        private void timerIntervalStep()
        {
            VisualizationTimer.Interval = this.modelingParams.appearanceInterval * 50 * Globals.INTERVAL;
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