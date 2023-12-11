using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptek_Poreject
{
    public static class Authenticate
    {
        public static bool AuthenticateMusteri()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xaiş edirik işçi kimi proqrama giriş etmək üçün aşağıda email adresinizi və şifrənizi daxil edin: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-----------------------------------");

            Console.WriteLine("Maili daxil edn");
            string musteriMail = Console.ReadLine();

            Console.WriteLine("Sifreni daxil edin");
            string musteriSifre = Console.ReadLine();


            if (musteriMail == "musteri@mail.com" && musteriSifre == "musteri123")
            {
                return true;


            }

            return false;

        }

        public static bool AuthenticateAdmin()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xaiş edirik işçi kimi proqrama giriş etmək üçün aşağıda email adresinizi və şifrənizi daxil edin: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-----------------------------------");

            Console.WriteLine("Maili daxil edn");
            string adminMail = Console.ReadLine();


            Console.WriteLine("Sifreni daxil edin");
            string adminSifre = Console.ReadLine();


            if (adminMail == "admin@mail.com" && adminSifre == "admin123")
            {
                return true;


            }

            return false;


        }


        public static bool AuthenticateEmployee()
        {
            Employee staff = new Employee();
            Aptek aptekim = new Aptek();

            // İstifadəçi adı və şifrəni almaq üçün istifadəçidən soruşulur.
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xaiş edirik işçi kimi proqrama giriş etmək üçün aşağıda email adresinizi və şifrənizi daxil edin: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-----------------------------------");


            Console.WriteLine("Email'i daxil edin: ");
            string email = Console.ReadLine();

            // usernam'in boş vəya null olduğu yoxlanılır.
            if (email == null)
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            // İstifadəçi şifrəsinin alınması.
            Console.WriteLine("Şifrəni daxil edin: ");
            string password = Console.ReadLine();
            if (password == null)
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            var isciler = aptekim.GetEmplooyes();

            foreach (var isci in isciler)
            {
                if (isci.IsciSifresii == password && isci.IsciMail == email)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Giriş uğurlu oldu.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
            }
            return false;
            // isci.FName == ad && isci.LName == soyad
        }

        
    }
}
