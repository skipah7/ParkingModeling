﻿using ParkingApp.Classes.AlgPathFind;
using ParkingApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ParkingApp.Classes.BaseParkingClasses;
using System.Threading.Tasks;

namespace ParkingApp.Classes
{
    class Car
    {
        private static int OFFSET = 5;
        private int height;

        public int rotate { get; set; }
        public PathPoint currPos { get; set; }
        public PictureBox carPicBox { get; set; }
        public List<Point> carPath { get; set; }
        public TableItem tabloItem { get; set; }

        private Random random;
        public double probability { get; set; }
        public int parkingPlaceNumber { get; set; }
        public double timeStay { get; set; }

        public Timer timer;
        public Car(int height)
        {
            random = new Random();
            carPath = new List<Point>();

            this.height = height;
            this.probability = random.NextDouble();

            timer = new Timer { Interval = Globals.INTERVAL };
            timer.Tick += timerTick;

            carPicBox = new PictureBox
            {
                Location = Modeling.getLocationFromPathPoint(FindPaths.roadStart),
                Image = getRandomCarImage(),
                Name = "car",
                Size = new Size(Globals.PICTURE_BOX_SIZE, Globals.PICTURE_BOX_SIZE),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            carPicBox.MouseEnter += CarPicBox_MouseEnter;
        }

        private void CarPicBox_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip((PictureBox)sender, "Вероятность заезда: " + Math.Round((1 - this.probability), 2));
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
            rotate = 3;
            carPicBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            carPicBox.Refresh();
        }

        public List<Point> getStayPoint(int k)
        {
            List<Point> points = new List<Point>();
            while (k >= 0)
            {
                points.Add(new Point(0, 0));
                k--;
            }
            return points;
        }

        public List<Point> getBetweenTwoPointRoadPark(PathPoint start, PathPoint end)
        {
            List<Point> points = new List<Point>();
            var firstPoint = Modeling.getLocationFromPathPoint(start);
            var secondPoint = Modeling.getLocationFromPathPoint(end);
            secondPoint.Offset(-firstPoint.X, -firstPoint.Y);
            addPoints(points, secondPoint);
            return points;
        }

        public List<Point> getBetweenTwoPointParkRoad(PathPoint start, PathPoint end)
        {
            List<Point> points = new List<Point>();
            var firstPoint = Modeling.getLocationFromPathPoint(start);
            var secondPoint = Modeling.getLocationFromPathPoint(end);
            secondPoint.Offset(-firstPoint.X, -firstPoint.Y);
            addPoints(points,secondPoint);
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
            var pathPoints = FindPaths.FindPath(matrix, start, end);
            for (int i = 0; i < pathPoints.Count - 1; i++)
            {
                var firstPoint = Modeling.getLocationFromPathPoint(pathPoints.ElementAt(i));
                var secondPoint = Modeling.getLocationFromPathPoint(pathPoints.ElementAt(i + 1));
                secondPoint.Offset(-firstPoint.X, -firstPoint.Y);
                addPoints(points, secondPoint);
            }
            return points;
        }

        public async void timerTick(object sender, EventArgs e)
        {
            carPicBox.BringToFront();
            carPicBox.Location = new Point(carPicBox.Location.X + carPath.ElementAt(0).X, carPicBox.Location.Y + carPath.ElementAt(0).Y);
            rotateCar();

            carPath.RemoveAt(0);
            if (carPath.Count != 0) return;

            timer.Stop();
            if (currPos == FindPaths.roadEnd)
            {
                carPicBox.Dispose();
            }
            else
            {
                await Task.Delay(Convert.ToInt32(timeStay));
                await Task.Run(() => outParkToEndPark(this));
                await Task.Run(() => outParkToRoad(this));
                await Task.Run(() => outRoad(this));
                this.carPicBox.Refresh();
                timer.Start();
            }
        }

        private void rotateCar()
        {
            if (carPath.Count < 2) return;

            var xDifference = carPath.ElementAt(1).X - carPath.ElementAt(0).X;
            var yDifference = carPath.ElementAt(1).Y - carPath.ElementAt(0).Y;

            //ехали вверх
            if ((carPath.ElementAt(0 + 1).Y == 0) && (carPath.ElementAt(0).Y < 0))
            {
                if (carPath.ElementAt(0 + 1).X > 0)
                {//поворот вправо
                 // машина смотрит вправо относительно начального положения въезда
                    rotate = 1;
                    carPicBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    carPicBox.Refresh();
                }
                else if (carPath.ElementAt(0 + 1).X < 0)
                {//поворот влево
                 //машина смотрит влево относительно начального положения въезда
                    rotate = 3;
                    carPicBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    carPicBox.Refresh();
                }
            }
            //ехали вниз
            if ((carPath.ElementAt(0 + 1).Y == 0) && (carPath.ElementAt(0).Y > 0))
            {
                if (carPath.ElementAt(0 + 1).X > 0)
                {//поворот вправо
                 //машина смотрит вправо относительно начального положения въезда
                    rotate = 1;
                    carPicBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    carPicBox.Refresh();
                }
                else if (carPath.ElementAt(0 + 1).X < 0)
                {//поворот влево
                 //машина смотрит влево относительно начального положения въезда
                    rotate = 3;
                    carPicBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    carPicBox.Refresh();
                }
            }
            //ехали вправо
            if ((carPath.ElementAt(0 + 1).X == 0) && (carPath.ElementAt(0).X > 0))
            {
                if (carPath.ElementAt(0 + 1).Y > 0)
                {//поворот вниз
                 //машина смотрит вниз относительно начального положения въезда
                    rotate = 2;
                    carPicBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    carPicBox.Refresh();
                }
                else if (carPath.ElementAt(0 + 1).Y < 0)
                {//поворот вверх
                 //машина смотрит вверх относительно начального положения въезда
                    rotate = 0;
                    carPicBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    carPicBox.Refresh();
                }
            }
            //ехали влево
            if ((carPath.ElementAt(0 + 1).X == 0) && (carPath.ElementAt(0).X < 0))
            {
                if (carPath.ElementAt(0 + 1).Y > 0)
                {//поворот вниз
                 //машина смотрит вниз относительно начального положения въезда
                    rotate = 2;
                    carPicBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    carPicBox.Refresh();
                }
                else if (carPath.ElementAt(0 + 1).Y < 0)
                {//поворот вверх
                 //машина смотрит вверх относительно начального положения въезда
                    rotate = 0;
                    carPicBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    carPicBox.Refresh();
                }
            }
        }

        private Car outParkToRoad(Car car)
        {
            car.currPos = FindPaths.parkingExit;
            car.carPath.AddRange(car.getBetweenTwoPointParkRoad(FindPaths.parkingExit, FindPaths.roadBeforeExit));
            car.currPos = FindPaths.roadBeforeExit;
            return car;
        }
        private Car outRoad(Car car)
        {
            car.currPos = FindPaths.roadBeforeExit;
            car.carPath.AddRange(car.getPathList(FindPaths.roadBeforeExit, FindPaths.roadEnd, FindPaths.roadMatrix));
            car.currPos = FindPaths.roadEnd;
            return car;
        }

        private void outParkToEndPark(Car car)
        {
            PathPoint carPoint = FindPaths.getCarPoint(car);
            if (carPoint == null) return;

            car.currPos = carPoint;
            car.carPath.AddRange(car.getPathList(car.currPos, FindPaths.parkingExit, FindPaths.parkingMatrix));
            FindPaths.parkingMatrix[currPos.X, currPos.Y] = 5;

            rotateCarBeforeExit(car);

            // car.timer.Start();
            //  car.carPicBox.Refresh();
            car.currPos = FindPaths.parkingExit;

            Globals.tabloItems.Remove(tabloItem);
        }

        private void rotateCarBeforeExit(Car car)
        {
            //полицейский разворот
            if (car.rotate == 0 && (FindPaths.parkingExit.X >= car.currPos.X))
            {
                car.carPicBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            else if (car.rotate == 1 && (FindPaths.parkingExit.Y == car.currPos.Y) && (FindPaths.parkingMatrix[car.currPos.X + 1, car.currPos.Y] == 0))
            {
                car.carPicBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (car.rotate == 1 && (FindPaths.parkingExit.Y <= car.currPos.Y))
            {
                car.carPicBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            else if (car.rotate == 2 && (FindPaths.parkingExit.X >= car.currPos.X) && (FindPaths.parkingMatrix[car.currPos.X, car.currPos.Y - 1] == 0))
            {
                car.carPicBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (car.rotate == 2 && (FindPaths.parkingExit.X <= car.currPos.X))
            {
                car.carPicBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            else if (car.rotate == 2 && (FindPaths.parkingExit.X > car.currPos.X))
            {
                car.carPicBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            // если машина повернута влево и находится слева от выезда с праковки, то поворачиваем

            else if (car.rotate == 3 && (FindPaths.parkingExit.Y <= car.currPos.Y) && (FindPaths.parkingMatrix[car.currPos.X + 1, car.currPos.Y] == 0))
            {
                car.carPicBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (car.rotate == 3 && (FindPaths.parkingExit.Y <= car.currPos.Y) && (FindPaths.parkingMatrix[car.currPos.X, car.currPos.Y - 1] == 0))
            {
                car.carPicBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
            }
            else if (car.rotate == 3 && (FindPaths.parkingExit.Y <= car.currPos.Y) && (FindPaths.parkingMatrix[car.currPos.X - 1, car.currPos.Y] == 0))
            {
                car.carPicBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (car.rotate == 3 && (FindPaths.parkingExit.Y > car.currPos.Y) && (FindPaths.parkingMatrix[car.currPos.X + 1, car.currPos.Y] == 0))
            {
                car.carPicBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else
            {
                car.carPicBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
        }

    }
}
