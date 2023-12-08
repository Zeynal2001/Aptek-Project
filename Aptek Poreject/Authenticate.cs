using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptek_Poreject
{
    public static class Authenticate
    {
        
        public static bool AuthenticateEmployee()
        {
            Aptek aptek = new();

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

            var isciler = aptek.GetEmplooyes();

            foreach (var isci in isciler)
            {
                if (isci.IsciSifresi == password && isci.IsciMail == email)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Giriş uğurlu oldu.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
            }
            return false;
        }
    }
}
