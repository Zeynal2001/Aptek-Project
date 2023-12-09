using System.Xml.Serialization;

namespace Aptek_Poreject
{
    public class Aptek
    {
        
        string productPath = "produkt.xml";
        public List<Product> listproducts;
        string employeePath = "isciler.xml";
        public List<Employee> listemployees = new List<Employee>();

        Employee isci3 = new Employee();
        public Aptek()
        {
            //Employee isci = new Employee();
            //isci.IsciMail = "zeynal@mail.com";
            //isci.IsciSifresi = "zeynalov";
            //listemployees.Add( isci );
            //SaveEmployees();
            isci3.listemployees = isci3.GetEmplooyes();
            listproducts = GetProducts();
        }

        #region Isci

        //public void AddEmployee(Employee employee)
        //{
        //    Console.WriteLine("İşçinin adını daxil edin:");
        //    string isciAdi = Console.ReadLine();
        //    Console.WriteLine("İşçinin soyadını daxil edin: ");
        //    string isciSoyadi = Console.ReadLine();
        //    Console.WriteLine("İşçinin email adresini daxil edin:");
        //    string isciEmail = Console.ReadLine();
        //    Console.WriteLine("İşçinin şifrəsini daxil edin:");
        //    string isciSifresi = Console.ReadLine();

        //    Employee iscim = new Employee(fName: isciAdi, lName: isciSoyadi, isciMail: isciEmail, isciSifresii: isciSifresi);
        //    isci3.listemployees = isci3.GetEmplooyes();
        //    isci3.listemployees.Add(iscim);
        //    isci3.SaveEmployees();
        //}

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

        public void DisplayDermanlar()
        {
            Console.WriteLine("\nAptekdəki dərmanlar:");
            foreach (var item in listproducts)
            {
                Console.WriteLine($"Dərmanın adı: {item.Name} - Kateqoriya: {item.Category} - Miqdarı: {item.Quantity} - Qiyməti: {item.Price}");
            }
        }

        //public void RemoveProduct(Product product)
        //{
        //    listproducts.Remove(product);
        //}

        //Product derman = new Product();
        #endregion



    }
}
