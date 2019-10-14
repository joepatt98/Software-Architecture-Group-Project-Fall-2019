using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SQLite;


namespace sqlite_demo
{
    class Adding_to_cart
    {

        static void storefront(string username)
        {


            DataBase databaseObject = new DataBase();

            string user_query = "SELECT * FROM User WHERE username ='" + username + "'";
            SQLiteCommand check_user = new SQLiteCommand(user_query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            SQLiteDataReader user_result = check_user.ExecuteReader();

            if (user_result.HasRows)
            {
                user_result.Read();
                string realname = user_result["name"].ToString();
                string cartID = user_result["cartid"].ToString();

            }

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
            databaseObject.CloseConnection();

            Console.ReadKey();


        }
    }
}
