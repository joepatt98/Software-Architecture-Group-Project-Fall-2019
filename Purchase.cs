// Class to create the purchase object

namespace SoftwareArch.OSC
{
    class Purchase
    {
        private string item;
        private float price;
        private string creditCardNum;
        private string address;
        private string username;

        public Purchase(string item, float price, string creditCardNum, string address, string username)
        {
            this.item = item;
            this.price = price;
            this.creditCardNum = creditCardNum;
            this.address = address;
            this.username = username;
        }
    }
}

