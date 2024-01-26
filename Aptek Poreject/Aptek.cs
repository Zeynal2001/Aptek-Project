using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
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
            var indiki = listproducts;
            indiki.Add(yeniproduct);
            //listproducts = GetProducts();
            SaveProduct(indiki);
            Console.WriteLine("Yeni dərman əlavə edildi.");
        }

        public void SaveProduct(List<Product>? dermanlar = null)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>));
            if (dermanlar != null)
            {
                var file = File.Open(productPath, FileMode.Create);
                xmlSerializer.Serialize(file, dermanlar);
                file.Close();
            }
            else
            {
                var file = File.Open(productPath, FileMode.Create);
                xmlSerializer.Serialize(file, listproducts);
                file.Close();
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                if (!File.Exists(productPath))
                {
                    return new();
                }
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
            var count = 1;
            Console.WriteLine("\nAptekdəki dərmanlar:");
            foreach (var item in listproducts)
            {
                Console.WriteLine($"======Dərman {count}======");
                Console.WriteLine($"Dərmanın adı: {item.PName} - Kateqoriya: {item.Category} - Miqdarı: {item.Quantity} - Qiyməti: {item.Price}");
                count++;
            }
        }

        // TODO: parametr yaradib onun ustunde isleyecek
       //Product dermanobj = new Product();
        public Product? SearchMedicine(string dermanad)
        {
            
            foreach (var derman in listproducts)
            {
                if (derman.PName.ToLower() == dermanad.ToLower())
                {
                    Console.WriteLine($"Tapıldı: Adı: {derman.PName} - Kateqoriyası: {derman.Category}," +
                        $" Qiyməti: {derman.Price}, Miqdarı: {derman.Quantity}");

                    return derman;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Axtarışa uyğun dərman tapılmadı.");
            Console.ForegroundColor = ConsoleColor.White;
            return null;
        }

        public bool DermaniDeyis(int productnum, Product deyisdirilmisD)
        {
            var deyiselecek = listproducts;

            for (int i = 0; i <= deyiselecek.Count; i++)
            {
                if (productnum == (i + 1))
                {
                    var kohnederman = deyiselecek[i];
                    deyisdirilmisD.PName = string.IsNullOrWhiteSpace(deyisdirilmisD.PName) ? kohnederman.PName : deyisdirilmisD.PName;
                    deyisdirilmisD.Category = string.IsNullOrWhiteSpace (deyisdirilmisD.Category) ? kohnederman.Category : deyisdirilmisD.Category;
                    deyisdirilmisD.Price = deyisdirilmisD.Price == 0 ? kohnederman.Price : deyisdirilmisD.Price;
                    deyisdirilmisD.Quantity = deyisdirilmisD.Quantity == 0 ? kohnederman.Quantity : deyisdirilmisD.Quantity;
                    deyiselecek[i] = deyisdirilmisD;
                    SaveProduct(deyiselecek);

                    return true;
                }
            }
            return false;
        }


        public bool RemoveProduct(int silineceknum1)
        {
            var silinecekDermanlar = listproducts;

            for (int i = 0; i < silinecekDermanlar.Count; i++)
            {
                if (silineceknum1 == (i + 1))
                {
                    //silinecekDermanlar[i].Quantity - miqar
                    silinecekDermanlar.RemoveAt(i);
                    SaveProduct(silinecekDermanlar);
                    return true;
                }
            }
            return false;
        }


        public bool DermanAlmaq(int alinacaqnum1, int miqdar1)
        {
            var alinacaqDerman1 = listproducts;

            for (int i = 0; i < alinacaqDerman1.Count; i++)
            {
                if (alinacaqnum1 == (i + 1))
                {
                    if (alinacaqDerman1[i].Quantity >= miqdar1)
                    {
                        //alinacaqDerman[i].Quantity = alinacaqDerman[i].Quantity - miqdar;
                        alinacaqDerman1[i].Quantity -= miqdar1;
                        SaveProduct(alinacaqDerman1); 
                        return true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Dəyər mənfi və ya mövcud miqdardan çox ola bilməz!");
                        Console.ForegroundColor = ConsoleColor.White;
                        return false;
                    }
                }
            }

            return false;
        }


        public bool QiymetCixartmaq(int alinacaqnum2, int miqdar2)
        {
            var alinacaqDerman2 = listproducts;

            for (int i = 0; i < alinacaqDerman2.Count; i++)
            {
                if (alinacaqnum2 == (i + 1))
                {
                    if (alinacaqDerman2[i].Quantity >= miqdar2)
                    {
                        var sum = miqdar2 * alinacaqDerman2[i].Price;
                        Console.WriteLine($"Ödənilməli məbləğ: {sum}");

                        Console.WriteLine("Ödənişi edin/məbləği daxil edin:");
                        double mebleg = double.Parse(Console.ReadLine());
                        if (sum == mebleg)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ödəniş təsdiqləndi.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ödəniş təsdiqlənmədi.");
                            Console.ForegroundColor = ConsoleColor.White;
                            return false;
                        }
                        return true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Daxil edilən dəyər mənfi və ya mövcud miqdardan çox ola bilməz!");
                        Console.ForegroundColor = ConsoleColor.White;
                        return false;
                    }
                }
            }

            return false;
        }

        #endregion
    }
}
