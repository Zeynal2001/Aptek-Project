using System.Xml.Serialization;

namespace Aptek_Poreject
{
    public class Admin
    {
        public string AdminFName { get; set; }
        public string AdminLName { get; set; }
        public string AdminMail { get; set; }
        public string AdminPassword { get; set; }
        public string AdminNum { get; set; }

        public Admin(string adminAdi, string adminSoyadi, string adminMaili, string adminSifresi, string adminNomresi)
        {
            AdminFName = adminAdi;
            AdminLName = adminSoyadi;
            AdminMail = adminMaili;
            AdminPassword = adminSifresi;
            AdminNum = adminNomresi;
        }

        string employeePath = "isciler.xml";
        private List<Employee> _isciler;
        public List<Employee> listemployees           //= new List<Employee>();
        {
            get
            {
                if (File.Exists(employeePath))
                {
                    return GetEmplooyes();
                }
                else
                {
                    return new List<Employee>();
                }
            }

            set
            {
                _isciler = value;
            }
        }

        public Admin()
        {
            listemployees = GetEmplooyes();
        }


        #region Isci/Admin

        public void AddEmployee(Employee employee)
        {
            //if (File.Exists(employeePath))
            //{
            //    listemployees = GetEmplooyes();
            //}

            var hazirki = listemployees;
            hazirki.Add(employee);
            SaveEmployees(hazirki);
        }
        public void SaveEmployees(List<Employee>? isciler = null)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            if (serializer != null)
            {
                var file = File.Open(employeePath, FileMode.Create);
                serializer.Serialize(file, isciler);
                file.Close();
            }
            else
            {
                var file = File.Open(employeePath, FileMode.Create);
                serializer.Serialize(file, listemployees);
                file.Close();
            }
        }

        public List<Employee> GetEmplooyes()
        {
            if (!File.Exists(employeePath))
            {
                return new();
            }
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

        public void DisplayEmploye()
        {
            foreach (var employee in listemployees)
            {
                Console.WriteLine($"İşçinin adı: {employee.FName} - Soyadı: {employee.LName} - Emaili: {employee.IsciMail} - Şifrəsi: {employee.IsciSifresii} - Nömrəsi: {employee.IsciNomersi}");
            }
        }

        public void SearchEmployee()
        {
            Console.WriteLine("\nAxtardığınız işçinin adını daxil edin: ");
            string searchName = Console.ReadLine();

            Console.WriteLine("\nAxtardığınız işçinin soyadını daxil edin: ");
            string searchLastName = Console.ReadLine();

            bool found = false;

            foreach (var item in listemployees)
            {
                if (item.LName.ToLower() == searchName.ToLower() && item.LName.ToLower() == searchLastName.ToLower())
                {
                    found = true;

                    if (item is Employee isci)
                    {
                        Console.WriteLine($"Tapildi: Adı: {isci.LName} - Soyadı: {isci.LName}");
                    }
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Axtarışa uyğun işçi tapılmadı.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        #endregion
    }
}
