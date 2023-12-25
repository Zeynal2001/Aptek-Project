using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptek_Poreject
{
    public static class Authenticator
    {
        public static bool AuthenticateAdmin()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xaiş edirik admin kimi proqrama giriş etmək üçün aşağıda email adresinizi və şifrənizi daxil edin: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-----------------------------------");

            Console.WriteLine("Maili daxil edn");
            string adminMail = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(adminMail)) //adminMail == null
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            Console.WriteLine("Şifrəni daxil edin");
            string adminSifre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(adminSifre)) 
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            if (adminMail == "admin@mail.com" && adminSifre == "admin123")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Giriş uğurlu oldu.");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }

            return false;
        }



        public static bool AuthenticateMusteri()
        {

            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xaiş edirik müştəri kimi proqrama giriş etmək üçün aşağıda email adresinizi və şifrənizi daxil edin: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-----------------------------------");

            Console.WriteLine("Maili daxil edn");
            string musteriMail = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(musteriMail)) //musteriMail == null
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            Console.WriteLine("Şifrəni daxil edin");
            string musteriSifre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(musteriSifre))
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            if (musteriMail == "musteri@mail.com" && musteriSifre == "musteri123")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Giriş uğurlu oldu.");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }

            return false;
        }




        public static bool AuthenticateEmployee()
        {
            Admin adminobj = new Admin();

            // İstifadəçi adı və şifrəni almaq üçün istifadəçidən soruşulur.
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xaiş edirik işçi kimi proqrama giriş etmək üçün aşağıda email adresinizi və şifrənizi daxil edin: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-----------------------------------");


            Console.WriteLine("Email'i daxil edin: ");
            string email = Console.ReadLine();

            // usernam'in boş vəya null olduğu yoxlanılır.
            if (string.IsNullOrWhiteSpace(email)) //email == null
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            // İstifadəçi şifrəsinin alınması.
            Console.WriteLine("Şifrəni daxil edin: ");
            string password = Console.ReadLine();

            // password'un boş vəya null olduğu yoxlanılır.
            if (string.IsNullOrWhiteSpace(password)) //password == null
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            var isciler = adminobj.GetEmplooyes();

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



        public static bool HandleFaliedLoginAttempsAd()
        {
            int loginAttemps = 0;

            while (loginAttemps <= 3)
            {
                if (AuthenticateAdmin())
                    return true;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mail vəya şifrə yanlışdır");
                Thread.Sleep(1800);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                loginAttemps++;
                if (loginAttemps >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3 dəfə yanlış mail və ya şifrə daxil edildiyinə görə proqram bağlandı.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    return false;
                }
            }
            return false;
        }


        public static bool HandleFaliedLoginAttempsEmp()
        {
            int loginAttemps = 0;

            while (loginAttemps <= 3)
            {
                if (AuthenticateEmployee())
                    return true;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mail vəya şifrə yanlışdır");
                Thread.Sleep(1800);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                loginAttemps++;
                if (loginAttemps >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3 dəfə yanlış mail və ya şifrə daxil edildiyinə görə proqram bağlandı.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    return false;
                }
            }
            return false;
        }


        public static bool HandleFaliedLoginAttempsMus()
        {
            int loginAttemps = 0;

            while (loginAttemps <= 3)
            {
                if (AuthenticateMusteri())
                    return true;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mail vəya şifrə yanlışdır");
                Thread.Sleep(1800);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                loginAttemps++;
                if (loginAttemps >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3 dəfə yanlış mail və ya şifrə daxil edildiyinə görə proqram bağlandı.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    return false;
                }
            }
            return false;
        }
    }
}
    


