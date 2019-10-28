using System;

namespace SoftwareArch.OSC
{
    class Program
    {
        static void Main(string[] args)
        {
            bool logout = false;
            while (!logout)
            {
                Console.WriteLine("Welcome to Generic Online Shopping Center! ");

                Console.Write("Enter your username: ");
                string username;
                username = Console.ReadLine();
                User user = new User(username);
                string name = user.name;
                string cartID = user.cartId;
                Cart cart = new Cart(user.cartId, user);

                Console.WriteLine("Welcome back, " + name + ".  You are using cart " + cartID);

                bool stop = false;

                while (!stop)
                {

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
                            break;
                        case "C":
                            //Cart
                            Console.WriteLine("You are viewing CartID " + cartID);
                            //Displaying current cart
                            cart.DisplayCurrentCart();
                            break;
                        case "I":
                            //Inventory
                            Console.WriteLine("You are viewing the Inventory...");
                            ViewInventory(cart);
                            break;
                        case "Q":
                            logout = true;
                            stop = true;
                            break;
                        default:
                            stop = true;
                            break;
                    }
                }
            }
            Console.ReadKey();
        }

        private static void ViewInventory(Cart cart) {
            Console.WriteLine("Current Items available");
            Inventory inventory = new Inventory();
            inventory.DisplayCurrentInventory();

            Console.Write("View an item? (y/n)");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "y":
                    //continue
                    break;
                case "n":
                    return;
            }

            bool addingItems = true;

            while (addingItems)
            {
                Console.Write("Enter product ID of item to purchase: ");
                string id = Console.ReadLine();
    
                Item item = inventory.GetItemByID(id);

                Console.Write("Add item to cart? (y/n)");
                choice = Console.ReadLine();


                switch (choice)
                {
                    case "y":

                        Console.WriteLine("Adding " + item.Name + " to your cart...");
                        Console.Write("Enter quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        item.Quantity = quantity;
                        cart.AddToCart(item);

                        Console.Write("Add another item to cart? (y/n)");
                        choice = Console.ReadLine();
                        break;
                    case "n":
                        addingItems = false;
                        return;
                }
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
            Console.WriteLine("     'Q' - Logout");
        }
    }
}
