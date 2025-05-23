using UserRoles.Data;
using UserRoles.Models;

namespace UserRoles;

class Program
{
    private static ConsoleMenu _userMenu = new("Ana Menü");
    private static ConsoleMenu _editorMenu = new("Ana Menü");
    private static ConsoleMenu _adminMenu = new("Ana Menü");
    
    static void Main(string[] args)
    {
        // _userMenu
        //     .AddOption("Kullanıcı bilgilerim", () => Console.WriteLine(""))
        //     .AddOption("Onay bekleyen yorumlarım", () => Console.WriteLine(""));
        //
        // _editorMenu
        //     .AddOption("Onay bekleyen yorumlar", () => Console.WriteLine(""))
        //     .AddOption("Tüm yorumlar", () => Console.WriteLine(""))
        //     .AddOption("Yeni içerik ekleme", () => Console.WriteLine(""));
        //
        // _adminMenu
        //     .AddOption("Tüm Kullanıcılar", () => Console.WriteLine(""))
        //     .AddOption("Tüm yorumlar", () => Console.WriteLine(""))
        //     .AddMenu("Editör İşlemleri", () => { _editorMenu.Show(); })
        //     .AddOption("Tüm içerikler", () => Console.WriteLine(""));
        //
        // using var context = new AppDbContext();
        // var firstUser = context.Users.FirstOrDefault();
        // switch (firstUser?.Role)
        // {
        //    case Roles.User:
        //        _userMenu.Show(true);
        //        break;
        //    case Roles.Editor:
        //        _editorMenu.Show(true);
        //        break;
        //    case Roles.Admin:
        //        _adminMenu.Show(true);
        //        break;
        // }
        
        using var context = new AppDbContext();
        
        var newUser = new User
        {
            Username = "baskabiri",
            Password = "123",
        };
        context.Users.Add(newUser);
        
        var inputRol = Helper.AskOption(["Kullanıcı", "Editör", "Yönetici"]);
        newUser.Role = (Roles)inputRol;
        context.SaveChanges();
        
        // postman
    }
}