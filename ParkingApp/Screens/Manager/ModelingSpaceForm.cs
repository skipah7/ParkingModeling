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
        private Random random;
        private double systemTimer = 0;
        private string[,] patterns;
        public ModelingSpaceForm(int height, int width, string[,] patterns, ModelingParams modelingParams)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
            this.clearValues();

            this.random = new Random();
            this.modelingParams = modelingParams;
            this.patterns = patterns;

            Globals.calculatePictureBoxSize(height, width);
            Globals.highwayPatterns = new string[width, height + 1];
            mainPanel.Location = new Point(0, 0);
            SystemTimeLabel.Location = new Point(width * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE * 2, 0);
            freePlacesCounter.Location = new Point(width * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE * 2, 20);
            dataGridView1.Location = new Point(width * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE * 2, 40);
            dataGridView1.Size = new Size(300, height * Globals.PICTURE_BOX_SIZE + Globals.PICTURE_BOX_SIZE - 40);

            var parkingField = new ParkingFieldClass();
            parkingField.fillPictureBoxesList(width, height, patterns);
            parkingField.applyPictureBoxes(mainPanel);

            Paths.fillParkingMatrix(width, height, patterns);

            mainPanel.Invalidate();

            RoadsClass.createRoads(mainPanel, width, height);
            Paths.fillRoadMatrix(width, height);

            configureTimers();
        }

        private void VisualizationTimer_Tick(object sender, EventArgs e)
        {
            VisualizationTimer.Interval = this.modelingParams.appearanceInterval * 50 * Globals.INTERVAL;

            var car = new Car(this.modelingParams, random.NextDouble());
            car.rotateCarBeforeStart();
            moveToEntrance(car);
            if (car.shouldEnterParking(random.NextDouble()))
            {
                this.moveFromRoadToEntrance(car);
                this.moveFromEntranceToParkingPlace(car);
                this.setParkingTime(car);

                this.moveFromParkingPlaceToExit(car);
                this.moveFromExitToRoad(car);
                this.moveAwayFromExit(car);
            }
            else
            {
                moveAwayFromEntrance(car);
            }
        }

        private void moveToEntrance(Car car)
        {
            car.currentPosition = Paths.roadStart;
            car.carPath.AddRange(car.getPathList(Paths.roadStart, Paths.roadBeforeEntrance, Paths.roadMatrix));
            Action action = () =>
            {
                mainPanel.Controls.Add(car.carPicBox);
                car.timer.Start();
                car.currentPosition = Paths.roadBeforeEntrance;
            };

            if (InvokeRequired) Invoke(action);
            else action();
        }

        private void moveFromRoadToEntrance(Car car)
        {
            car.currentPosition = Paths.roadBeforeEntrance;
            car.carPath.AddRange(car.setPathBetweenTwoPoints(Paths.roadBeforeEntrance, Paths.parkingEntrance));
            car.currentPosition = Paths.parkingEntrance;
        }

        private void moveFromEntranceToParkingPlace(Car car)
        {
            PathPoint parkPoint = Paths.getFreeParkingPlace(car);

            car.currentPosition = Paths.parkingEntrance;
            car.carPath.AddRange(car.getPathList(Paths.parkingEntrance, parkPoint, Paths.parkingMatrix));
            car.currentPosition = parkPoint;

            if (car.carType == CarType.Heavy)
            {
                var x = parkPoint.X;
                var y = parkPoint.Y;
                var nearbyElements = new[] { new PathPoint(x + 1, y), new PathPoint(x - 1, y), new PathPoint(x, y + 1), new PathPoint(x, y - 1) };
                foreach (var element in nearbyElements)
                {
                    if (this.patterns.GetLength(0) < element.X || this.patterns.GetLength(1) < element.Y || element.Y < 0 || element.X < 0) continue;
                    if (this.patterns[element.X, element.Y] != Globals.HEAVY_PARKING_PLACE_SECOND) continue;
                    var mainParkingPlace = Modeling.getLocationFromPathPoint(parkPoint);
                    var secondHeavyParkingPartPosition = Modeling.getLocationFromPathPoint(new PathPoint(element.X, element.Y));
                    var newX = mainParkingPlace.X + ((secondHeavyParkingPartPosition.X - mainParkingPlace.X) / 2);
                    var newY = mainParkingPlace.Y + ((secondHeavyParkingPartPosition.Y - mainParkingPlace.Y) / 2);

                    //car.setPathBetweenTwoPoints(car.carPath[car.carPath.Count - 1], new PathPoint(element.X, element.Y), true);
                    var realParkingPlace = new Point(newX, newY);
                    realParkingPlace.Offset(-mainParkingPlace.X, -mainParkingPlace.Y);
                    car.addPoints(car.carPath, realParkingPlace);

                    realParkingPlace = new Point(newX, newY);
                    mainParkingPlace.Offset(-realParkingPlace.X, -realParkingPlace.Y);
                    car.addPoints(car.carPath, mainParkingPlace);

                    car.parkingPlace = realParkingPlace;
                }
            }
            if (car.carType == CarType.Ligth)
            {
                car.parkingPlace = Modeling.getLocationFromPathPoint(parkPoint);
            }
        }

        private void moveFromParkingPlaceToExit(Car car)
        {
            car.carPath.AddRange(car.getPathList(car.currentPosition, Paths.parkingExit, Paths.parkingMatrix));
            Paths.parkingMatrix[car.currentPosition.X, car.currentPosition.Y] = 5;
            car.currentPosition = Paths.parkingExit;
        }

        private Car moveFromExitToRoad(Car car)
        {
            car.currentPosition = Paths.parkingExit;
            car.carPath.AddRange(car.setPathBetweenTwoPoints(Paths.parkingExit, Paths.roadBeforeExit));
            car.currentPosition = Paths.roadBeforeExit;
            return car;
        }

        private void moveAwayFromEntrance(Car car)
        {
            car.currentPosition = Paths.roadBeforeEntrance;
            car.carPath.AddRange(car.getPathList(Paths.roadBeforeEntrance, Paths.roadEnd, Paths.roadMatrix));
            car.currentPosition = Paths.roadEnd;
        }

        private void moveAwayFromExit(Car car)
        {
            car.currentPosition = Paths.roadBeforeExit;
            car.carPath.AddRange(car.getPathList(Paths.roadBeforeExit, Paths.roadEnd, Paths.roadMatrix));
            car.currentPosition = Paths.roadEnd;
        }

        private void setParkingTime(Car car)
        {
            car.timeStay = this.modelingParams.parkingInterval * 50 * Globals.INTERVAL;
        }

        private void refreshTablo()
        {
            Action action = () =>
            {
                var freeParkingPlaces = Paths.ligthParkingPlaces.Count + Paths.heavyParkingPlaces.Count;
                freePlacesCounter.Text = "Свободных парковочных мест: " + freeParkingPlaces + "/" + Paths.totalParkingPlaces;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Globals.tableItem;
            };
            if (InvokeRequired) Invoke(action);
            else action();
        }

        private void SystemTime_Tick1(object sender, EventArgs e)
        {
            systemTimer += 0.5;
            SystemTimeLabel.Text = "Системное время: " + systemTimer;
            this.refreshTablo();
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
            Paths.reset();
            Globals.tableItem = new List<TableItem>();
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