using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string IsciNomresi { get; set; }

        private List<Musteri> _musteriler;

        [XmlIgnore]
        public List<Musteri> musteriList
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

            set
            {
                _musteriler = value;
            }
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
            IsciNomresi = isciPass;
        }



        #region Musteri
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
            var indiki = musteriList;
            indiki.Add(musteriobj);
            SaveMusteri(indiki);
            Console.WriteLine("Yeni müştəri əlavə edildi.");
            //Product yeniproduct = new Product(name: dermanAdi, category: dermanKateqoriya, price: dermaninQiymeti, quantity: dermanMiqdari);
            //listproducts = GetProducts();
            //listproducts.Add(yeniproduct);
            //SaveProduct();
        }

        public void SaveMusteri(List<Musteri>? musteris = null)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Musteri>));
            if (musteris != null)
            {
                var file = File.Open(musteriPath, FileMode.Create);
                serializer.Serialize(file, musteris);
                file.Close();   
            }
            else
            {
                var file = File.Open(musteriPath, FileMode.Create);
                serializer.Serialize(file, musteriList);
                file.Close();
            }
        }

        public List<Musteri> GetMuseteri()
        {
            if (!File.Exists(musteriPath))
            {
                return new();
            }
            var file = File.OpenRead(musteriPath);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Musteri>));
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

        public void DisplayMusteri()
        {
            var count = 1;
            Console.WriteLine("\nQeydiyyatdan keçmiş müştərilər:");
            foreach (var musterim1 in musteriList)
            {
                Console.WriteLine($"======İstifadəçi {count}======");
                Console.WriteLine($"Müştərinin adı: {musterim1.MusteriAdi} - Soyadı: {musterim1.MusteriSoyadi} - Emaili: {musterim1.MusteriMail} - Şifrəsi: {musterim1.MusteriSifresi} - Nömrəsi: {musterim1.MusteriNomresi}");
                count++;
            }
        }

        //Musteri musteriobj = new Musteri();
        public Musteri? SearchMusteri(string ad, string soyad)
        {
            foreach (var musterim2 in musteriList)
            {
                if (musterim2.MusteriAdi.ToLower() == ad.ToLower() && musterim2.MusteriSoyadi.ToLower() == soyad.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Tapıldı. Müştərinin adı: {musterim2.MusteriAdi} - Soyadı: {musterim2.MusteriSoyadi} - Emaili: {musterim2.MusteriMail} - Şifrəsi: {musterim2.MusteriSifresi} - Nömrəsi: {musterim2.MusteriNomresi}");
                    Console.ForegroundColor = ConsoleColor.White;
                    return musterim2;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Axtarışa uyğun işçi tapılmadı.");
            Console.ForegroundColor = ConsoleColor.White;
            return null;
        }


        public bool MusteriniDeyis(int musterinum, Musteri deyisdirilmisM)
        {
            var deyiselecek = musteriList;

            for (int i = 0; i <= deyiselecek.Count; i++)
            {
                if (musterinum == (i + 1))
                {
                    var kohnederman = deyiselecek[i];
                    deyisdirilmisM.MusteriAdi = string.IsNullOrWhiteSpace(deyisdirilmisM.MusteriAdi) ? kohnederman.MusteriAdi : deyisdirilmisM.MusteriAdi;
                    deyisdirilmisM.MusteriSoyadi = string.IsNullOrWhiteSpace(deyisdirilmisM.MusteriSoyadi) ? kohnederman.MusteriSoyadi : deyisdirilmisM.MusteriSoyadi;
                    deyisdirilmisM.MusteriMail = string.IsNullOrWhiteSpace(deyisdirilmisM.MusteriMail) ? kohnederman.MusteriMail : deyisdirilmisM.MusteriMail;
                    deyisdirilmisM.MusteriSifresi = string.IsNullOrWhiteSpace(deyisdirilmisM.MusteriSifresi) ? kohnederman.MusteriSifresi : deyisdirilmisM  .MusteriSifresi;
                    deyisdirilmisM.MusteriNomresi = string.IsNullOrWhiteSpace(deyisdirilmisM.MusteriNomresi) ? kohnederman.MusteriNomresi : deyisdirilmisM.MusteriNomresi;
                    deyiselecek[i] = deyisdirilmisM;
                    SaveMusteri(deyiselecek);

                    return true;
                }
            }
            return false;
        }


        public bool RemoveMusteri(int silineceknum)
        {
            var silinecekMusteriler = musteriList;

            for (int i = 0; i < silinecekMusteriler.Count; i++)
            {
                if (silineceknum == (i + 1))
                {
                    silinecekMusteriler.RemoveAt(i);
                    SaveMusteri(silinecekMusteriler);
                    return true;
                }
            }
            return false;
        }



        #endregion

    }
}
