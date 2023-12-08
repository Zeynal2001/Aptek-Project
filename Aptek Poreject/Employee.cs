using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Aptek_Poreject
{
    public class Employee
    {
        Aptek aptekim = new Aptek();
        string employeePath = "isciler.xml";
        private List<Employee> listemployees = new List<Employee>();

        //string IsciAdi {  get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string IsciMail { get; set; }
        public string IsciSifresi { get; set; }

        public Employee()
        {

        }
        public Employee(string fName, string lName ,string isciMail, string isciSifresii)
        {
            FName = fName;
            LName = lName;
            IsciMail = isciMail;
            IsciSifresi = isciSifresii;
        }

        #region Isci

        //public void AddProduct()
        //{
        //    Console.WriteLine("Dermanin adini adini daxil edin:");
        //    string dermanAdi = Console.ReadLine();
        //    Console.WriteLine("Dermanin daxil oldugu kateqoriyani daxil edin: ");
        //    string dermanKateqoriya = Console.ReadLine();
        //    Console.WriteLine("Dermanin miqdarini daxil edin: ");
        //    int dermanMiqdari = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Dermanin qiymetini daxil edin");
        //    double dermaninQiymeti = double.Parse(Console.ReadLine());

        //    Product yeniproduct = new Product(name: dermanAdi, category: dermanKateqoriya, price: dermaninQiymeti, quantity: dermanMiqdari);
        //    listproducts = GetProducts();
        //    listproducts.Add(yeniproduct);
        //    SaveProduct();
        //}

        public void AddEmployee()
        {
            Console.WriteLine("İşçinin adını daxil edin:");
            string isciAdi = Console.ReadLine();
            Console.WriteLine("İşçinin soyadını daxil edin: ");
            string isciSoyadi = Console.ReadLine();
            Console.WriteLine("İşçinin email adresini daxil edin:");
            string isciEmail = Console.ReadLine();
            Console.WriteLine("İşçinin şifrəsini daxil edin:");
            string isciSifresi = Console.ReadLine();

            Employee iscim = new Employee(fName: isciAdi, lName: isciSoyadi, isciMail: isciEmail, isciSifresii: isciSifresi);
            listemployees = GetEmplooyes();
            listemployees.Add(iscim);
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
        #endregion
    }
}
