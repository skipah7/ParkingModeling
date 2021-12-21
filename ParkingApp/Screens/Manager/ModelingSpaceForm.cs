using ParkingApp.Classes;
using ParkingApp.Classes.AlgPathFind;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ParkingApp.Classes.BaseParkingClasses;
using System.ComponentModel;

namespace ParkingApp.Screens.Manager
{
    public partial class ModelingSpaceForm : Form
    {
        private static System.Timers.Timer VisualizationTimer;

        private BindingList<TableItem> tableDataSource;
        private ModelingParams modelingParams;
        private Random random;
        private string[,] patterns;

        private int timeHours;
        private int timeMinutes;
        private List<Car> cars;

        public ModelingSpaceForm(int height, int width, string[,] patterns, ModelingParams modelingParams)
        {
            InitializeComponent();
            Paths.reset();
            this.tableDataSource = new BindingList<TableItem>();
            this.cars = new List<Car>();

            this.random = new Random();
            this.modelingParams = modelingParams;
            this.patterns = patterns;

            this.timeHours = modelingParams.timeHours;
            this.timeMinutes = modelingParams.timeMinutes;

            Globals.calculatePictureBoxSize(height, width);
            Globals.highwayPatterns = new string[width, height + 1];
            mainPanel.Location = new Point(0, 0);
            SystemTimeLabel.Location = new Point((width + 3) * Globals.PICTURE_BOX_SIZE, 0);
            freePlacesCounter.Location = new Point((width + 3) * Globals.PICTURE_BOX_SIZE, 20);
            dataGridView.Location = new Point((width + 3) * Globals.PICTURE_BOX_SIZE, 40);
            dataGridView.Size = new Size(300, (height - 1) * Globals.PICTURE_BOX_SIZE);
            dataGridView.DataSource = tableDataSource;
            controlPanel.Location = new Point(dataGridView.Location.X, dataGridView.Location.Y + dataGridView.Size.Height);

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
            car.addToDataTable += Car_addToDataTable;
            car.removeFromDataTable += Car_removeFromDataTable;
            this.cars.Add(car);
            car.rotateCarBeforeStart();
            moveToEntrance(car);
            if (car.shouldEnterParking(random.NextDouble()))
            {
                this.moveFromRoadToEntrance(car);
                this.moveFromEntranceToParkingPlace(car);
                this.setParkingTime(car);

                this.moveFromParkingPlaceToTileBeforeExit(car);
                this.moveFromTileBeforeExitToExit(car);
                this.moveAwayFromExit(car);
            }
            else
            {
                moveAwayFromEntrance(car);
            }
        }

        private void Car_removeFromDataTable(object sender, EventArgs e)
        {
            var car = sender as Car;
            tableDataSource.Remove(car.tableItem);
            car.removeFromDataTable -= Car_removeFromDataTable;
        }

        private void Car_addToDataTable(object sender, EventArgs e)
        {
            var car = sender as Car;
            var realParkingTime = (int)(car.timeOnParking / (50 * Globals.INTERVAL));
            var totalPrice = this.calculateTotalPrice(realParkingTime);
            var tableItem = new TableItem(car.parkingPlaceNumber, this.SystemTimeLabel.Text, realParkingTime, totalPrice);
            car.tableItem = tableItem;
            this.tableDataSource.Add(tableItem);
            car.addToDataTable -= Car_addToDataTable;
        }

        private int calculateTotalPrice(int parkingTime)
        {
            var totalPrice = 0d;
            var minutesDayRate = (double)this.modelingParams.dayTariffRate / 60;
            var minutesNightRate = (double)this.modelingParams.nightTariffRate / 60;
            var tariffHours = this.timeHours;
            var tariffMinutes = this.timeMinutes;

            for (var i = 0; i < parkingTime; i++)
            {
                totalPrice += (tariffHours < 23 && tariffHours > 7) ? minutesDayRate : minutesNightRate;
                if (tariffMinutes > 59)
                {
                    tariffHours++;
                    tariffMinutes = 0;
                }
                else tariffMinutes++;
                tariffHours = tariffHours > 23 ? 0 : tariffHours;
            }

            return (int)totalPrice;
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
                    if (this.patterns.GetLength(0) <= element.X || this.patterns.GetLength(1) <= element.Y || element.Y < 0 || element.X < 0) continue;
                    if (this.patterns[element.X, element.Y] != Globals.HEAVY_PARKING_PLACE_SECOND) continue;
                    var mainParkingPlace = Modeling.getLocationFromPathPoint(parkPoint);
                    var secondHeavyParkingPartPosition = Modeling.getLocationFromPathPoint(new PathPoint(element.X, element.Y));
                    var newX = mainParkingPlace.X + ((secondHeavyParkingPartPosition.X - mainParkingPlace.X) / 2);
                    var newY = mainParkingPlace.Y + ((secondHeavyParkingPartPosition.Y - mainParkingPlace.Y) / 2);

                    var realParkingPlace = new Point(newX, newY);
                    realParkingPlace.Offset(-mainParkingPlace.X, -mainParkingPlace.Y);
                    car.addPoints(car.carPath, realParkingPlace);

                    realParkingPlace = new Point(newX, newY);
                    mainParkingPlace.Offset(-realParkingPlace.X, -realParkingPlace.Y);
                    car.addPoints(car.carPath, mainParkingPlace);

                    car.heavyParkingPlace = Modeling.getLocationFromPathPoint(parkPoint);
                    car.parkingPlace = realParkingPlace;
                }
            }
            if (car.carType == CarType.Ligth)
            {
                car.parkingPlace = Modeling.getLocationFromPathPoint(parkPoint);
            }
        }

        private void moveFromParkingPlaceToTileBeforeExit(Car car)
        {
            car.carPath.AddRange(car.getPathList(car.currentPosition, Paths.tileBeforeExit, Paths.parkingMatrix));
            Paths.parkingMatrix[car.currentPosition.X, car.currentPosition.Y] = 5;
            car.currentPosition = Paths.tileBeforeExit;
        }

        private void moveFromTileBeforeExitToExit(Car car)
        {
            car.currentPosition = Paths.tileBeforeExit;
            car.carPath.AddRange(car.setPathBetweenTwoPoints(Paths.tileBeforeExit, Paths.parkingExit));
            car.currentPosition = Paths.parkingExit;
        }

        private void moveAwayFromExit(Car car)
        {
            car.currentPosition = Paths.parkingExit;
            car.carPath.AddRange(car.getPathList(Paths.parkingExit, Paths.roadEnd, Paths.roadMatrix));
            car.currentPosition = Paths.roadEnd;
        }

        private void moveAwayFromEntrance(Car car)
        {
            car.currentPosition = Paths.roadBeforeEntrance;
            car.carPath.AddRange(car.getPathList(Paths.roadBeforeEntrance, Paths.roadEnd, Paths.roadMatrix));
            car.currentPosition = Paths.roadEnd;
        }

        private void setParkingTime(Car car)
        {
            car.timeOnParking = this.modelingParams.parkingInterval * 50 * Globals.INTERVAL;
        }

        private void SystemTime_Tick1(object sender, EventArgs e)
        {
            var freeParkingPlaces = Paths.ligthParkingPlaces.Count + Paths.heavyParkingPlaces.Count;
            freePlacesCounter.Text = "Свободных парковочных мест: " + freeParkingPlaces + "/" + Paths.totalParkingPlaces;

            if (timeMinutes > 59)
            {
                timeHours++;
                timeMinutes = 0;
            } else timeMinutes++;
            timeHours = timeHours > 23 ? 0 : timeHours;
            SystemTimeLabel.Text = timeHours.ToString("00") + " : " + timeMinutes.ToString("00");
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

        #region helpers

        private void exitButton_Click(object sender, EventArgs e)
        {
            VisualizationTimer.Stop();
            SystemTime.Stop();
            foreach (Control control in this.Controls) control.Dispose();
            this.cars.ForEach((car) => {
                car.timer.Stop();
                car = null;
                }
            ); 
            this.cars = null;
            this.Close();
            this.Dispose();
            GC.Collect();
            ManagerMainScreen managerMainScreen = new ManagerMainScreen();
            managerMainScreen.Show();
        }

        #endregion
    }
}