using System.Dynamic;
using System.Xml.Serialization;

namespace Aptek_Poreject
{
    public class Aptek
    {
        //string adminPath = "admin.xml";

        string productPath = "produkt.xml";
        private List<Product> _products;
        public List<Product> listproducts
        {
            get
            {
                if (File.Exists(productPath))
                {
                    return GetProducts();
                }
                else
                {
                    return new List<Product>();
                }
            }
            set
            {
                _products = value;
            }
        }

        

        Employee isci3 = new Employee();
        public Aptek()
        {
            //Employee isci = new Employee();
            //isci.IsciMail = "zeynal@mail.com";
            //isci.IsciSifresi = "zeynalov";
            //listemployees.Add( isci );
            //SaveEmployees();
            //if (File.Exists(employeePath))
            //{
            //    listemployees = GetEmplooyes();
            //}
            listproducts = GetProducts();
        }


        #region Product/Derman

        //Product üçün metodlar

        public void AddProduct()
        {
            Console.WriteLine("Dermanin adini adini daxil edin:");
            string dermanAdi = Console.ReadLine();
            Console.WriteLine("Dermanin daxil oldugu kateqoriyani daxil edin: ");
            string dermanKateqoriya = Console.ReadLine();
            Console.WriteLine("Dermanin miqdarini daxil edin: ");
            int dermanMiqdari = int.Parse(Console.ReadLine());
            Console.WriteLine("Dermanin qiymetini daxil edin");
            double dermaninQiymeti = double.Parse(Console.ReadLine());

            Product yeniproduct = new Product(pname:dermanAdi, category:dermanKateqoriya, price:dermaninQiymeti, quantity:dermanMiqdari);
            listproducts = GetProducts();
            listproducts.Add(yeniproduct);
            SaveProduct();
        }

        public void SaveProduct()
        {
            var file = File.Open(productPath, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>));
            xmlSerializer.Serialize(file, listproducts);
            file.Close();
        }

        public List<Product> GetProducts()
        {
            try
            {
                Console.WriteLine();
                var file = File.OpenRead(productPath);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>));
                var productlistim = (List<Product>?)xmlSerializer.Deserialize(file);
                file.Close();
                if (productlistim == null)
                {
                    return new List<Product>();
                }
                else
                {
                    return productlistim;
                }
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public void DisplayDermanlar()
        {
            Console.WriteLine("\nAptekdəki dərmanlar:");
            foreach (var item in listproducts)
            {
                Console.WriteLine($"Dərmanın adı: {item.PName} - Kateqoriya: {item.Category} - Miqdarı: {item.Quantity} - Qiyməti: {item.Price}");
            }
        }


        public void SearchMedicine()
        {
            Console.WriteLine("\nAxtardığınız dərmanın adını daxil edin: ");
            string searchPName = Console.ReadLine();


            bool found = false;

            foreach (var item in listproducts)
            {
                if (item.PName.ToLower() == searchPName.ToLower())
                {
                    found = true;

                    if (item is Product derman)
                    {
                        Console.WriteLine($"Tapildi: Adı: {derman.PName} - Kateqoriya: {item.Category} - Miqdarı: {item.Quantity} - Qiyməti: {item.Price}");
                    }
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Axtarışa uyğun dərman tapılmadı.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void RemoveProduct(Product product)
        {
            listproducts.Remove(product);
        }

        #endregion
    }
}
