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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Yeni işçi əlavə edildi.");
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
            var count = 1;
            Console.WriteLine("\nİşçilər :");
            foreach (var employee in listemployees)
            {
                Console.WriteLine($"======İşçi {count}======");
                Console.WriteLine($"İşçinin adı: {employee.FName} - Soyadı: {employee.LName} - Emaili: {employee.IsciMail} - Şifrəsi: {employee.IsciSifresii} - Nömrəsi: {employee.IsciNomresi}");
                count++;
            }
        }

        
        public Employee? SearchEmployee(string ad, string soyad)
        {
            foreach (var isci in listemployees)
            {
                if (isci.LName.ToLower() == soyad.ToLower() && isci.FName.ToLower() == ad.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Tapildi: Adı: {isci.FName} - Soyadı: {isci.LName}");
                    Console.ForegroundColor = ConsoleColor.White;
                    return isci;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Axtarışa uyğun işçi tapılmadı.");
            Console.ForegroundColor = ConsoleColor.White;
            return null;
        }


        public bool IsciniDeyis(int iscinum, Employee deyisdirilmisI)
        {
            var deyiselecek = listemployees;

            for (int i = 0; i <= deyiselecek.Count; i++)
            {
                if (iscinum == (i + 1))
                {
                    var kohnederman = deyiselecek[i];
                    deyisdirilmisI.FName = string.IsNullOrWhiteSpace(deyisdirilmisI.FName) ? kohnederman.FName : deyisdirilmisI.FName;
                    deyisdirilmisI.LName = string.IsNullOrWhiteSpace(deyisdirilmisI.LName) ? kohnederman.LName : deyisdirilmisI.LName;
                    deyisdirilmisI.IsciMail = string.IsNullOrWhiteSpace(deyisdirilmisI.IsciMail) ? kohnederman.IsciMail : deyisdirilmisI.IsciMail;
                    deyisdirilmisI.IsciSifresii = string.IsNullOrWhiteSpace(deyisdirilmisI.IsciSifresii) ? kohnederman.IsciSifresii : deyisdirilmisI.IsciSifresii;
                    deyisdirilmisI.IsciNomresi = string.IsNullOrWhiteSpace(deyisdirilmisI.IsciNomresi) ? kohnederman.IsciNomresi : deyisdirilmisI.IsciNomresi;
                    deyiselecek[i] = deyisdirilmisI;
                    SaveEmployees(deyiselecek);

                    return true;
                }
            }
            return false;
        }


        public bool RemoveEmployee(int silineceknum)
        {
            var silinecekIsciler = listemployees;

            for (int i = 0; i < silinecekIsciler.Count; i++)
            {
                if (silineceknum == (i + 1))
                {
                    silinecekIsciler.RemoveAt(i);
                    SaveEmployees(silinecekIsciler);
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
