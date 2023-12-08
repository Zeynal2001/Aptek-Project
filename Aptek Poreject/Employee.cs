using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptek_Poreject
{
    public class Employee
    {
        //string IsciAdi {  get; set; }
        public string IsciMail { get; set; }
        public string IsciSifresi { get; set; }

        public Employee()
        {

        }
        public Employee(string iscimail, string iscisifresi)
        {
            IsciMail = iscimail;
            IsciSifresi = iscisifresi;
        }
    }
}
