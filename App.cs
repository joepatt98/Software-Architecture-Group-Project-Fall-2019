//TODO: TEST
using System;

namespace SoftwareArch.OSC
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Welcome to Generic Online Shopping Center! ");

            //TODO: INSERT LOGIN STUFF\
            Console.Write("Enter your username: ");
            string usern;
            usern = Console.ReadLine();
            User authent = new User();
            authent.user(usern);
            //Console.Write("Enter your password: ");
            //string passw;
            //passw = Console.RealLine();
            //TODO: DECIDE FLOW OF MAIN CONSOLE
            string name = "";
            string cartID = "";

            Console.WriteLine("Welcome back, " + name + ".  You are using cart " + cartID);

            DisplayOptions();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "P":
                    //Profile
                    break;
                case "C":
                    //Cart
                    break;
                case "I":
                    ViewInventory();
                    break;
                default:
                    //Re-show options
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
            Console.WriteLine("     'P' - View, edit profile information");
            Console.WriteLine("     'C' - View your cart");
            Console.WriteLine("     'I' - View inventory");
        }
    }
}
