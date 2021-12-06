using System.Collections.Generic;

namespace ParkingApp
{
    class UserValidator
    {
        private FileWorkerWithUsers fileWorker = new FileWorkerWithUsers();

        // checks if user exists in file
        public string isExisted(string login, string password)
        {
            List<User> users = fileWorker.readUsers();
            if (users == null)
            {
                return "";
            }
            foreach (User u in users)
            {
                if(u.getLogin()!=null && u.getPassword()!=null && u.getType() != null)
                {
                    if (u.getLogin().Equals(login) && u.getPassword().Equals(password) && u.getType().Equals(Globals.ADMINISTRATOR))
                    {
                        return Globals.ADMINISTRATOR;
                    }

                    if (u.getLogin().Equals(login) && u.getPassword().Equals(password) && u.getType().Equals(Globals.MANAGER))
                    {
                        return Globals.MANAGER;
                    }
                }
            }
            return "";
        }
    }
}
