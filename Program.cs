using ConsoleChatApp.Data;
using ConsoleChatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleChatApp;

class Program
{
    private static User? _loggedInUser;
    private static ConsoleMenu _userMenu = new("Kullanıcı Menüsü");
    private static AppDbContext _context = new AppDbContext();
    
    static void Main()
    {
        _userMenu
            .AddMenu("Mesajları izle", () => ReadMessages())
            .AddMenu("Mesaj gönder", SendMessage);
        
        var mainMenu = new ConsoleMenu("Console Chat Uygulaması", true);
        mainMenu
            .AddMenu("Giriş Yap", LoginUser)
            .AddMenu("Kayıt Ol", RegisterUser);

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

    static void SendMessage()
    {
        Helper.ShowInfoMsg("Çıkış için boş mesaj gönderin");
        while (true)
        {
            var inputMsg = Helper.Ask("Mesaj");
            if (string.IsNullOrEmpty(inputMsg))
            {
                break;
            }
            _context.Messages.Add(new Message
            {
                Content = inputMsg,
                SenderId = _loggedInUser!.Id
            });
            _context.SaveChanges();
        }
    }

    static async Task ReadMessages()
    {
        // lokal fonksiyon
        // method içindeki iş akışımızı sadeleştirmek ve daha yönetilebilir hale getirmek için
        // async olayının bununla alakası yok
        async Task StreamMessages()
        {
            var lastMessageId = 0;
            while (true)
            {
                _context.Messages
                    .Where(m => m.Id > lastMessageId)
                    .Include(s => s.Sender).ToList()
                    .ForEach(m =>
                    {
                        string msg;
                
                        if (m.Sender.Id == _loggedInUser!.Id)
                        {
                            msg = $"{m.Content} - {m.Sender.Name}".PadLeft(Console.WindowWidth);
                        }
                        else
                        {
                            msg = $"{m.Sender.Name} - {m.Content}";
                        }
                
                        lastMessageId = m.Id;
                        Console.WriteLine(msg);
                    
                    });
                await Task.Delay(200);
            }
        }

        async Task CheckForExit()
        { 
            Console.ReadKey(true);
        }

        await Task.WhenAny(StreamMessages(), CheckForExit());
    }
    
    static void RegisterUser()
    {
        var inputName = Helper.Ask("Ad", true);
        var inputUsername = Helper.Ask("Kullanıcı adı", true);
        var inputPassword = Helper.AskPassword("Şifre");
        var registerStatus = Auth.Register(inputName!, inputUsername!, inputPassword, out var user);

        if (registerStatus == Auth.RegisterStatus.UsernameExists)
        {
            Helper.ShowErrorMsg("Bu kullanıcı zaten var!");
            Thread.Sleep(1000);
            return;
        }
        
        Helper.ShowSuccessMsg("Kaydın yapıldı");
        Thread.Sleep(1000);
        _loggedInUser = user;
        //LoggedInUserMenu(); // TODO: bunu daha mantıklı formata getirelim
        _userMenu.Show();
    }

    static void LoginUser()
    {
        // chat odasını izle
        // chat odasına mesaj gönder -> mesaj gönderin
        
        var inputUsername = Helper.Ask("Kullanıcı adı", true);
        var inputPassword = Helper.AskPassword("Şifre");
        var loginStatus = Auth.Login(inputUsername!, inputPassword, out var user);
        switch (loginStatus)
        {
            case Auth.LoginStatus.LoggedIn:
                _loggedInUser = user; // login olan kullanıcıyı genel olarak erişebileceğim bir yere göndermem lazım
                _userMenu.Show();
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