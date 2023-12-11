using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptek_Poreject
{
    public static class Menu
    {
        public static void MainDisplayMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xoş gəlmisiniz. Girişi seçin: ");
            Console.WriteLine("1. Admin kimi");
            Console.WriteLine("2. İşçi kimi. ");
            Console.WriteLine("3. Müştəri kimi. ");
            Console.WriteLine("4. Proqramdan çıxış etmək.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }

        public static void AdminMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAşağıda etmək istədiyiniz əməliyyatı seçin (1/12)");
            Console.WriteLine("1. Proqramdan çıxış etmək.");
            Console.WriteLine("2. İşçi elave etmek. ");
            Console.WriteLine("3. İşçi siyahısını göstərmək.");
            Console.WriteLine("4. İşçi hesabını axtarmaq.");
            Console.WriteLine("5. İşçinin məlumatlarını yeniləmək.");
            Console.WriteLine("6. Mövcud işçi hesabını silmək.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");

        }

        public static void EmployeeDisplayMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAşağıda etmək istədiyiniz əməliyyatı seçin (1/11)");
            Console.WriteLine("1. Proqramdan çıxış etmək.");
            Console.WriteLine("2. Müştəri əlavə etmək. ");
            Console.WriteLine("3. Müştəri siyahısını göstərmək.");
            Console.WriteLine("4. Müştəri hesabını axtarmaq.");
            Console.WriteLine("5. Müştəri məlumatlarını yeniləmək.");
            Console.WriteLine("6. Müştəri hesabını silmək.");

            Console.WriteLine("7. Dərmanı əlavə etmək.");
            Console.WriteLine("8. Aptekdəki dərman siyahısını göstərmək.");
            Console.WriteLine("9. Dərmanı axtarmaq.");
            Console.WriteLine("10. Dərmanın məlumanlarını yeniləmək.");
            Console.WriteLine("11. Dərmanı silmək.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }
    }
}
