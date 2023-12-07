using Aptek_Poreject;
using System.Numerics;
using System.Xml.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//Console.ForegroundColor = ConsoleColor.Blue;

Aptek aptek = new Aptek();

var isAtuthenticater = AuthenticateEmployee();
int loginAttemps = 0;

//if (!isAtuthenticater)
//    Console.WriteLine("Istideci adi veya sifresi yanlisdir");

//var whileAuthenticater = isAtuthenticater;
while (!isAtuthenticater)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Istideci adi veya sifresi yanlisdir");
    Console.ForegroundColor = ConsoleColor.White;
    loginAttemps++;
    if (loginAttemps >=3)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("3 dəfə yanlış istifadəçi adı və ya şifrə daxil edildiyinə görə proqram bağlandı.");
        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(2000);
        return;
    }
    isAtuthenticater = AuthenticateEmployee();
}


bool AuthenticateEmployee()
{
    // İstifadəçi adı və şifrəni almaq üçün istifadəçidən soruşulur.
    Console.WriteLine("\n-----------------------------------");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Xoş gəlmiziniz");
    Console.WriteLine("Xaiş edirik proqrama giriş etmək üçün aşağıda mail adresinizi və şifrənizi daxil edin: ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\n-----------------------------------");
    Console.WriteLine("İstifadəçi adı: ");
    string mail = Console.ReadLine();

    // usernam'in boş vəya null olduğu yoxlanılır.
    if (mail == null)
    {
        Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
    }

    // İstifadəçi şifrəsinin alınması.
    Console.WriteLine("Şifrə: ");
    string password = Console.ReadLine();
    if (password == null)
    {
        Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
    }

    var isciler = aptek.GetEmplooyes();

    foreach (var isci in isciler)
    {
        if (isci.IsciSifresi == password && isci.IsciMail == mail)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Giriş uğurlu oldu.");
            Console.ForegroundColor= ConsoleColor.White;
            return true;
        }
    }    return false;
}

//aptek.AddEmployee(isci);

try
{
    while (true)
    {
        EmployeeDisplayMenu();
        int secim = int.Parse(Console.ReadLine());
        // Menyunun göstərilməsi üçün DisplayMenu metodu çağrılır.
        switch (secim)
        {
            case 1:
                // Programın bağlanması.
                Console.WriteLine("Program bağlandı");
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

            default:

                break;
        }

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
    //Thread.Sleep(5000);
    //Console.Clear();
}



void EmployeeDisplayMenu()
{
    Console.WriteLine("\n-----------------------------------");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Aşağıda etmək istədiyiniz əməliyyatı seçin (1/6)");
    Console.WriteLine("1. Proqramı bağlamaq");
    Console.WriteLine("2. Aptekdəki dərman siyahısı");
    Console.WriteLine("3. Dərmanı axtarmaq");
    Console.WriteLine("4. Dərmanı əlavə etmək");
    Console.WriteLine("5. Dərmanı silmək");
    Console.WriteLine("6. Dərmanın məlumanlarını yeniləmək ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\n-----------------------------------");
}

