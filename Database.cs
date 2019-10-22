using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace SoftwareArch.OSC
{
    class Database
    {
        public SQLiteConnection myConnection;
        
        public Database()
        {

            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");

                System.Console.WriteLine("Data file created");
            }

            OpenConnection();
            
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
                myConnection.Clone();
            }
        }

        ~Database()
        {
            CloseConnection();
        }
    }
}