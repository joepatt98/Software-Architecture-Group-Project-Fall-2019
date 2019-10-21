//Needs to be modularized
//Add to cart function incomplete
//Need proper return statements
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SQLite; 

namespace sqlite_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //THIS OPENS DATA BASE
            DataBase databaseObject = new DataBase();

            string pass_wrd = "Empty";
            string password = "CLEAR";
            string user_check = "User not found..";
            string username = "default";
            bool querycheck = false;
            string realname = "Guest";
            Console.WriteLine("Welcome to Generic Online Shopping Center! ");


            //The beginnging
            Console.WriteLine("Please enter your username(Press 0 to enter as guest)");
            username = Console.ReadLine();

            if (username == "0")
            {
                Console.WriteLine("Continuing as Guest");
                querycheck = true;
                password = pass_wrd;
                user_check = "-------------------------";
            }

            //search for user
            string user_query = "SELECT * FROM User WHERE username ='" + username + "'";
            SQLiteCommand check_user = new SQLiteCommand(user_query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            SQLiteDataReader user_result = check_user.ExecuteReader();

            while (querycheck == false)
            {

                if (user_result.HasRows)
                {
                    user_check = "User found";
                    user_result.Read();
                    pass_wrd = (string)user_result["password"];
                    string pass_check = user_result["password"].ToString();
                    realname = user_result["name"].ToString();
                    querycheck = true;

                }
                else
                {
                    Console.WriteLine(user_check);
                    Console.WriteLine("Please enter a correct username");
                    username = Console.ReadLine();
                    user_query = "SELECT * FROM User WHERE username ='" + username + "'";
                    check_user = new SQLiteCommand(user_query, databaseObject.myConnection);
                    databaseObject.OpenConnection();
                    user_result = check_user.ExecuteReader();
                }
            }

            Console.WriteLine(user_check);

            while (password != pass_wrd)
            {
                Console.WriteLine("Please enter the correct password for the username {0}", username);
                password = Console.ReadLine();
            }

            //THIS NEEDS TO BE A DIFFERENT FUNCTION
            //static void store_front(string username)

            string store_query = "SELECT * FROM User WHERE username ='" + username + "'";
            SQLiteCommand check_store = new SQLiteCommand(store_query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            SQLiteDataReader store_result = check_store.ExecuteReader();

            string real_name = "Guest";
            string cartID = "none";
            if (store_result.HasRows)
            {
                store_result.Read();
                real_name = store_result["name"].ToString();
                cartID = store_result["cartid"].ToString();

            }

            Console.WriteLine("Welcome back, " + real_name + ".  You are using cart " + cartID);

            Console.WriteLine("Current Items available");

            string query = "SELECT * FROM item";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();


            SQLiteDataReader result = myCommand.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                    Console.WriteLine("Name:  {0}  |  Price:  {1}  |  Quanity Available:  {2}  |  Type:  {3}", result["name"], result["price"], result["quanity"], result["Type"]);

            }

            Console.WriteLine("Please enter the Product ID of the item you wish to purchase: ");
            Console.WriteLine("Press 'Q' to view and edit your profile information and 'C' to view your cart");

            string item_choice = Console.ReadLine();

            //Searches for item:

            //declare variables

            string item_name = "blank";
            string selection = "32";
            var quanity = 0;
            string item_found = "Item not found";
            string item_confirm = "9";
            string item_descrip = "...";
            bool item_check = false;
            string item_query = "SELECT * FROM Item WHERE ProductID ='" + item_choice + "'";
            SQLiteCommand check_item = new SQLiteCommand(item_query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            SQLiteDataReader item_result = check_item.ExecuteReader();

            if (item_choice == "Q")
            {
                string profile_query = "SELECT * FROM User WHERE username ='" + username + "'";
                SQLiteCommand profile_view = new SQLiteCommand(profile_query, databaseObject.myConnection);
                databaseObject.OpenConnection();

                SQLiteDataReader result_profile = profile_view.ExecuteReader();

                Console.WriteLine("Viewing your profile....");
                if (result_profile.HasRows)
                {
                    while (result_profile.Read())
                        Console.WriteLine("Username:  {0}     \n1. Real Name:  {1}      \n2. Address:  {2}\n3. Payment:  {3}      \n4. Phone Number:  {4}     ", result_profile["username"], result_profile["name"], result_profile["addr"], result_profile["payment"], result_profile["phone"], result_profile);

                }
                Console.WriteLine("\nPress 1-4 to edit profile fields.  And 'K' to view purchase history ");
                
                string name_user_choice;
                string addr_user_choice;
                string pay_user_choice;
                string phone_user_choice;
                string profile_choice = Console.ReadLine();

                if (profile_choice == "2")
                {

                    Console.WriteLine("Choose enter new Address...");
                    addr_user_choice = Console.ReadLine();
                    Console.WriteLine("Field updated...");
                    string update_db_user2 = "UPDATE User SET addr = '" + addr_user_choice + "' WHERE username = '" + username +"'";
                    SQLiteCommand updating_addr = new SQLiteCommand(update_db_user2, databaseObject.myConnection);
                    var updater2 = updating_addr.ExecuteNonQuery();
                    databaseObject.OpenConnection();
                    Console.WriteLine();



                }
                if (profile_choice == "3")
                {

                    Console.WriteLine("Choose enter new payment method...");
                    pay_user_choice = Console.ReadLine();
                    Console.WriteLine("Field updated...");
                    string update_db_user3 = "UPDATE User SET payment = '" + pay_user_choice + "' WHERE username = '" + username + "'";
                    Console.WriteLine(update_db_user3);
                    SQLiteCommand updating_payment = new SQLiteCommand(update_db_user3, databaseObject.myConnection);
                    databaseObject.OpenConnection();
                    Console.WriteLine();

                }
                if (profile_choice == "4")
                {

                    Console.WriteLine("Choose enter new phone...");
                    phone_user_choice = Console.ReadLine();
                    Console.WriteLine("Field updated...");
                    string update_db_user = "UPDATE User SET phone = '" + phone_user_choice + "' WHERE username = '" + username + "'";
                    SQLiteCommand updating_phone = new SQLiteCommand(update_db_user, databaseObject.myConnection);
                    var updater4 = updating_phone.ExecuteNonQuery();
                    databaseObject.OpenConnection();
                    Console.WriteLine();

                }
                if (profile_choice == "1")
                {
                    Console.WriteLine("Choose enter new name...");
                    name_user_choice = Console.ReadLine();
                    Console.WriteLine("Field updated...");
                    string update_db_user = "UPDATE User SET name = '" + name_user_choice + "' WHERE username = '" + username + "'";
                    SQLiteCommand updating_username = new SQLiteCommand(update_db_user, databaseObject.myConnection);
                    var updater2 = updating_username.ExecuteNonQuery();
                    databaseObject.OpenConnection();
                    Console.WriteLine();
                }
                databaseObject.CloseConnection();
                Console.ReadKey();
            }

            while (item_check == false)

                if (item_result.HasRows)
                {
                    item_found = "Item selected: ";
                    item_result.Read();
                    item_name = (string)item_result["name"];
                    item_descrip = (string)item_result["description"];
                    quanity = Convert.ToInt32(item_result["quanity"]);


                    //string pass_check = user_result["password"].ToString()
                    item_check = true;

                }
                else
                {
                    Console.WriteLine(item_found);
                    Console.WriteLine("Please enter a correct Product ID from the store");
                    item_choice = Console.ReadLine();
                    item_query = "SELECT * FROM Item WHERE ProductID ='" + item_choice + "'";
                    check_item = new SQLiteCommand(item_query, databaseObject.myConnection);
                    databaseObject.OpenConnection();
                    item_result = check_user.ExecuteReader();
                }

            Console.WriteLine(item_found + item_name);
            Console.WriteLine("Description: " + item_descrip);
            Console.WriteLine("Amount: " + quanity);

            while (item_confirm != "Y"  && item_confirm != "N")
            {
                Console.WriteLine("Add " + item_name + " to cart? (Y/N)");
                item_confirm = Console.ReadLine();
            }

            if (item_confirm == "Y")
            {
                Console.WriteLine("Adding " + item_name + " to your cart...");
                if (quanity == 0)
                {
                    Console.WriteLine("Sorry, this item is sold out.");
                    //Call the function to reset the store front
                }
                else
                {
                    //UPDATE THE ITEM DATA BASE
                    Console.WriteLine("Item added!");
                    string update_db = "UPDATE Item SET quanity = quanity - 1 WHERE ProductID = " + item_choice;
                    SQLiteCommand updating_items = new SQLiteCommand(update_db, databaseObject.myConnection);
                    var updater = updating_items.ExecuteNonQuery();

                    //UPDATE THE CART DATA BASE
                    //INCOMPLETE
                    //string update_cart = "INSERT INTO cart where cartID = " + cartID +" and "
                    Console.WriteLine();
                    databaseObject.OpenConnection();

                }
            }
           if(item_confirm == "N")
            {
                Console.WriteLine("Canceled!");
                //recall the storefront function from the beginning
            }

            //This is the end 

            databaseObject.CloseConnection();

            Console.ReadKey();
        }
    }
}
