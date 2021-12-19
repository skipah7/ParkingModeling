using System;
using System.IO;

namespace ParkingApp.Classes
{
    class FileWorkerWithParkingField
    {
        private ParkingField parkingField = null;

        public FileWorkerWithParkingField(ParkingField parkingField, string fileName)
        {
            // parking object for serializing
            this.parkingField = parkingField;
            Globals.parkingFileName = fileName + ".parking";
            Globals.parkingFilePath = Globals.directory + "\\" + Globals.parkingFileName;
            if (!File.Exists(Globals.parkingFilePath))
            {
                File.Create(Globals.parkingFilePath).Close();
            }
        }

        public FileWorkerWithParkingField()
        {
           
        }

        // deserialize parking
        public ParkingField readParkingField()
        {
            SerializeClass ser = new SerializeClass(Globals.parkingFilePath, parkingField);
            if (!ser.isCorrectFile()) return null;
            try
            {
                parkingField = (ParkingField)ser.Deserialize();
                ser.Close();
                return parkingField;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // serialize parking
        public void writeParkingField()
        {
            SerializeClass ser = new SerializeClass(Globals.parkingFilePath, parkingField);
            ser.Serialize();
            ser.Close();
        }
    }
}
