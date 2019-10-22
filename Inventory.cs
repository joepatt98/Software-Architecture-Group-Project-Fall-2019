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

        public SQLiteDataReader GetItemByID(string productID)
        {
            string query = "SELECT * FROM Item WHERE ProductID ='" + productID + "'";
            SQLiteDataReader items = databaseConnection.ExecuteQuery(query);

            if (items.HasRows)
            {
                Console.WriteLine("Item Selected: {0}", items["name"]);
                Console.WriteLine("Description: {0}", items["description"]);
                Console.WriteLine("Quantity: {0}", items["quantity"]);
                return items;
            }
            else
            {
                Console.WriteLine("Item not found");
                Console.WriteLine("Please enter a correct Product ID from the store");
                return GetItemByID(Console.ReadLine());
            }
        }
}