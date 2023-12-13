using Aptek_Poreject;
using System.Numerics;
using System.Xml.Linq;
using System.Xml.Serialization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//Console.ForegroundColor = ConsoleColor.Blue;

//aptek.AddEmployee(isci);
Aptek aptek = new Aptek();
Employee iscim = new Employee();
Admin adminobj2 = new Admin();
Menu.MainDisplayMenu();

int secim1 = 0;
if (int.TryParse(Console.ReadLine(), out secim2))
{
    
                    
 
    switch (secim1)
    {
        case 1:
            //Admin kimi giriş etmək.
            if (Authenticate.AuthenticateAdmin())
            {
                LoginAttemp.LoginAttemps1();
                
                while (true)
                {
                    //TODO: while yaz
                    Menu.AdminMenu();

                    int deyer = int.Parse(Console.ReadLine());
                    switch (deyer)
                    {
                        case 1:
                            // Yeni işçi əlavə etmək.

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

                            Employee isci5 = new Employee(adminAdi, adminSoyadi, adminEmail, adminSifresi, adminNomresi);
                            adminobj2.AddEmployee(isci5);
                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                        case 6:

                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Melumatlar yanlisdir");

            }
            break;
        case 2:
            //İşçi kimi giriş etmək.

            if (Authenticate.AuthenticateEmployee())
            {
                LoginAttemp.LoginAttemps2();

                while (true)
                {
                    //TODO: while yaz
                    // Menyunun göstərilməsi üçün DisplayMenu metodu çağrılır.
                    Menu.EmployeeDisplayMenu();

                    int secim2 = int.Parse(Console.ReadLine());
                    try
                    {

                        switch (secim2)
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
                            iscim.DisplayMusteri();
                            break;
                        case 4:
                            // Müştəri hesabının axtarılması.
                            iscim.SearchMusteri();
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
                            aptek.SearchMedicine();
                            break;
                        case 10:
                            // Dərman məlumanlarının yenilənmısi.

                            break;
                        case 11:
                            // Mövcud olan dərmanın bazadan silinməsi
                            aptek.RemoveProduct();
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
                }
            }
            else
            {
                Console.WriteLine("Melumatlar yanlisdir");
            }
            break;
        case 3:
            //Müştəri kimi giriş etmək.
            if (Authenticate.AuthenticateMusteri())
            {
                LoginAttemp.LoginAttemps3();

                while (true)
                {
                    Menu.MusteriDisplayMenu();

                    int secim3 = int.Parse(Console.ReadLine());
                    switch (secim3)
                    {
                        case 1:
                            // Dərmanlara baxmaq.
                            aptek.DisplayDermanlar();
                            break;
                        case 2:
                            // Dərman almaq.

                            break;
                        case 3:
                            // Proqramdan çıxmaq.
                            Console.WriteLine("Proqram bağlandı.");
                            return;
                        default:

                            break;
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Melumatlar yanlisdir");
            }


            break;
        case 4:
            // Programın bağlanması.
            Console.WriteLine("Proqram bağlandı.");
            return;
        default:
            //Yanlış seçim
            Console.WriteLine("Yanlış seçim etmisiniz");

            break;
    }
 
}
else
{
    Console.WriteLine("Daxil etdiyiniz dəyər doğru formatda deyil!");
}









