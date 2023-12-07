using System.Xml.Serialization;

namespace Aptek_Poreject
{
    public class Aptek
    {
        string employeePath = "isciler.xml";
        string productPath = "produkt.xml";
        private List<Employee> listemployees = new List<Employee>();
        public List<Product> listproducts;


        public Aptek()
        {
            //Employee isci = new Employee();
            //isci.Iscimail = "zeynal@mail.com";
            //isci.IsciSifresi = "zeynalov";
            //listemployees.Add( isci );
            //SaveEmployees();
            listproducts = GetProducts();
        }

        #region Isci
        public void AddEmployee(Employee employee)
        {
            listemployees = GetEmplooyes();
            listemployees.Add(employee);
            SaveEmployees();
        }

        public void SaveEmployees()
        {
            var file = File.Open(employeePath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            serializer.Serialize(file, listemployees);
            file.Close();
        }

        public List<Employee> GetEmplooyes()
        {
            var file = File.OpenRead(employeePath);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            var listim = (List<Employee>?)serializer.Deserialize(file);
            file.Close();
            if (listim == null)
            {
                return new List<Employee>();
            }
            else
            {
                return listim;
            }
        }

        //Product derman = new Product();
        public void DisplayDermanlar()
        {
            Console.WriteLine("\nAptekdəki dərmanlar:");
            foreach (var item in listproducts)
            {
                Console.WriteLine($"Dərmanın adı: {item.Name} - Kateqoriya: {item.Category} - Miqdarı: {item.Quantity} - Qiyməti: {item.Price}");
            }
        }
        #endregion


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

            Product yeniproduct = new Product(name:dermanAdi, category:dermanKateqoriya, price:dermaninQiymeti, quantity:dermanMiqdari);
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

        //public void RemoveProduct(Product product)
        //{
        //    listproducts.Remove(product);
        //}
        #endregion
        
    }
}
