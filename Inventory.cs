using System;
using System.Data.SQLite;

namespace SoftwareArch.OSC{
    class Inventory{
        private Database databaseConnection;
        public Inventory(){
            databaseConnection = new Database();
        }

        public void GetCurrentInventory(){
            string query = "SELECT * FROM item";
            SQLiteDataReader items = databaseConnection.ExecuteQuery(query);

            if (items.HasRows)
            {
                while (items.Read())
                {
                    Console.WriteLine("Name:  {0}  |  Price:  {1}  |  Quanity Available:  {2}  |  Type:  {3}", items["name"], items["price"], items["quanity"], items["Type"]);
                }
            }


        }

        public void GetItemByID(string productID)
        {
            string query = "SELECT * FROM Item WHERE ProductID ='" + productID + "'";
            SQLiteDataReader item = databaseConnection.ExecuteQuery(query);
        }
}