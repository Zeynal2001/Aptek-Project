using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptek_Poreject
{
    public static class LoginAttemp
    {
        public static void LoginAttemps1()
        {
            var isAtuthenticater1 = Authenticate.AuthenticateAdmin();
            int loginAttemps = 0;


            while (!isAtuthenticater1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Admin maili vəya şifrəsi yanlışdır");
                Thread.Sleep(1800);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                loginAttemps++;
                if (loginAttemps >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3 dəfə yanlış Admin maili və ya şifrə daxil edildiyinə görə proqram bağlandı.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    return;
                }
                isAtuthenticater1 = Authenticate.AuthenticateAdmin();

                Authenticate.AuthenticateAdmin();
            }
        }

        public static void LoginAttemps2()
        {
            var isAtuthenticater2 = Authenticate.AuthenticateEmployee();
            int loginAttemps = 0;


            while (!isAtuthenticater2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("İşçi maili vəya şifrəsi yanlışdır");
                Thread.Sleep(1800);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                loginAttemps++;
                if (loginAttemps >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        "3 dəfə yanlış İşçi maili və ya şifrə daxil edildiyinə görə proqram bağlandı.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    return;
                }

                isAtuthenticater2 = Authenticate.AuthenticateEmployee();

                Authenticate.AuthenticateEmployee();
            }
        }


        public static void LoginAttemps3()
        {
            var isAtuthenticater3 = Authenticate.AuthenticateMusteri();
            int loginAttemps = 0;


            while (!isAtuthenticater3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Müştəri maili vəya şifrəsi yanlışdır");
                Thread.Sleep(1800);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                loginAttemps++;
                if (loginAttemps >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        "3 dəfə yanlış müştəri maili və ya şifrə daxil edildiyinə görə proqram bağlandı.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    return;
                }

                isAtuthenticater3 = Authenticate.AuthenticateMusteri(); ;

                Authenticate.AuthenticateMusteri();
            }
        }
    }
}
