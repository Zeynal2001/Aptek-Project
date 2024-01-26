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
Product dermanobj = new Product();
Menu.MainDisplayMenu();

int secim1 = 0;
if (int.TryParse(Console.ReadLine(), out secim1))
{
    
    switch (secim1)
    {
        case 1:
            //Admin kimi giriş etmək.
            bool authed1 = Authenticator.AuthenticateAdmin();
            if (!authed1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mail vəya şifrə yanlışdır");
                Console.ForegroundColor = ConsoleColor.White;
                authed1 = Authenticator.HandleFaliedLoginAttempsAd();

            }
            while (true && authed1)
            {
                //TODO: while yaz
                Menu.AdminMenu();
                try
                {
                    int deyer = int.Parse(Console.ReadLine());
                    switch (deyer)
                    {
                        case 1:
                            // Programın bağlanması.
                            Console.WriteLine("Proqram bağlandı.");
                            return;
                        case 2:
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
                        case 3:
                            // İşçi siyahısının göstərilməsi.
                            adminobj2.DisplayEmploye();
                            break;
                        case 4:
                            // İşçi hesabının axtarılması.
                            Console.WriteLine("Tapmaq istədiyiniz işçinin adını daxil edin:");
                            string isad = Console.ReadLine(); 
                            Console.WriteLine("Tapmaq istədiyiniz işçinin soyadını daxil edin:");
                            string issoyad = Console.ReadLine();

                            var tapilacaqIs = adminobj2.SearchEmployee(isad, issoyad);
                            if (tapilacaqIs == null)
                            {
                                Console.WriteLine("İşçi tapılmadı");
                                return;
                            }
                            break;
                        case 5:
                            // İşçi məlumanlarının yenilənməsi.
                            adminobj2.DisplayEmploye();

                            Console.WriteLine("Məlumatlarını dəyişmək istədiyniz işçinin sıra sayını girin: ");
                            int secim_isci = int.Parse(Console.ReadLine());

                            Console.WriteLine("İşçinin yeni adını daxil edin: ");
                            string yeniIsAd = Console.ReadLine();
                            Console.WriteLine("İşçinin yeni soyadını daxil edin: ");
                            string yeniIsSoyad = Console.ReadLine();
                            Console.WriteLine("İşçinin yeni mail adresini daxil edin: ");
                            string yeniIsMail = Console.ReadLine();
                            Console.WriteLine("İşçinin yeni şifrəsini daxil edin: ");
                            string yeniIsSifre = Console.ReadLine();
                            Console.WriteLine("İşçinin yeni nömrəsini daxil edin: ");
                            string yeniIsNomre = Console.ReadLine();


                            Employee yeniIs = new Employee(fName: yeniIsAd, lName: yeniIsSoyad, isciMail: yeniIsSifre, isciPassword: yeniIsSifre, isciPass: yeniIsNomre);

                            bool deyisildimiIs = adminobj2.IsciniDeyis(secim_isci, yeniIs);
                            if (deyisildimiIs)
                            {
                                Console.WriteLine("Məlumatlar uğurla dəyişildi");
                            }
                            else
                            {
                                Console.WriteLine("Daxil edilen sıra sayına uyğun işçi tapılmadı");
                            }

                            break;
                        case 6:
                            // Mövcud olan İşçi hesabının bazadan silinməsi
                            adminobj2.DisplayEmploye();

                            Console.WriteLine("\nSilinəcək işçinin sıra sayını girin: ");
                            int silinecekIs = int.Parse(Console.ReadLine());

                            bool silindimiIs = adminobj2.RemoveEmployee(silinecekIs);
                            if (silindimiIs)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("İşçi uğurla bazadan silindi");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Daxil edilen sıra sayına uyğun işçi tapılmadı");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        default:
                            Console.WriteLine("Seçim düzgün deyil.");
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
            break;
        case 2:
            //İşçi kimi giriş etmək.
            bool authed2 = Authenticator.AuthenticateEmployee();
            if (!authed2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mail vəya şifrə yanlışdır");
                Console.ForegroundColor = ConsoleColor.White;
                authed2 = Authenticator.HandleFaliedLoginAttempsEmp();
            }

            while (true && authed2)
            {
                //TODO: while yaz
                // Menyunun göstərilməsi üçün DisplayMenu metodu çağrılır.
                Menu.EmployeeDisplayMenu();

                try
                {
                    int secim2 = int.Parse(Console.ReadLine());

                    switch (secim2)
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
                            iscim.DisplayMusteri();
                            break;
                        case 4:
                            // Müştəri hesabının axtarılması.
                            Console.WriteLine("Tapmaq istədiyiniz müştərinin adını daxil edin:");
                            string musAd = Console.ReadLine();
                            Console.WriteLine("Tapmaq istədiyiniz müştərinin soyadını daxil edin:");
                            string musSoyad = Console.ReadLine();

                            var tapilacaqMus = iscim.SearchMusteri(musAd, musSoyad);
                            if (tapilacaqMus == null)
                            {
                                Console.WriteLine("Müştəri tapılmadı");
                                return;
                            }
                            break;
                        case 5:
                            // Müştəri məlumanlarının yenilənməsi.
                            iscim.DisplayMusteri();

                            Console.WriteLine("Məlumatlarını dəyişmək istədiyniz müştərinin sıra sayını girin: ");
                            int secim_musteri = int.Parse(Console.ReadLine());

                            Console.WriteLine("İstifadəçinin yeni adını daxil edin: ");
                            string yenimad = Console.ReadLine();
                            Console.WriteLine("İstifadəçinin yeni soyadını daxil edin: ");
                            string yenisoyad = Console.ReadLine();
                            Console.WriteLine("İstifadəçinin yeni mail adresini daxil edin: ");
                            string yeniMail = Console.ReadLine();
                            Console.WriteLine("İstifadəçinin yeni şifrəsini daxil edin: ");
                            string yeniSifre = Console.ReadLine();
                            Console.WriteLine("İstifadəçinin yeni nömrəsini daxil edin: ");
                            string yeniNomre = Console.ReadLine();
                            
                            
                            Musteri yeniMus = new Musteri(musteriAdi: yenimad, musteriSoyadi: yenisoyad, musteriMail: yeniMail, musteriSifresi: yeniSifre, musteriNomresi: yeniNomre);

                            bool deyisildimiM = iscim.MusteriniDeyis(secim_musteri, yeniMus);
                            if (deyisildimiM)
                            {
                                Console.WriteLine("Məlumatlar uğurla dəyişildi");
                            }
                            else
                            {
                                Console.WriteLine("Daxil edilen sıra sayına uyğun müştəri tapılmadı");
                            }
                            break;
                        case 6:
                            // Mövcud olan Müştəri hesabının bazadan silinməsi
                            iscim.DisplayMusteri();

                            Console.WriteLine("\nSilinəcək müştərinin sıra sayını girin: ");
                            int silinecekM = int.Parse(Console.ReadLine());


                            bool silindimiMus = iscim.RemoveMusteri(silinecekM);
                            if (silindimiMus)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Müştəri uğurla bazadan silindi");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Daxil edilen sıra sayına uyğun müştəri tapılmadı");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
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
                            Console.WriteLine("Tapmaq istədiyiniz dərmanın adını daxil edin:");
                            string dermanad = Console.ReadLine();

                            var tapilacaqDer = aptek.SearchMedicine(dermanad);
                            if (tapilacaqDer == null)
                            {
                                Console.WriteLine("Dərman tapılmadı");
                                return;
                            }
                            break;
                        case 10:
                            // Dərman məlumanlarının yenilənmısi.
                            aptek.DisplayDermanlar();

                            Console.WriteLine("Məlumatlarını dəyişmək istədiyniz dərmanın sıra sayını girin: ");
                            int secim_derman = int.Parse(Console.ReadLine());

                            Console.WriteLine("Dərmanın yeni adını daxil edin: ");
                            string yeniad = Console.ReadLine();
                            Console.WriteLine("Dərmanın kateqoriyasını daxil edin: ");
                            string yenikateqoriya = Console.ReadLine();
                            Console.WriteLine("Dərmanın miqdarını daxil edin: ");
                            int yenimiqdar = int.Parse(Console.ReadLine());
                            Console.WriteLine("Dərmanın qiymətini daxil edin: ");
                            double yeniqiymet = int.Parse(Console.ReadLine());

                            Product yeniD = new Product(pname: yeniad, category: yenikateqoriya, price: yeniqiymet, quantity: yenimiqdar);

                            bool deyisildimiDer = aptek.DermaniDeyis(secim_derman, yeniD);
                            if (deyisildimiDer)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Məlumatlar uğurla dəyişildi");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Daxil edilen sıra sayına uyğun dərman tapılmadı");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case 11:
                            // Mövcud olan dərmanın bazadan silinməsi
                            aptek.DisplayDermanlar();

                            Console.WriteLine("\nSilinəcək dərmanın sıra sayını girin: ");
                            int silinecekD = int.Parse(Console.ReadLine());

                            bool silindimiDer = aptek.RemoveProduct(silinecekD);
                            if (silindimiDer)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Dərman uğurla bazadan silindi");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Daxil edilen sıra sayına uyğun dərman tapılmadı");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        default:
                            //Yanlış seçim
                            Console.WriteLine("Seçim düzgün deyil.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Xəta baş verdi: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                finally
                {
                    // Bura əlavə təmizləmə və ya başqa tədbirlər əlavə edilə bilər.
                    Thread.Sleep(3000);
                    Console.Clear();
                }
            }
            break;
        case 3:
            //Müştəri kimi giriş etmək.
            bool authed3 = Authenticator.AuthenticateMusteri();
            if (!authed3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mail vəya şifrə yanlışdır");
                Console.ForegroundColor = ConsoleColor.White;
                authed3 = Authenticator.HandleFaliedLoginAttempsMus();
            }

            while (true && authed3)
            {
                Menu.MusteriDisplayMenu();

                try
                {
                    int secim3 = int.Parse(Console.ReadLine());
                    switch (secim3)
                    {
                        case 1:
                            // Dərmanlara baxmaq.
                            aptek.DisplayDermanlar();
                            break;
                        case 2:
                            // Dərman almaq.
                            aptek.DisplayDermanlar();

                            Console.WriteLine("\nAlmaq istədiyiniz dərmanın sıra sayını girin: ");
                            int alinacaqD = int.Parse(Console.ReadLine());
                            Console.WriteLine("Miqdarı daxil edin");
                            int miqdarD = int.Parse(Console.ReadLine());

                            aptek.QiymetCixartmaq(alinacaqD, miqdarD);

                            bool alindimiD = aptek.DermanAlmaq(alinacaqD, miqdarD);
                            if (alindimiD)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Dərman uğurla alındı. Həmişə sağlam qalın 😊");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Daxil edilen sıra sayına uyğun dərman tapılmadı vəya başqa bir xəta meydana gəldi.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case 3:
                            // Proqramdan çıxmaq.
                            Console.WriteLine("Proqram bağlandı.");
                            return;
                        default:

                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Xəta baş verdi: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                finally
                {
                    // Bura əlavə təmizləmə və ya başqa tədbirlər əlavə edilə bilər.
                    Thread.Sleep(3000);
                    Console.Clear();
                }
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
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Xəta: Daxil etdiyiniz dəyər doğru formatda deyil!");
    Console.ForegroundColor = ConsoleColor.White;
}
