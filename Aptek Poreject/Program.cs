using Aptek_Poreject;
using System.Numerics;
using System.Xml.Linq;
using System.Xml.Serialization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//Console.ForegroundColor = ConsoleColor.Blue;

//aptek.AddEmployee(isci);
Aptek aptek = new Aptek();
Employee iscim = new Employee();
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
                
                Employee isciswitch = new Employee();
                
                
                LoginAttemp.LoginAttemps();
                // Menyunun göstərilməsi üçün DisplayMenu metodu çağrılır.
                Menu.EmployeeDisplayMenu();
                int secim1 = int.Parse(Console.ReadLine());
                try
                {
                    
                    switch (secim1)
                    {
                        case 1:
                            // Programın bağlanması.
                            Console.WriteLine("Proqram bağlandı.");
                            return;
                        case 2:
                            // Müştəri əlavə etmək
                            iscim.AddMusteri();
                            break;
                        case 3:
                            // Müştəri siyahısının göstərilməsi.

                            break;
                        case 4:
                            // Müştəri hesabının axtarılması.

                            break;
                        case 5:
                            // Müştəri məlumanlarının yenilənmısi.

                            break;
                        case 6:
                            // Mövcud olan Müştəri hesabının bazadan silinməsi
                            break;
                        case 7:
                            // Aptekə yeni dərmanın əlavə edilməsi.
                            aptek.AddProduct();
                            break;
                        case 8:
                            // Aptekdəki dərmanların siyahısının göstərilməsi.
                            aptek.DisplayDermanlar();
                            break;
                        case 9:
                            // Dərmanın axtarılması.
                            break;
                        case 10:
                            // Dərman məlumanlarının yenilənmısi.

                            break;
                        case 11:
                            // Mövcud olan dərmanın bazadan silinməsi
                            
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

                //Admin kimi giriş etmək.
                if (Authenticate.AuthenticateAdmin())
                {
                    Menu.AdminMenu();
                    int deyer = int.Parse(Console.ReadLine());
                    switch (deyer)
                    {
                        case 1:

                            Console.WriteLine("İşçinin adını daxil edin:");
                            string adminAdi = Console.ReadLine();
                            Console.WriteLine("İşçinin soyadını daxil edin: ");
                            string adminSoyadi = Console.ReadLine();
                            Console.WriteLine("İşçinin email adresini daxil edin:");
                            string adminEmail = Console.ReadLine();
                            Console.WriteLine("İşçinin şifrəsini daxil edin:");
                            string adminSifresi = Console.ReadLine();
                            Console.WriteLine("İşçinin nömrəsini daxil edin:");
                            string adminNomresi = Console.ReadLine();

                            Employee isci5 = new Employee(isciAdi, isciSoyadi, isciEmail, isciSifresi, isciNomresi);
                            aptek.AddEmployee(isci5);
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Melumatlar yanlisdir");
                    
                }

                break;
            case 4:
                break;
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









