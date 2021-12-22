using ParkingApp.Classes.AlgPathFind;
using ParkingApp.Classes.BaseParkingClasses;
using ParkingApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingApp.Classes
{
    public enum CarDirection
    {
        Top,
        Right,
        Bottom,
        Left,
    }

    public enum CarType
    {
        Ligth,
        Heavy,
    }

    class Car
    {
        private static int OFFSET = 5;

        public PathPoint currentPosition { get; set; }
        public Point parkingPlace { get; set; }
        public Point heavyParkingPlace { get; set; }
        public PictureBox carPicBox { get; set; }
        public List<Point> carPath { get; set; }
        public TableItem tableItem { get; set; }

        public int parkingPlaceNumber { get; set; }
        public double timeOnParking { get; set; }

        public CarType carType;
        public Timer timer;
        private CarDirection currentCarDirection = CarDirection.Top;
        private ModelingParams modelingParams;
        public event EventHandler addToDataTable;
        public event EventHandler removeFromDataTable;
        public event EventHandler disposeCar;
        private DateTime timerStartTime;
        private int remainingInterval;


        public Car(ModelingParams modelingParams, double probability)
        {
            this.modelingParams = modelingParams;
            carPath = new List<Point>();

            this.carType = probability <= modelingParams.lightToHeavyRatio ? CarType.Ligth : CarType.Heavy;

            carPicBox = new PictureBox
            {
                Location = Modeling.getLocationFromPathPoint(Paths.roadStart),
                Image = getRandomCarImage(),
                Name = "Car",
                Size = new Size(Globals.PICTURE_BOX_SIZE, Globals.PICTURE_BOX_SIZE),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };

            this.timerStartTime = DateTime.Now;
            timer = new Timer { Interval = Globals.INTERVAL };
            timer.Tick += timerTick;
        }

        public void timerTick(object sender, EventArgs e)
        {
            if (carPath.Count == 0) return;

            carPicBox.BringToFront();
            var newX = carPicBox.Location.X + carPath.ElementAt(0).X;
            var newY = carPicBox.Location.Y + carPath.ElementAt(0).Y;
            if (carPath.Count > 1) rotateCar(newX, newY);
            carPicBox.Location = new Point(newX, newY);

            carPath.RemoveAt(0);
            if (carPath.Count == 0 && currentPosition == Paths.roadEnd) 
            {
                this.disposeCar.Invoke(this, EventArgs.Empty);
                carPicBox.Dispose();
                timer.Stop();
                return;
            }

            if (this.carPicBox.Location == Modeling.getLocationFromPathPoint(Paths.parkingEntrance)) this.addToDataTable.Invoke(this, EventArgs.Empty);
            if (this.carPicBox.Location == Modeling.getLocationFromPathPoint(Paths.parkingExit)) this.removeFromDataTable.Invoke(this, EventArgs.Empty);
            if (this.parkingPlace != null && this.carPicBox.Location == this.parkingPlace)
            {
                this.timerStartTime = DateTime.Now;
                timer.Interval = (int)timeOnParking;
                timer.Tick += timerReset;
            }
        }

        private void timerReset(object sender, EventArgs e)
        {
            this.carPicBox.Refresh();
            if (this.carType == CarType.Ligth) Paths.ligthParkingPlaces.Add(Modeling.getPathPointFromLocation(this.parkingPlace));
            if (this.carType == CarType.Heavy) Paths.heavyParkingPlaces.Add(Modeling.getPathPointFromLocation(this.heavyParkingPlace));

            this.timerStartTime = DateTime.Now;
            timer.Interval = Globals.INTERVAL;
            timer.Tick -= timerReset;
        }

        public void playPauseTimer()
        {
            if (this.timer.Enabled)
            {
                
                this.remainingInterval = (int)(this.timer.Interval - (DateTime.Now - this.timerStartTime).TotalMilliseconds);
                this.timer.Stop();
                return;
            }
            if (!this.timer.Enabled)
            {
                this.timer.Interval = this.remainingInterval > 0 ? this.remainingInterval : Globals.INTERVAL;
                this.timer.Start();
                this.timerStartTime = DateTime.Now;
                this.timer.Tick += intervalAdjust;
            }
        }

        public void adjustTimer(int newPlaySpeed, int currentPlaySpeed)
        {
            if (this.timer.Interval == currentPlaySpeed)
            {
                this.timerStartTime = DateTime.Now;
                this.timer.Interval = newPlaySpeed;
                return;
            }
            var playSpeedsRatio = (double)newPlaySpeed / currentPlaySpeed;
            var newTimerInterval = (this.timer.Interval - (DateTime.Now - this.timerStartTime).TotalMilliseconds) * playSpeedsRatio;
            this.timerStartTime = DateTime.Now;
            this.timer.Interval = (int)newTimerInterval;
            this.timer.Tick += intervalAdjust;
        }

        private void intervalAdjust(object sender, EventArgs e)
        {
            this.timerStartTime = DateTime.Now;
            this.timer.Interval = Globals.INTERVAL;
            this.timer.Tick -= intervalAdjust;
        }

        public bool shouldEnterParking(double probability)
        {
            bool result = false;
            if (this.carType == CarType.Heavy)
            {
                result = (probability <= this.modelingParams.heavyCarProbability) && (Paths.heavyParkingPlaces.Count != 0);
            }
            if (this.carType == CarType.Ligth)
            {
                result = (probability <= this.modelingParams.lightCarProbability) && (Paths.ligthParkingPlaces.Count != 0);
            }
            return result;
        }

        public List<Point> getPathList(PathPoint start, PathPoint end, int[,] matrix)
        {
            List<Point> points = new List<Point>();
            var pathPoints = Paths.FindPath(matrix, start, end);
            for (int i = 0; i < pathPoints.Count - 1; i++)
            {
                var firstPoint = Modeling.getLocationFromPathPoint(pathPoints.ElementAt(i));
                var secondPoint = Modeling.getLocationFromPathPoint(pathPoints.ElementAt(i + 1));
                secondPoint.Offset(-firstPoint.X, -firstPoint.Y);
                addPoints(points, secondPoint);
            }
            return points;
        }

        public List<Point> setPathBetweenTwoPoints(PathPoint start, PathPoint end, bool isForHeavy = false)
        {
            List<Point> points = new List<Point>();
            var firstPoint = Modeling.getLocationFromPathPoint(start);
            var secondPoint = Modeling.getLocationFromPathPoint(end);

            secondPoint.Offset(-firstPoint.X, -firstPoint.Y);
            this.addPoints(points, secondPoint);
            return points;
        }

        public void addPoints(List<Point> points, Point secondPoint)
        {
            if (secondPoint.X != 0)
            {
                int temp = 0;
                int path = Math.Sign(secondPoint.X) * OFFSET;
                while (temp != secondPoint.X)
                {
                    points.Add(new Point(path, 0));
                    temp += Math.Sign(secondPoint.X) * OFFSET;
                }
            }

            if (secondPoint.Y != 0)
            {
                int temp = 0;
                int path = Math.Sign(secondPoint.Y) * OFFSET;
                while (temp != secondPoint.Y)
                {
                    points.Add(new Point(0, path));
                    temp += Math.Sign(secondPoint.Y) * OFFSET;
                }
            }
        }

        private void rotateCar(int newX, int newY)
        {
            var xDifference = newX - carPicBox.Location.X;
            var yDifference = newY - carPicBox.Location.Y;

            if (xDifference < 0) this.changeCarDirection(CarDirection.Left);
            if (yDifference < 0) this.changeCarDirection(CarDirection.Top);
            if (xDifference > 0) this.changeCarDirection(CarDirection.Right);
            if (yDifference > 0) this.changeCarDirection(CarDirection.Bottom);
        }

        private void changeCarDirection(CarDirection carDirection)
        {
            if (this.currentCarDirection == carDirection) return;

            int FULL_TURN = 4;
            var amountOfTurns = FULL_TURN - (int)this.currentCarDirection + (int)carDirection;
            for (var i = 0; i < amountOfTurns; i++) this.carPicBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            this.currentCarDirection = carDirection;
            this.carPicBox.Refresh();
        }

        public Image getRandomCarImage()
        {
            var random = new Random();

            if (this.carType == CarType.Ligth)
            {
                int value = random.Next(0, 5);
                if (value == 0) return Resources.carPic1;
                if (value == 1) return Resources.carPic2;
                if (value == 2) return Resources.carPic3;
                if (value == 3) return Resources.carPic4;
                if (value == 4) return Resources.carPic5;
            }
            if (this.carType == CarType.Heavy)
            {
                int value = random.Next(0, 4);
                if (value == 0) return Resources.heavyCarPic1;
                if (value == 1) return Resources.heavyCarPic2;
                if (value == 2) return Resources.heavyCarPic3;
                if (value == 3) return Resources.heavyCarPic4;
            }
            return Resources.carPic5;
        }

        public void rotateCarBeforeStart()
        {
            carPicBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.currentCarDirection = CarDirection.Left;
            carPicBox.Refresh();
        }
    }
}
