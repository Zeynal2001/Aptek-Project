using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptek_Poreject
{
    public static class LoginAttemp
    {
        public static void LoginAttemps()
        {
            var isAtuthenticater = Authenticate.AuthenticateEmployee();
            int loginAttemps = 0;

            
            while (!isAtuthenticater)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Istifadəçi adı vəya şifrəsi yanlışdır");
                Thread.Sleep(1800);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                loginAttemps++;
                if (loginAttemps >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3 dəfə yanlış istifadəçi adı və ya şifrə daxil edildiyinə görə proqram bağlandı.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    return;
                }
                isAtuthenticater = Authenticate.AuthenticateEmployee();

                Authenticate.AuthenticateEmployee();
            }
        }
    }
}
