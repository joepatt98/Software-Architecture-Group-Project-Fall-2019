namespace SoftwareArch.OSC
{
    struct Item
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public Item(string name, string id, string description, int quantity, float price)
        {
            this.Name = name;
            this.Id = id;
            this.Description = description;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
