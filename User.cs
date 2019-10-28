using System;
using System.Data.SQLite;

namespace SoftwareArch.OSC
{
    class User
    {
        //Do not store passwords please
        public string userId { get; set; }
        public string username { get; set; }
        public string address { get; set; }
        public string creditCardNumber { get; set; }
        public string name { get; set; }
        private bool authenticated = false;

        public void user(string username = "default")
        {
            this.username = username;
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (Authenticate(password))
            {
                AssignUserInfo();
            }
            
        }

        internal void CurrentUser(string username)
        {
            throw new NotImplementedException();
        }

        private bool Authenticate(string password)
        {
            Database databaseConnection = new Database();
            databaseConnection.OpenConnection();

            string usernameQuery = "SELECT * FROM USERS WHERE username = '" + username + "'";
            SQLiteDataReader userResult = databaseConnection.ExecuteQuery(usernameQuery);

            if (userResult.HasRows)
            {

                userResult.Read();
                if (password == userResult["password"].ToString())
                {
                    authenticated = true;
                    databaseConnection.CloseConnection();
                    return true;
                }
                
                else
                {
                    Console.Write("Invalid password. Please retry: ");
                    password = Console.ReadLine();
                    //Currently will retry until valid, no escaping from this though.
                    Authenticate(password);
                    return false;
                }
            }
            else
            {
                Console.Write("Invalid username. Please retry: ");
                this.username = Console.ReadLine();
                //Currently will retry until valid, no escaping from this though.
                Authenticate(password);
                return false;
            }
        }

        private void AssignUserInfo()
        {
            if (!authenticated)
            {
                Console.WriteLine("ERROR: Cannot fetch info for non-authenticated user.");
                return;
            }

            Database databaseConnection = new Database();
            databaseConnection.OpenConnection();

            string usernameQuery = "SELECT * FROM USERS WHERE username = '" + username + "'";
            SQLiteDataReader userResult = databaseConnection.ExecuteQuery(usernameQuery);

            userResult.Read();

            this.address = userResult["address"].ToString();
            this.creditCardNumber = userResult["creditCardNumber"].ToString();
            this.name = userResult["firstName"].ToString() + " " + userResult["middleName"].ToString() + " " + userResult["lastName"].ToString();

            databaseConnection.CloseConnection();

        }
    }
}