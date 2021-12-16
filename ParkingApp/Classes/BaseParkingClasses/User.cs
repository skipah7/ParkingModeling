using System;

namespace ParkingApp
{
    [Serializable]
    class User
    {
        private string login;
        private string password;
        private string type;

        public User(string login, string password, string type)
        {
            this.login = login;
            this.password = password;
            this.type = type;
        }

        public string getLogin()
        {
            return this.login;
        }

        public string getPassword()
        {
            return this.password;
        }

        public void setLogin(string newLogin)
        {
            this.login = newLogin;
        }

        public void setPassword(string newPassword)
        {
            this.password = newPassword;
        }

        public string getType()
        {
            return this.type;
        }

        public void setType(string newType)
        {
            this.type = newType;
        }
    }
}
