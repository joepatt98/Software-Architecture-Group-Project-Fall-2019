using System;
using System.Data.SQLite;

namespace SoftwareArch.OSC
{
    class User
    {
        //TODO: ADD ANY MORE USER VARIABLES WE WOULD LIKE TO HAVE
        //Do not store passwords please
        private string username;
        private string address;
        private string creditCardNumber;
        private string name;
        private bool authenticated = false;

        public User(string username = "default")
        {
            this.username = username;
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            if (Authenticate(password))
            {
                AssignUserInfo();
            }
            
        }

        //TODO: We need to decide if this is how we want to store/indicate that the user has been authenticated.
        private bool Authenticate(string password)
        {
            Database databaseConnection = new Database();

            string usernameQuery = "SELECT * FROM USERS WHERE username = '" + username + "'";
            SQLiteDataReader userResult = databaseConnection.ExecuteQuery(usernameQuery);

            if (userResult.HasRows)
            {
                if(password == userResult["password"])
                {
                    authenticated = true;
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid password. Please retry: ");
                    password = Console.ReadLine();
                    //Currently will retry until valid, no escaping from this though.
                    Authenticate(password);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid username. Please retry: ");
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

            string usernameQuery = "SELECT * FROM USERS WHERE username = '" + username + "'";
            SQLiteDataReader userResult = databaseConnection.ExecuteQuery(usernameQuery);

            //TODO: ALTER DATABASE TABLE COLUMNS TO MATCH
            this.address = userResult["address"].ToString();
            this.creditCardNumber = userResult["creditCardNumber"].ToString();
            this.name = userResult["name"].ToString();

        }
    }
}