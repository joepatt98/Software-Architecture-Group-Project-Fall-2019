using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SoftwareArch.OSC
{
    class Cart
    {
        List<Item> itemList;
        private string id;
        private User user;
        private float total;
        private Database databaseConnection;

        public Cart(string id, User user)
        {
            databaseConnection = new Database();
            databaseConnection.OpenConnection();

            itemList = new List<Item>();
            this.id = id;
            this.user= user;
            GetTotalPrice();
        }
        public Cart(Item item, string id, User user)
        {
            databaseConnection = new Database();
            databaseConnection.OpenConnection();
            itemList = new List<Item>();

            itemList.Add(item);
            this.id = id;
            this.user = user;
            GetTotalPrice();
        }

        public Cart(List<Item> items, string id, User user)
        {
            databaseConnection = new Database();
            itemList = items;
            this.id = id;
            this.user = user;
        }

        public void AddToCart(Item item)
        {
            databaseConnection.OpenConnection();
            SQLiteDataReader quantity = databaseConnection.ExecuteQuery("SELECT quantity FROM CART_ITEMS WHERE productID = '" + item.Id + "'");
            
            if (quantity.HasRows)
            {
                databaseConnection.ExecuteQuery("UPDATE CART_ITEMS SET quantity = " + (Convert.ToInt32(quantity[0]) + item.Quantity));
            }
            else
            {
                databaseConnection.ExecuteQuery("INSERT INTO CART_ITEMS VALUES (cartID, productID, quantity)" +
                    "('" + id + "','" + item.Id + "'," + item.Quantity +")");
            }
            itemList.Add(item);
            total += item.Price * item.Quantity;
            databaseConnection.CloseConnection();
        }

        public void RemoveFromCart(Item item)
        {
            databaseConnection.OpenConnection();
            SQLiteDataReader quantity = databaseConnection.ExecuteQuery(
                        "SELECT quantity FROM CART_ITEMS WHERE productID = '" + item.Id + "' AND cartID ='" + id + "'"
            );
            int amount = Convert.ToInt32(quantity[0]);
            if (quantity.HasRows)
            {
                if (amount < item.Quantity)
                {
                    databaseConnection.ExecuteQuery(
                        "DELETE FROM CART_ITEMS WHERE productId = '" + item.Id + "' AND cartID ='" + id + "'"
                    ); 
                    //setting this because the quantity of the item to remove should not be higher than 
                    //the amount that exists in the cart
                    item.Quantity = amount; 
                }
                else
                {
                    databaseConnection.ExecuteQuery(
                        "UPDATE CART_ITEMS SET quantity = " + (Convert.ToInt32(quantity[0]) - item.Quantity) + " WHERE productId = '" + item.Id + "' AND cartID = '" + id + "'"
                    );
                }
            }
            else
            {
                Console.WriteLine("ERROR: Cannot remove an item that does not exist in cart.");
            }
                
            itemList.Remove(item);
            total -= item.Price * item.Quantity;
            databaseConnection.CloseConnection();
        }

        public void DisplayCurrentCart()
        {
            foreach (Item item in itemList)
            {
                Console.WriteLine("Name: {0} | Price: {1} | Quantity: {2}", item.Name, item.Price, item.Quantity);
            }

            Console.WriteLine("Total: " + total);
        }

        private float GetTotalPrice()
        {
            float totalPrice = 0;
            foreach(Item item in itemList)
            {
                totalPrice += item.Price * item.Quantity;
            }
            total = totalPrice;
            return totalPrice;
        }

        //TODO: CREATE PURCHASING FUNCTIONALITY
        public void Purchase()
        {
            databaseConnection.OpenConnection();

            string newPurchaseId = Guid.NewGuid().ToString();
            databaseConnection.ExecuteQuery(
                "INSERT INTO PURCHASE (purchaseID, userId, creditCardNumber, address, total) VALUES " +
                "('" + newPurchaseId + "','" + user.userId + "','" + user.creditCardNumber + "','" + user.address + "'" + total + ")"
            );

            foreach (Item item in itemList)
            {
                SQLiteDataReader quantity = databaseConnection.ExecuteQuery("SELECT quantity FROM CART_ITEMS WHERE productID = '" + item.Id + "'");
                int amount = Convert.ToInt32(quantity[0]);

                databaseConnection.ExecuteQuery("DELETE FROM CART_ITEM WHERE productID == (item.Id) (" + item.Id + ")");
                databaseConnection.ExecuteQuery("UPDATE INVENTORY SET quantity = " + (amount - item.Quantity) + "WHERE productID = '" + item.Id + "'");
                databaseConnection.ExecuteQuery("INSERT INTO PURCHASE_ITEM (purchaseId, productId, quantity) VALUES " +
                    "('" + newPurchaseId + "','" + item.Id + "'," + item.Quantity + ")"
                );

            }
            databaseConnection.CloseConnection();
        }

        ~Cart()
        {
            databaseConnection.CloseConnection();
        }
    }
}
