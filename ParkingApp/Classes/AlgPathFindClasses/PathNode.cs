namespace ParkingApp.Classes.AlgPathFind
{
    class PathNode
    {
        // coordinates on map
        public PathPoint Position {get; set;}

        // length of the path from start (G).
        public int PathLengthFromStart {get; set;}

        // reference to the point, from which we came to this point
        public PathNode CameFrom { get; set; }

        // roughly distance to the target (H).
        public int HeuristicEstimatePathLength { get; set; }

        // expected full distance to the target (F).
        public int EstimateFullPathLength
        {
            get
            {
                return this.PathLengthFromStart + this.HeuristicEstimatePathLength;
            }
        }
    }
}
