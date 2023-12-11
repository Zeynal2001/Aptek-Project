using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Aptek_Poreject
{
    

    public class Employee
    {
        string musteriPath = "musteriler.xml";

        //string IsciAdi {  get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string IsciMail { get; set; }
        public string IsciSifresii { get; set; }
        public string IsciNomersi { get; set; }

        private List<Musteri> musteriList
        {
            get
            {
                if (File.Exists(musteriPath))
                {
                    return GetMuseteri();
                }
                else
                {
                    return new List<Musteri>();
                }
            }

            set { }
        }

        public Employee()
        {
        }
        public Employee(string fName, string lName ,string isciMail, string isciPassword, string isciPass)
        {
            FName = fName;
            LName = lName;
            IsciMail = isciMail;
            IsciSifresii = isciPassword;
            IsciNomersi = isciPass;
        }


        

        public void AddMusteri()
        {
            Console.WriteLine("Müştərinin adını daxil edin:");
            string musteriAdi = Console.ReadLine();
            Console.WriteLine("Müştərinin soyadını daxil edin: ");
            string musteriSoyadi = Console.ReadLine();
            Console.WriteLine("Müştərinin email adresini daxil edin:");
            string musteriEmail = Console.ReadLine();
            Console.WriteLine("Müştərinin şifrəsini daxil edin:");
            string musteriSifresi = Console.ReadLine();
            Console.WriteLine("Müştərinin nömrəsini daxil edin:");
            string musteriNomresi = Console.ReadLine();

            Musteri musteriobj = new Musteri(musteriAdi, musteriSoyadi, musteriEmail, musteriSifresi, musteriNomresi);
            //Employee isci5 = new Employee(isciAdi, isciSoyadi, isciEmail, isciSifresi, isciNomresi);
            musteriList = GetMuseteri();
            musteriList.Add(musteriobj);
            SaveMusteri();

            //Product yeniproduct = new Product(name: dermanAdi, category: dermanKateqoriya, price: dermaninQiymeti, quantity: dermanMiqdari);
            //listproducts = GetProducts();
            //listproducts.Add(yeniproduct);
            //SaveProduct();
        }

        public void SaveMusteri()
        {
            var file = File.Open(musteriPath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            serializer.Serialize(file, musteriList);
            file.Close();
        }

        public List<Musteri> GetMuseteri()
        {
            if (!File.Exists(musteriPath))
            {
                return new();
            }
            var file = File.OpenRead(musteriPath);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            var listim = (List<Musteri>?)serializer.Deserialize(file);
            file.Close();
            if (listim == null)
            {
                return new List<Musteri>();
            }
            else
            {
                return listim;
            }
        }

        public void SearchMusteri()
        {
            Console.WriteLine("\nAxtardığınız müştərinin adını daxil edin: ");
            string searchName = Console.ReadLine();

            Console.WriteLine("\nAxtardığınız müştərinin soyadını daxil edin: ");
            string searchLastName = Console.ReadLine();

            bool found = false;

            foreach (var item in musteriList)
            {
                if (item.MusteriAdi.ToLower() == searchName.ToLower() && item.MusteriSoyadi.ToLower() == searchLastName.ToLower())
                {
                    found = true;

                    if (item is Musteri musteri)
                    {
                        Console.WriteLine($"Tapildi: Adı: {musteri.MusteriAdi} - Soyadı: {musteri.MusteriSoyadi}, - Mail adresi: {musteri.MusteriMail}, - Şifrəsi: {musteri.MusteriSifresi}, - Nömrəsi: {musteri.MusteriNomresi}");
                    }
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Axtarışa uyğun müştəri tapılmadı.");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
