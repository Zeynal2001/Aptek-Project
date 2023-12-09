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
        

        //string IsciAdi {  get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string IsciMail { get; set; }
        public string IsciSifresii { get; set; }
        public string IsciNomersi { get; set; }


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

        #region Isci
      
        string employeePath = "isciler.xml";
        public List<Employee> listemployees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            Console.WriteLine("İşçinin adını daxil edin:");
            string isciAdi = Console.ReadLine();
            Console.WriteLine("İşçinin soyadını daxil edin: ");
            string isciSoyadi = Console.ReadLine();
            Console.WriteLine("İşçinin email adresini daxil edin:");
            string isciEmail = Console.ReadLine();
            Console.WriteLine("İşçinin şifrəsini daxil edin:");
            string isciSifresi = Console.ReadLine();
            Console.WriteLine("İşçinin nömrəsini daxil edin:");
            string isciNomresi = Console.ReadLine();

            Employee iscim7 = new Employee(fName: isciAdi, lName: isciSoyadi, isciMail: isciEmail, isciPassword: isciSifresi, isciPass: isciNomresi);
            listemployees = GetEmplooyes();
            listemployees.Add(iscim7);
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

        //////public void SearchEmployee()
        //////{
        //////    Console.WriteLine("\nAxtardığınız işçinin adını daxil edin: ");

        //////    string searchName = Console.ReadLine();

        //////    bool found = false;

        //////    foreach (var item in listemployees)
        //////    {
        //////        if (item.LName.ToLower() == searchName.ToLower())
        //////        {
        //////            found = true;

        //////            if (item is )
        //////            {
                        
        //////            }
        //////        } 
        //////    }
        //////}


        #endregion
    }
}
