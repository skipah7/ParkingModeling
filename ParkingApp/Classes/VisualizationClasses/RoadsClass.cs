using System.Windows.Forms;

namespace ParkingApp.Classes
{
    class RoadsClass
    {
        public void createRoads(Panel panel1)
        {
            AdjacentRoadClass roadClass = new AdjacentRoadClass();
            roadClass.createDownAdjacentRoad(panel1);
        }
    }
}
