using System;
using System.Data.SQLite;
using System.Collections.Generic;

namespace SoftwareArch.OSC{
    class Inventory
    {
        private Database databaseConnection;
        private List<Item> inventoryList;

        public Inventory()
        {
            databaseConnection = new Database();
            inventoryList = GetCurrentInventory();
        }

        public List<Item> GetCurrentInventory()
        {
            List<Item> items = new List<Item>();

            databaseConnection.OpenConnection();

            string query = "SELECT * FROM INVENTORY";
            SQLiteDataReader result = databaseConnection.ExecuteQuery(query);

            if (result.HasRows)
            {
                while (result.Read())
                {
                    Item item = new Item(result["name"].ToString(), result["productID"].ToString(), result["description"].ToString(), Convert.ToInt32(result["quantity"]), (float)Convert.ToDouble(result["price"]));
                    items.Add(item);
                }
            }

            databaseConnection.CloseConnection();
            return items;
        }

        public void DisplayCurrentInventory()
        {
            foreach (Item item in inventoryList){
                Console.WriteLine("Name:  {0}  |  Price:  {1}  |  Quanity Available:  {2}  |  ID:  {3}", item.Name, item.Price, item.Quantity, item.Id);
            }
        }

        public Item GetItemByID(string productID)
        {
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM INVENTORY WHERE productID ='" + productID + "'";
            SQLiteDataReader result = databaseConnection.ExecuteQuery(query);
            
            if (result.HasRows)
            {
                result.Read();
                Item item = new Item(result["name"].ToString(), result["productID"].ToString(), result["description"].ToString(), (int)result["quantity"], (float)Convert.ToDouble(result["price"]));

                Console.WriteLine("Item Selected: {0}", item.Name);
                Console.WriteLine("Description: {0}", item.Description);
                Console.WriteLine("Quantity: {0}", item.Quantity);

                databaseConnection.CloseConnection();
                return item;
            }
            else
            {

                Console.WriteLine("Item not found");
                Console.WriteLine("Please enter a correct product ID from the store");
                productID = Console.ReadLine();
                databaseConnection.CloseConnection();
                return GetItemByID(productID);
            }
        }
    }
}