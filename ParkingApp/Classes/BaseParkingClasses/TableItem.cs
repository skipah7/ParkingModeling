namespace ParkingApp.Classes.BaseParkingClasses
{
    public class TableItem
    {
        public int placeNumber { get; set; }
        public string arrivalTime { get; set; }
        public double parkingTime { get; set; }
        public int totalPrice { get; set; }


        public TableItem(int placeNumber, string arrivalTime, double parkingTime,  int totalPrice)
        {
            this.placeNumber = placeNumber;
            this.arrivalTime = arrivalTime;
            this.parkingTime = parkingTime;
            this.totalPrice = totalPrice;
        }
    }
}