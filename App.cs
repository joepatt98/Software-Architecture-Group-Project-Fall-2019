//Needs to be modularized
//Add to cart function incomplete
//Need proper return statements
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SQLite; 

namespace SoftwareArch.OSC
{
    class Program
    {
        static void Main(string[] args)
        {
            //login stuff here   

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

            SQLiteDataReader item = inventory.GetItemByID(id);

            Console.WriteLine("Add item to cart? (y/n)");

            switch (choice)
            {
                case "y":
                    Console.WriteLine("Adding " + item["name"] + " to your cart...");
                    //code for purchasing?
                    break;
                case "n":
                    return;
            }
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
