using System.Collections.Generic;

namespace SoftwareArch.OSC
{
    class Cart
    {
        List<Item> itemList;
        private string id;
        private string username;
        private float total;
        private Database databaseConnection;

        public Cart(Item item, string id, string username)
        {
            databaseConnection = new Database();
            databaseConnection.OpenConnection();
            itemList = new List<Item>();

            itemList.Add(item);
            this.id = id;
            this.username = username;
            GetTotalPrice();
        }

        public Cart(List<Item> items, string id, string username)
        {
            itemList = items;
            this.id = id;
            this.username = username;
        }

        public void AddToCart(Item item)
        {
            databaseConnection.ExecuteQuery("INSERT INTO Cart_Items VALUES (cartID, productID) (" + id + "," + item.Id + ")");
            itemList.Add(item);
            total += item.Price;
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
        private void Purchase()
        {
            foreach (Item item in itemList)
            {
                databaseConnection.ExecuteQuery("DELETE productID WHERE productID == (item.Id) (" + item.Id + ")");
            }
        }

        ~Cart()
        {
            databaseConnection.CloseConnection();
        }
    }
}
