using System.Xml.Serialization;

namespace Aptek_Poreject
{
    public class Aptek
    {
        string path = "isciler.xml";
        private List<Employee> listemployees = new List<Employee>();

        public Aptek()
        {
            //Employee isci = new Employee();
            //isci.Iscimail = "zeynal@mail.com";
            //isci.IsciSifresi = "zeynalov";
            //listemployees.Add( isci );
            //SaveEmployees();
        }

        public void AddEmployee(Employee employee)
        {
            listemployees = GetEmplooyes();
            listemployees.Add(employee);
            SaveEmployees();
        }

        private void SaveEmployees()
        {
            var file = File.Open(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            serializer.Serialize(file, listemployees);
            file.Close();
        }

        public List<Employee> GetEmplooyes()
        {
            var file = File.OpenRead(path);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
             var listim = (List<Employee>?)serializer.Deserialize(file);
            file.Close();
            if (listim == null )
            {
                return new List<Employee>();
            }
            else
            {
                return listim; 
            }
        }
    }
}
