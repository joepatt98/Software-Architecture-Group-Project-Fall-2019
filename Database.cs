using System.Data.SQLite;
using System.IO;

namespace SoftwareArch.OSC
{
    class Database
    {
        public SQLiteConnection myConnection;
        
        public Database()
        {

            myConnection = new SQLiteConnection("Data Source=C:/Users/maris/Software_Arch_HWK_3/OSC.db;Version=3");
            if (!File.Exists("OSC.db"))
            {
                System.Console.WriteLine("Data file does not exist");
            }
            else
            {
                System.Console.WriteLine("Database found.");
            }
            

        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public SQLiteDataReader ExecuteQuery(string query){
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            SQLiteDataReader result = myCommand.ExecuteReader();
            return result;
        }
        
        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
}