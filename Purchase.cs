using System.Collections.Generic;
using System;
using System.Data.SQLite;

namespace SoftwareArch.OSC
{
    class Purchase
    {
        public string id { get; set; }
        private string userId;
        public float total { get; set; }
        public string creditCardNum { get; set; }
        public string address { get; set; }
        private Database databaseConnection;
        private List<Item> products;

        public Purchase(string id, string userId,string creditCardNum, string address, float total)
        {
            this.id = id;
            this.userId = userId;
            this.creditCardNum = creditCardNum;
            this.address = address;
            this.total = total;
            Database databaseConnection = new Database();
            products = new List<Item>();
        }

        private void GetPurchaseItems()
        {
            databaseConnection.OpenConnection();

            List<Item> items = new List<Item>();

            string query = "SELECT (purchaseID, productID, name, description, PURCHASE_ITEMS.quantity, price) " +
                "FROM PURCHASE_ITEMS, INVENTORY WHERE purchaseID = '" + id + 
                "' JOIN ON PURCHASE_ITEMS.productID=INVENTORY.productID";

            SQLiteDataReader purchaseItems = databaseConnection.ExecuteQuery(query);

            if (purchaseItems.HasRows)
            {
                while (purchaseItems.Read())
                {
                    Item item = new Item(purchaseItems["name"].ToString(), purchaseItems["productID"].ToString(), purchaseItems["description"].ToString(), Convert.ToInt32(purchaseItems["quantity"]), (float)Convert.ToDouble(purchaseItems["price"]));
                    items.Add(item);
                }
            }

            databaseConnection.CloseConnection();
            this.products = items;
        }

        public void DisplayPurchase()
        {
            foreach (Item item in products)
            {
                Console.WriteLine("Name:  {0}  |  Price:  {1}  |  Quanity:  {2}  |  ID:  {3}", item.Name, item.Price, item.Quantity, item.Id);
            }
        }
    }
}

