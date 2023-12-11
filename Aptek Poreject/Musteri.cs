using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptek_Poreject
{
    public class Musteri
    {
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public string MusteriMail { get; set; }
        public string MusteriSifresi { get; set; }
        public string MusteriNomresi { get; set; }


        public Musteri() { }

        public Musteri(string musteriAdi, string musteriSoyadi, string musteriMail, string musteriSifresi, string musteriNomresi)
        {
            MusteriAdi = musteriAdi;
            MusteriSoyadi = musteriSoyadi;
            MusteriMail = musteriMail;
            MusteriSifresi = musteriSifresi;
            MusteriNomresi = musteriNomresi;
        }
    }
    
}
