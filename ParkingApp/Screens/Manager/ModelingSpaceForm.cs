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
        public ModelingSpaceForm()
        {
            InitializeComponent();

            clearValues();

            Globals.calculatePictureBoxSize(Globals.HEIGHT, Globals.WIDTH);

            Globals.highwayPatterns = new String[Globals.WIDTH + 1, Globals.HEIGHT + 1];

            panel1.Location = new Point(0, 0);

            ParkingFieldClass parkingField = new ParkingFieldClass();

            parkingField.fillPictureBoxesList(5,5, Globals.patterns);
            parkingField.loadField(panel1);

            FindPaths.fillParkMatr();

            panel1.Invalidate();

            RoadsClass.createRoads(panel1, Globals.WIDTH, Globals.HEIGHT);
            FindPaths.fillRoadMatr();

            configureTimer();

            SystemTimeLabel.Location = new Point(Globals.HEIGHT * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE * 2, 0);
            freePlacesCounter.Location = new Point(Globals.HEIGHT * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE * 2, 20);
            dataGridView1.Location = new Point(Globals.HEIGHT * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE * 2, 40);
            dataGridView1.Size = new Size(300, Globals.WIDTH * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE - 40);

            SystemTime.Start();
            SystemTime.Interval = 50 * Globals.INTERVAL;
            SystemTime.Tick += SystemTime_Tick1;
        }

        private void clearValues()
        {
            FindPaths.startPark = null;
            FindPaths.endPark = null;
            FindPaths.startRoad = null;
            FindPaths.endRoad = null;
            FindPaths.preStartPark = null;
            FindPaths.preEndPark = null;
            FindPaths.parkPoints = new List<PathPoint>();
            FindPaths.carPoints = new List<PathPoint>();
            Globals.tabloItems = new List<TableItem>();
            FindPaths.parkMatr = null;
            FindPaths.roadMatr = null;
        }

        double systemTimer = 0;
        private void SystemTime_Tick1(object sender, EventArgs e)
        {
            systemTimer+=0.5;
            SystemTimeLabel.Text = "Системное время: " + systemTimer;
        }

        int intervalNumber = 0;
        private void configureTimer()
        {
            VisualizationTimer = new System.Timers.Timer();
            if (Globals.modelingParams.appearanceInterval != 0)
            {
                VisualizationTimer.Interval = Globals.modelingParams.appearanceInterval * 50 * Globals.INTERVAL;
            }
            else
            {
                VisualizationTimer.Interval = Globals.modelingParams.appearanceIntervals[intervalNumber] * 50 * Globals.INTERVAL;
                intervalNumber++;
            }  
            VisualizationTimer.Elapsed += VisualizationTimer_Tick;
            VisualizationTimer.Start();
        }

        private Car startRoad(Car car)
        {
            car.currPos = FindPaths.startRoad;
            car.onParking.AddRange(car.getBetweenTwoPointRoad(FindPaths.startRoad, FindPaths.preStartPark));
            Action action = () =>
            {
                panel1.Controls.Add(car.carPicBox);
                car.timer1.Start();
                car.currPos = FindPaths.preStartPark;
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
            return car;
        }
        private void outRoadToPark(Car car)
        {
            car.currPos = FindPaths.preStartPark;
            car.onParking.AddRange(car.getBetweenTwoPointRoadPark(FindPaths.preStartPark, FindPaths.startPark));
            car.currPos = FindPaths.startPark;
        }
        private void preStartParkToEndRoad(Car car)
        {
            car.currPos = FindPaths.preStartPark;
            car.onParking.AddRange(car.getBetweenTwoPointRoad(FindPaths.preStartPark, FindPaths.endRoad));
            car.currPos = FindPaths.endRoad;
        }

        private void preStartParkToParkPoint(Car car)
        {
            PathPoint parkPoint = FindPaths.getParkPoint(car);
            car.onParking.AddRange(car.getBetweenTwoPointPark(FindPaths.startPark, parkPoint));
            car.currPos = FindPaths.startPark;
            car.currPos = parkPoint;
        }

        private void addToTablo(Car car)
        {
            if (intervalNumber == 100)
            {
                intervalNumber = 0;
            }
            if (Globals.modelingParams.parkingInterval != 0)
            {
                car.tabloItem = new TableItem(Globals.modelingParams.parkingInterval, car.parkingPlaceNumber, Globals.tariff.carPrice * Globals.modelingParams.parkingInterval);
                Globals.tabloItems.Add(car.tabloItem);
            }
            else
            {
                car.tabloItem = new TableItem(Globals.modelingParams.onParkingIntervals[intervalNumber], car.parkingPlaceNumber, Convert.ToInt32(Globals.tariff.carPrice * Globals.modelingParams.onParkingIntervals[intervalNumber]));
                Globals.tabloItems.Add(car.tabloItem);
            }
        }

        private Car stayOnParking(Car car)
        {
            if (Globals.modelingParams.parkingInterval != 0)
            {
                car.timeStay = Globals.modelingParams.parkingInterval * 50 * Globals.INTERVAL;
            }
            else
            {
                car.timeStay = Globals.modelingParams.onParkingIntervals[intervalNumber] * 50 * Globals.INTERVAL;
            }
            return car;
        }

        private void VisualizationTimer_Tick(object sender, EventArgs e)
        {
            timerIntervalStep();
            Car car = new Car();
            car.rotateCarBeforeStart();
            startRoad(car);
            if (car.probability <= Globals.modelingParams.probability && FindPaths.parkPoints.Count != 0)
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
            {
                action();
            }
        }

        private void timerIntervalStep()
        {
            if (intervalNumber == 100)
            {
                intervalNumber = 0;
            }
            if (Globals.modelingParams.appearanceInterval != 0)
            {
                VisualizationTimer.Interval = Globals.modelingParams.appearanceInterval * 50 * Globals.INTERVAL;
            }
            else
            {
                VisualizationTimer.Interval = Globals.modelingParams.appearanceIntervals[intervalNumber] * 50 * Globals.INTERVAL;
            }
            
            intervalNumber++;
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