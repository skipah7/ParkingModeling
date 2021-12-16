namespace ParkingApp.Classes.BaseParkingClasses
{
    public class TableItem
    {
        public double onParkingTime { get; set; }
        public int placeNumber { get; set; }
        public int totalPrice { get; set; }


        public TableItem(double onParkingTime, int placeNumber, int totalPrice)
        {
            this.onParkingTime = onParkingTime;
            this.placeNumber = placeNumber;
            this.totalPrice = totalPrice;
        }
    }
}