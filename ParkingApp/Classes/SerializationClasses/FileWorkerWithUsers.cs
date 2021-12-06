using System;
using System.Collections.Generic;
using System.IO;

namespace ParkingApp
{
    class FileWorkerWithUsers
    {
        private List<User> users = null;
        
        private string filePath = "";
        private string fileName = "users.parking";

        public FileWorkerWithUsers()
        {
            filePath = Globals.directory + "\\" + fileName;
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // add users to the list
        public void addUserToFile(User user)
        {
            if (readUsers() == null)
            {
                users = new List<User>();
                users.Add(user);
            }
            else
            {
                users.Add(user);
            }
            // rewrite file
            writeUsers();
        }

        // read users from file
        public List<User> readUsers()
        {
            SerializeClass ser = new SerializeClass(filePath, users);
            if (ser.isCorrectFile())
            {
                try
                {
                    users = (List<User>)ser.Deserialize();
                    ser.Close();
                    return users;
                } catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
            
        }

        // write all users
        public void writeUsers()
        {
            SerializeClass ser = new SerializeClass(filePath, users);
            ser.Serialize();
            ser.Close();
        }
    }
}
