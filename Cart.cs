using System.Collections.Generic;

namespace SoftwareArch.OSC
{
    class Cart
    {
        List<Item> itemList;
        private string id;
        private string username;
        private float total;

        public Cart(Item item, string id, string username)
        {
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

        }
    }
}
