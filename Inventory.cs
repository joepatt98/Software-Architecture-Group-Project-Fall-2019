namespace SoftwareArch.OSC{
    class Inventory{
        private Database databaseConnection;
        public Inventory(){
            databaseConnection = new Database();
        }

        public GetCurrentInventory(){
            string query = string query = "SELECT * FROM item";
            databaseConnection.ExecuteQuery();
        }


    }
}