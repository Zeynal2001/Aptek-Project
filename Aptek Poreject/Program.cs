using Aptek_Poreject;
using System.Numerics;
using System.Xml.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//Console.ForegroundColor = ConsoleColor.Blue;

//aptek.AddEmployee(isci);

Menu.MainDisplayMenu();

int secim2 = 0;
if (int.TryParse(Console.ReadLine(), out secim2))
{
    while (true)
    {
        switch (secim2)
        {
            case 1:
                //İşçi kimi giriş etmək.
                LoginAttemp.LoginAttemps();
                Menu.EmployeeDisplayMenu();
                Aptek aptek = new Aptek();

                int secim1 = int.Parse(Console.ReadLine());
                try
                {
                    // Menyunun göstərilməsi üçün DisplayMenu metodu çağrılır.
                    switch (secim1)
                    {
                        case 1:
                            // Programın bağlanması.
                            Console.WriteLine("Proqram bağlandı.");
                            return;
                        case 2:
                            // Aptekdəki dərmanların siyahısının göstərilməsi.
                            aptek.DisplayDermanlar();
                            break;
                        case 3:
                            // Dərmanın axtarılması.

                            break;
                        case 4:
                            // Aptekə yeni dərmanın əlavə edilməsi.
                            aptek.AddProduct();
                            break;
                        case 5:
                            // Dərmanın bazadan silinməsi
                            break;
                        case 6:
                            // Dərmanın məlumanlarının yenilənmısi.

                            break;
                        case 7:

                            break;
                        case 8:

                            break;
                        case 9:

                            break;

                        default:
                            //Yanlış seçim

                            break;
                    }

                }
                catch (Exception ex)
                {
                    // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
                    Console.WriteLine($"Xəta baş verdi: {ex.Message}");
                }
                finally
                {
                    // Bura əlavə təmizləmə və ya başqa tədbirlər əlavə edilə bilər.
                    Thread.Sleep(3000);
                    Console.Clear();
                }

                break;
            case 2:
                //Müştəri kimi giriş etmək.

                break;
            case 3:
                //Proqramdan çıxış etmək.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Proqram bağlandı.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            default:
                //Yanlış seçim
                Console.WriteLine("Yanlış seçim etmisiniz");

                break;
        }
    }
}
else
{
    Console.WriteLine("Daxil etdiyiniz dəyər doğru formatda deyil!");
}









