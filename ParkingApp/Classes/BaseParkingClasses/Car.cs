using ParkingApp.Classes.AlgPathFind;
using ParkingApp.Classes.BaseParkingClasses;
using ParkingApp.Properties;
using System;
using System.Collections.Generic;
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

    class Car
    {
        private static int OFFSET = 5;

        public PathPoint currentPosition { get; set; }
        public PictureBox carPicBox { get; set; }
        public List<Point> carPath { get; set; }
        public TableItem tabloItem { get; set; }

        private Random random;
        public double probability { get; set; }
        public int parkingPlaceNumber { get; set; }
        public double timeStay { get; set; }

        public Timer timer;
        private CarDirection currentCarDirection = CarDirection.Top;
        public Car()
        {
            random = new Random();
            carPath = new List<Point>();

            this.probability = random.NextDouble();

            timer = new Timer { Interval = Globals.INTERVAL };
            timer.Tick += timerTick;

            carPicBox = new PictureBox
            {
                Location = Modeling.getLocationFromPathPoint(Paths.roadStart),
                Image = getRandomCarImage(),
                Name = "car",
                Size = new Size(Globals.PICTURE_BOX_SIZE, Globals.PICTURE_BOX_SIZE),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            carPicBox.MouseEnter += CarPicBox_MouseEnter;
        }

        public async void timerTick(object sender, EventArgs e)
        {
            carPicBox.BringToFront();
            var newX = carPicBox.Location.X + carPath.ElementAt(0).X;
            var newY = carPicBox.Location.Y + carPath.ElementAt(0).Y;
            if (carPath.Count > 1) rotateCar(newX, newY);
            carPicBox.Location = new Point(newX, newY);

            carPath.RemoveAt(0);
            if (carPath.Count != 0) return;

            timer.Stop();
            if (currentPosition == Paths.roadEnd)
            {
                carPicBox.Dispose();
            }
            else
            {
                await Task.Delay(Convert.ToInt32(timeStay));
                await Task.Run(() => moveFromParkingPlaceToExit(this));
                await Task.Run(() => moveFromExitToRoad(this));
                await Task.Run(() => moveAwayFromExit(this));
                this.carPicBox.Refresh();
                timer.Start();
            }
        }

        public List<Point> setPathBetweenTwoPoints(PathPoint start, PathPoint end)
        {
            List<Point> points = new List<Point>();
            var firstPoint = Modeling.getLocationFromPathPoint(start);
            var secondPoint = Modeling.getLocationFromPathPoint(end);
            secondPoint.Offset(-firstPoint.X, -firstPoint.Y);
            addPoints(points, secondPoint);
            return points;
        }

        private void addPoints(List<Point> points, Point secondPoint)
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

        private void moveFromParkingPlaceToExit(Car car)
        {
            PathPoint carParkingPosition = Paths.getCarParkingPosition(car);
            if (carParkingPosition == null) return;

            car.currentPosition = carParkingPosition;
            car.carPath.AddRange(car.getPathList(car.currentPosition, Paths.parkingExit, Paths.parkingMatrix));
            Paths.parkingMatrix[currentPosition.X, currentPosition.Y] = 5;

            car.currentPosition = Paths.parkingExit;

            Globals.tabloItems.Remove(tabloItem);
        }

        private Car moveFromExitToRoad(Car car)
        {
            car.currentPosition = Paths.parkingExit;
            car.carPath.AddRange(car.setPathBetweenTwoPoints(Paths.parkingExit, Paths.roadBeforeExit));
            car.currentPosition = Paths.roadBeforeExit;
            return car;
        }

        private Car moveAwayFromExit(Car car)
        {
            car.currentPosition = Paths.roadBeforeExit;
            car.carPath.AddRange(car.getPathList(Paths.roadBeforeExit, Paths.roadEnd, Paths.roadMatrix));
            car.currentPosition = Paths.roadEnd;
            return car;
        }

        public Image getRandomCarImage()
        {
            random = new Random();
            int value = random.Next(0, 5);

            if (value == 0) return Resources.carPic1;
            if (value == 1) return Resources.carPic2;
            if (value == 2) return Resources.carPic3;
            if (value == 3) return Resources.carPic4;
            if (value == 4) return Resources.carPic5;
            return Resources.carPic5;
        }

        public void rotateCarBeforeStart()
        {
            carPicBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.currentCarDirection = CarDirection.Left;
            carPicBox.Refresh();
        }

        private void CarPicBox_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip((PictureBox)sender, "Вероятность заезда: " + Math.Round((1 - this.probability), 2));
        }
    }
}
