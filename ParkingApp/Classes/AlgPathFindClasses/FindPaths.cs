using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingApp.Classes.AlgPathFind
{
    class FindPaths
    {
        public static PathPoint parkingEntrance;
        public static PathPoint parkingExit;
        public static PathPoint startRoad;
        public static PathPoint endRoad;
        public static PathPoint roadBeforeEntrance;
        public static PathPoint roadBeforeExit;

        public static List<PathPoint> parkPoints = new List<PathPoint>();
        public static List<PathPoint> carPoints = new List<PathPoint>();
        // public static List<PathPoint> freeParkPoints = new List<PathPoint>();
        public static int[,] parkingMatrix;
        public static int[,] roadMatr;
        // public static bool startEnd;
        //  public static List<PathPoint> PointsPath = new List<PathPoint>();

        public static void fillParkMatr(int width, int height, string[,] patterns)
        {
            parkingMatrix = new int[width, height];
            parkingEntrance = new PathPoint(0, 0);
            parkingExit = new PathPoint(0, 0);
            roadBeforeEntrance = new PathPoint(0, 0);
            roadBeforeExit = new PathPoint(0, 0);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (patterns[x, y] == Globals.ROAD)
                    {
                        parkingMatrix[x, y] = 0;
                    }
                    else if (patterns[x, y] == Globals.LIGHT_PARKING_PLACE)
                    {
                        parkingMatrix[x, y] = 5;
                        parkPoints.Add(new PathPoint(x, y));
                    }
                    else if (patterns[x, y] == Globals.ENTRANCE)
                    {
                        parkingMatrix[x, y] = 1;
                        parkingEntrance.set(x, y);
                        roadBeforeEntrance = getRoadPathPoint(parkingEntrance, roadBeforeEntrance);
                    }
                    else if (patterns[x, y] == Globals.EXIT)
                    {
                        parkingMatrix[x, y] = 1;
                        parkingExit.set(x, y);
                        roadBeforeExit = getRoadPathPoint(parkingExit, roadBeforeExit);
                     //   roadBeforeExit.X = x;
                     //   roadBeforeExit.Y = y;
                    }
                    else
                    {
                        parkingMatrix[x, y] = 2;
                    }
                }
            }
        }

        //Функция вычисления направления
        public static PathPoint getRoadPathPoint(PathPoint pointPark, PathPoint pointRoad)
        {
            return new PathPoint(pointPark.X, pointPark.Y + 1);
        }
        
        public static void fillRoadMatr(int width, int height)
        {
            startRoad = new PathPoint(0, 0);
            endRoad = new PathPoint(0, 0);
            roadMatr = new int[width + 1, height + 1];
            if (Globals.leftAdjacentRoadLength != 0 && Globals.downAdjacentRoadLength !=0)
            {
                endRoad = new PathPoint(0, 0);
                startRoad = new PathPoint(width, height);
            }
            else if (Globals.leftAdjacentRoadLength != 0 && Globals.upAdjacentRoadLength != 0)
            {
                endRoad = new PathPoint(0, height);
                startRoad = new PathPoint(width, 0);
            }
            else if (Globals.rightAdjacentRoadLength != 0 && Globals.downAdjacentRoadLength != 0)
            {
                endRoad = new PathPoint(width, 0);
                startRoad = new PathPoint(0, height);
            }
            else if (Globals.rightAdjacentRoadLength != 0 && Globals.upAdjacentRoadLength != 0)
            {
                endRoad = new PathPoint(width, height);
                startRoad = new PathPoint(0, 0);
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height + 1; y++)
                {
                    if (Globals.highwayPatterns[x, y] == Globals.HIGHWAY)
                    {
                        roadMatr[x, y] = 7;
                    }
                    else { roadMatr[x, y] = 2; }
                }
            }
        }

        // выезжающая машины
        public static PathPoint getCarPoint(Car car)
        {
            if (carPoints.Count != 0)
            {
                try
                {
                    var t = carPoints.First(car2 => ((car2.X == car.currPos.X) && (car2.Y == car.currPos.Y)));
                    carPoints.Remove(t);
                    parkingMatrix[t.X, t.Y] = 3;// рассматриваемая машина
                    parkPoints.Add(t);
                    return t;
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            return null;
        }

        //Поиск свободного места для легковых авто
        public static PathPoint getParkPoint(Car car)
        {          
            Random rnd = new Random();
            int value = rnd.Next(parkPoints.Count);
            //var f = freeParkPoints.ElementAt(value);
            
            var t = parkPoints.ElementAt(value);

            string placeNumber = t.X + "" + t.Y;
            car.parkingPlaceNumber = int.Parse(placeNumber);
            parkPoints.Remove(t);
            parkingMatrix[t.X, t.Y] = 3;// рассматриваемое парковочное место
            carPoints.Add(t);// добавляем машину в список          
            return t;
        }

        public static List<PathPoint> FindPath(int[,] field, PathPoint start, PathPoint goal)
        {
            //Создается 2 списка вершин — ожидающие рассмотрения и уже рассмотренные.
            //В ожидающие добавляется точка старта, список рассмотренных пока пуст.
            var closedSet = new List<PathNode>();
            var openSet = new List<PathNode>();
            //Для каждой точки рассчитывается F = G + H. G — расстояние от старта до точки, H — примерное расстояние от точки до цели.  
            //Так же каждая точка хранит ссылку на точку, из которой в нее пришли.
            PathNode startNode = new PathNode()
            {
                Position = start,
                CameFrom = null,
                PathLengthFromStart = 0,
                HeuristicEstimatePathLength = GetHeuristicPathLength(start, goal)
            };
            openSet.Add(startNode);
            while (openSet.Count > 0)
            {
                // Из списка точек на рассмотрение выбирается точка с наименьшим F. Обозначим ее X.
                var currentNode = openSet.OrderBy(node => node.EstimateFullPathLength).First();
                //Если X — цель, то мы нашли маршрут.
                if ((currentNode.Position.X == goal.X) && (currentNode.Position.Y == goal.Y))
                {
                    if ((field[goal.X, goal.Y] != 1) && (field[goal.X, goal.Y] != 7))
                    { field[goal.X, goal.Y] = 5; }//парковочное место занято}
                    return GetPathForNode(currentNode);
                }
                //Переносим X из списка ожидающих рассмотрения в список уже рассмотренных.
                openSet.Remove(currentNode);
                closedSet.Add(currentNode);
                //Для каждой из точек, соседних для X(обозначим эту соседнюю точку Y), делаем следующее:
                //Если Y уже находится в рассмотренных — пропускаем ее.
                foreach (var neighbourNode in GetNeighbours(currentNode, goal, field))
                {
                    //!!! Если Y уже находится в рассмотренных — пропускаем ее.
                    if (closedSet.Count(node => ((node.Position.X == neighbourNode.Position.X) && (node.Position.Y == neighbourNode.Position.Y))) > 0)
                        continue;
                    var openNode = openSet.FirstOrDefault(node => ((node.Position.X == neighbourNode.Position.X) && (node.Position.Y == neighbourNode.Position.Y)));
                    //!!!  Если Y еще нет в списке на ожидание — добавляем ее туда, запомнив ссылку на X и рассчитав Y.G (это X.G + расстояние от X до Y) и Y.H.
                    if (openNode == null)
                        openSet.Add(neighbourNode);
                    else
                    if (openNode.PathLengthFromStart > neighbourNode.PathLengthFromStart)
                    {
                        //Если же Y в списке на рассмотрение — проверяем, если X.G + расстояние от X до Y < Y.G, 
                        //значит мы пришли в точку Y более коротким путем, заменяем Y.G на X.G + расстояние от X до Y, а точку, из которой пришли в Y на X.
                        openNode.CameFrom = currentNode;
                        openNode.PathLengthFromStart = neighbourNode.PathLengthFromStart;
                    }
                }
            }
            //Если список точек на рассмотрение пуст, 
            //а до цели мы так и не дошли — значит маршрут не существует.
            return null;
        }

        // Функция расстояния от X до Y
        private static int GetDistanceBetweenNeighbours()
        {
            return 1;
        }

        //Функция примерной оценки расстояния до цели
        private static int GetHeuristicPathLength(PathPoint from, PathPoint to)
        {
            return (Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y));
        }

        //Получение списка соседей для точки
        private static List<PathNode> GetNeighbours(PathNode pathNode, PathPoint goal, int[,] field)
        {
            var result = new List<PathNode>();
            // Соседними точками являются соседние по стороне клетки.
            PathPoint[] neighbourPoints = new PathPoint[4];
            neighbourPoints[0] = new PathPoint(pathNode.Position.X - 1, pathNode.Position.Y);
            neighbourPoints[1] = new PathPoint(pathNode.Position.X + 1, pathNode.Position.Y);
            neighbourPoints[2] = new PathPoint(pathNode.Position.X, pathNode.Position.Y - 1);
            neighbourPoints[3] = new PathPoint(pathNode.Position.X, pathNode.Position.Y + 1);
            foreach (var point in neighbourPoints)
            {
                // Проверяем, что не вышли за границы карты.
                if (point.X < 0 || point.X >= field.GetLength(0))
                    continue;
                if (point.Y < 0 || point.Y >= field.GetLength(1))
                {
                    continue;
                }
                // Проверяем, что по клетке можно ходить.!!!
                if ((field[point.X, point.Y] == 2) || (field[point.X, point.Y] == 5))
                    continue;
                // Заполняем данные для точки маршрута.
                var neighbourNode = new PathNode()
                {
                    Position = point,
                    CameFrom = pathNode,
                    PathLengthFromStart = pathNode.PathLengthFromStart + GetDistanceBetweenNeighbours(),
                    HeuristicEstimatePathLength = GetHeuristicPathLength(point, goal)
                };
                result.Add(neighbourNode);
            }
            return result;
        }
        //Получения маршрута. Маршрут представлен в виде списка координат точек
        private static List<PathPoint> GetPathForNode(PathNode pathNode)
        {
            var result = new List<PathPoint>();
            var currentNode = pathNode;
            while (currentNode != null)
            {
                result.Insert(0, currentNode.Position);
                currentNode = currentNode.CameFrom;
            }
            //result.Reverse();
            return result;
        }
    }
}
