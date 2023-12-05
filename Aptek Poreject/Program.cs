using Aptek_Poreject;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//Console.ForegroundColor = ConsoleColor.Blue;



Aptek aptek = new Aptek();

var isAtuthenticater = AuthenticateEmployee();
int loginAttemps = 0;

if (!isAtuthenticater)
    Console.WriteLine("Istideci adi veya sifresi yanlisdir");

var whileAuthenticater = isAtuthenticater;
while (!whileAuthenticater)
{
    loginAttemps++;
    if (loginAttemps >=3)
    {
        Console.WriteLine("Siz 3 dəfə yanlış istifadəçi adı və ya şifrə daxil etdiniz");
        Thread.Sleep(2000);
        return;
    }
    whileAuthenticater = AuthenticateEmployee();
}


bool AuthenticateEmployee()
{
    // İstifadəçi adı və şifrəni almaq üçün istifadəçidən soruşulur.
    DisplayMenu();
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

void DisplayMenu()
{
    Console.WriteLine("\n-----------------------------------");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("xoş gəlmiziniz");
    Console.WriteLine("xaiş edirik proqrama giriş etmək üçün aşağıda istifadəçi adınızı və şifrənizi daxil edin: ");
    Console.ForegroundColor = ConsoleColor.White;

    //console.writeline("1. kitabxanadakı element siyahısı");
    //console.writeline("2. element əlavə etmək");
    //console.writeline("3. tələbəyə (kirayə) kitab vermək");

    //console.writeline("-----------------------------------");
    //console.write("seçiminizi daxil edin: ");

}
