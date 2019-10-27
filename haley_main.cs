using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SQLite; 

namespace SoftwareArch.OSC
{
    class CheckUser
    {
        static void CheckUser(string[] args)
        {
            // Connecting to the database
            databaseConnection = new Database();
            
            // Varible for queries
            queryCheck = false;
            
            Console.WriteLine("Please enter your username. (Press 0 to enter as guest)");
            username = Console.ReadLine();
            
            // Check for correct username and password against database
            // If not correct, keep asking until correct
            // If Guest, also allow access
            
            // Database query for correct username
            string usernameQuery = "SELECT * FROM User WHERE username = ' + username +'";
            databaseConnection.ExecuteQuery(usernameQuery);
            
            // Database query for correct password
            string passwordQuery = "SELECT * FROM User WHERE password = ' + password +'"; 
            databaseConnection.ExecuteQuery(passwordQuery)     
                
            // Guest access    
            if (username == "0")
            {
                Console.WriteLine("Continuing as Guest...");
                queryCheck = true;
            }
            
            while (queryCheck == false)
            {
                if (username == usernameQuery) 
                {   
                    // go on to input password
                    queryCheck = true;
                    Console.WriteLine("Pleae enter your password.")
                }
                else 
                {
                    Console.WriteLine("Please enter a correct username.")
                }
            }
            
            queryCheck = false; // change to false to check for password correctness
            
            while (queryCheck == false) 
            {
                if (password == passwordQuery)
                {
                    // go on to Welcome page
                    queryCheck = true;
                }
                else 
                {
                    Console.WriteLine("Please enter a correct password.")
                }
            }
        }
    }
    
    class StoreFront
    {
        private databaseConnection = new Database();
        public StoreFront(string username){
            
        }
        static void Options() 
        {
            // This function displays the options and navigation             
            // 1) Inventory (to build cart)
            // 2) Order History
            // 3) Logout
        }
        
        static void AddToCart()
        {
            // add by itemId
        }
        
        static void RemoveFromCart()
        {
            // removed by itemId
        }
        
        static void ViewCurrentCart()
        {
            // Displays what is currently in the cart
            // use itemId + details
        }
        
        static void Purchase()
        {
            // Get shipping address from input or database
            // Database query for shipping address
            // Make selectable
            string addressQuery = "SELECT * FROM User WHERE address = ' + address +'"; 
            databaseConnection.ExecuteQuery(addressQuery); 
            
            
            // Get credit card number from user
            Console.WriteLine("Please enter your credit card number.");
            address = Console.ReadLine();
            
            // User confirms purchase
        }
        
        static void UpdateInventory()
        {
            // Updated after a confirmed purchase
        }
        
        static void ViewOrderHistory()
        {
            // Purchases must be stored between uses
            // User has ability to view past purchase
        }
        
        static void LogoutUser()
        {
            
        }
    }
}
