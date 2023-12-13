namespace Aptek_Poreject
{
    public class Product
    {
        public string PName { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product()
        {
            
        }
        public Product(string pname, string category, double price, int quantity)
        {
            PName = pname;
            Category = category;
            Price = price;
            Quantity = quantity;
        }

        public Product(string dermanadi)
        {
            PName = dermanadi;
        }
    }
}
