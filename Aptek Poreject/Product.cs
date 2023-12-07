namespace Aptek_Poreject
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product()
        {
            
        }
        public Product(string name, string category, double price, int quantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
    }
}
