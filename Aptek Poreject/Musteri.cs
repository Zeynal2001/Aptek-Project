using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptek_Poreject
{
    public class Musteri
    {
        public string MusteriMail { get; set; }
        public string MusteriSifresi { get; set; }

        public Musteri() { }

        public Musteri(string musterimail, string musterisifresi)
        {
            MusteriMail = musterimail;
            MusteriSifresi = musterisifresi;
        }
    }
    
}
