using System.Collections.Generic;
using System;
using System.Data.SQLite;

namespace SoftwareArch.OSC
{
    class PurchaseHistory
    {
        List<Purchase> purchases;
        private string userId;
        private Database databaseConnection;

        public PurchaseHistory(string userId)
        {
            databaseConnection = new Database();
            this.userId = userId;
            purchases = new List<Purchase>();
            GetPurchaseHistory();
        }

        public void DisplayPurchaseHistory()
        {
            foreach(Purchase purchase in purchases)
            {
                Console.WriteLine("ID:  {0}  |  Total:  {1}  |  Address:  {2}  |  CCN:  {3}", purchase.id, purchase.total, purchase.address, purchase.creditCardNum);

            }
        }

        private void GetPurchaseHistory()
        {
            databaseConnection.OpenConnection();

            List<Item> items = new List<Item>();

            string query = "SELECT * FROM PURCHASE WHERE userId = '" + userId + "'";
            SQLiteDataReader purchaseHistory = databaseConnection.ExecuteQuery(query);

            if (purchaseHistory.HasRows)
            {
                while (purchaseHistory.Read())
                {
                    Purchase purchase = new Purchase(
                            purchaseHistory["purchaseId"].ToString(), 
                            userId,
                            purchaseHistory["creditCardNumber"].ToString(),
                            purchaseHistory["address"].ToString(),
                            (float)Convert.ToDouble(purchaseHistory["total"]));
                    purchases.Add(purchase);
                }
            }

            databaseConnection.CloseConnection();
            return;
        }
    }
}

