using System;

namespace SoftwareArch.OSC
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Welcome to Generic Online Shopping Center! ");

            Console.Write("Enter your username: ");
            string username;
            username = Console.ReadLine();
            User user = new User();
            user.user(username);
            string name = "";
            string cartID = "";

            Console.WriteLine("Welcome back, " + name + ".  You are using cart " + cartID);

            DisplayOptions();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "P":
                    //Profile
                    Console.WriteLine("You are viewing your Profile...");
                    Console.WriteLine("Name: " + name);
                    Console.WriteLine("Current CartID: " + cartID);
                    //Viewing purchase history
                    PurchaseHistory purchaseHistory = new PurchaseHistory(user.userId);
                    purchaseHistory.DisplayPurchaseHistory();
                    //Re-showing options
                    DisplayOptions();
                    break;
                case "C":
                    //Cart
                    Console.WriteLine("You are viewing CartID " + cartID);
                    //Displaying current cart
                    Cart cart = new Cart(user.cartId, user);
                    cart.DisplayCurrentCart();
                    break;
                case "I":
                    //Inventory
                    Console.WriteLine("You are viewing the Inventory...");
                    ViewInventory();
                    break;
                default:
                    //Re-show options
                    DisplayOptions();
                    break;
            }
        }

        private static void ViewInventory() {
            Console.WriteLine("Current Items available");
            Inventory inventory = new Inventory();
            inventory.GetCurrentInventory();

            Console.WriteLine("Purchase an item? (y/n)");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "y":
                    //continue
                    break;
                case "n":
                    return;
            }

            Console.WriteLine("Enter product ID of item to purchase: ");
            string id = Console.ReadLine();

            Item item = inventory.GetItemByID(id);

            Console.WriteLine("Add item to cart? (y/n)");

            switch (choice)
            {
                case "y":
                    Console.WriteLine("Adding " + item.Name + " to your cart...");
                    
                    //code for purchasing?
                    break;
                case "n":
                    return;
            }
        }

        private void AddToCart()
        {

        }

        private static void DisplayOptions()
        {
            Console.WriteLine("OPTIONS");
            Console.WriteLine("     'P' - View profile information and purchase history");
            Console.WriteLine("     'C' - View your cart");
            Console.WriteLine("     'I' - View inventory");
        }
    }
}
