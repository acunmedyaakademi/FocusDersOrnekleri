using System.Security.Cryptography;
using System.Text;
using ConsoleChatApp.Data;
using ConsoleChatApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

namespace ConsoleChatApp;

class Program
{
    private static User? _loggedInUser = null;
    
    static void Main(string[] args)
    {
        var mainMenu = new ConsoleMenu("Console Chat Uygulaması", true);
        mainMenu
            .AddMenu("Giriş Yap", LoginUser)
            .AddOption("Kayıt Ol", () => Console.WriteLine("Silme"));

        mainMenu.Show();
        
        #region sonra bakıcaz

        // kullanıcı giriş çıkış işlemleri
        // kullanıcı kayıt
        // mevcut giriş yapmış kullanıcı bulma, onunla işlem yapabilme
        // kullanıcıadı|şifre|geçerlilik zamanı
        // yeni kullanıcı kaydı
        // Console.Write("Ad: ");
        // var inputName = Console.ReadLine();
        //
        // Console.Write("Kullanıcı adı: ");
        // var inputUsername = Console.ReadLine();
        //
        // Console.Write("Şifre: ");
        // var inputPass = Console.ReadLine();
        // var hashedPassword = Hash(inputPass);
        //
        // var db = new AppDbContext();
        // while (true)
        // {
        //     var doesUserExist = db.Users.Any(u => u.Username == inputUsername);
        //     if (!doesUserExist)
        //     {
        //         break;
        //     }       
        //     
        //     Console.WriteLine("Bu kullanıcıdan var.");
        //     Console.Write("Kullanıcı adı: ");
        //     inputUsername = Console.ReadLine();
        // }
        //
        //
        // var newUser = new User()
        // {
        //     Name = inputName,
        //     Username = inputUsername,
        //     Password = hashedPassword
        // };
        // db.Users.Add(newUser);
        // db.SaveChanges();

        // try
        // { 
        //     
        //     Console.WriteLine("Kullanıcı kaydı tamamlandı.");
        // }
        // catch (Exception e)
        // {
        //     // -2146233088
        //     // -2146233079
        //     // -2146232060
        //     Console.WriteLine(e.HResult);
        //     Console.WriteLine("Aynı isimde Başka kullanıcı var.");
        // }

        // kullanıcı önce veritabanında arayıp, varsa bu kullanıcı var demek

        //Console.WriteLine(VerifyPassword(inputPass, hashedPassword));

        // var inputUserName = "orhanekici";
        // var inputUserpass = "123123";
        // kontrolü uygulamada yapar
        // var user = db.Users.FirstOrDefault(u => u.Username == inputUserName);
        // if (user != null && VerifyPassword(inputUserpass, user.Password))
        // {
        //     // merhaba kullanıcı
        // }

        // kontrolü veritabanında yapar
        // var user = db.Users.FirstOrDefault(u => u.Username == inputUserName && u.Password == Hash(inputUserpass));
        // if (user != null)
        // {
        //     // merhaba kullanıcı
        // }

        // kontrolü uygulamada yaparsak;
        // önce ilgili kullanıcıyı veritabanından çekip, şifre doğru mu diye uygulama üzerinde kontrol yaparız

        // kontrolü veritabanında yaparsak;
        // veritabanına hem kullanıcı adı hem de şifre gönderip, uyan kullanıcı varsa o zaman o kullanıcı çekeriz

        // iki durumda da tekrar şifreleme için işlem yapmamız gerekir

        #endregion
    }

    static void LoggedInUserMenu()
    {
        var userMenu = new ConsoleMenu("Kullanıcı Menüsü");
        userMenu
            .AddOption("Rumuz belirle", () => Console.WriteLine("Rumuzun nedir?"))
            .AddOption("Oda ara", () => Console.WriteLine("Oda ara"))
            .AddOption("Oda oluştur", () => Console.WriteLine("Oda oluştur"));
        
        userMenu.Show();
    }

    static void LoginUser()
    {
        var inputUsername = Helper.Ask("Kullanıcı adı", true);
        var inputPassword = Helper.AskPassword("Şifre");
        var loginStatus = Auth.Login(inputUsername, inputPassword, out var user);
        switch (loginStatus)
        {
            case Auth.LoginStatus.LoggedIn:
                _loggedInUser = user; // login olan kullanıcıyı genel olarak erişebileceğim bir yere göndermem lazım
                LoggedInUserMenu(); // giriş yapıldıktan sonra göstermem gereken menüyü göstercem
                break;
            case Auth.LoginStatus.UserNotFound:
                    Helper.ShowErrorMsg("Kullanıcın bulunamadı!");
                    Thread.Sleep(1000);
                break;
            case Auth.LoginStatus.WrongCredentials:
                    Helper.ShowErrorMsg("Eksik veya hatalı giriş yaptın!");
                    Thread.Sleep(1000);
                break;
        }
    }
    
}