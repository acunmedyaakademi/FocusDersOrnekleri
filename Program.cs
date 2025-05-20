using System.Security.Cryptography;
using System.Text;
using ConsoleChatApp.Data;
using ConsoleChatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleChatApp;

class Program
{
    static void Main(string[] args)
    {
        // yeni kullanıcı kaydı
        Console.Write("Ad: ");
        var inputName = Console.ReadLine();
        
        Console.Write("Kullanıcı adı: ");
        var inputUsername = Console.ReadLine();
        
        Console.Write("Şifre: ");
        var inputPass = Console.ReadLine();
        var hashedPassword = Hash(inputPass);

        var newUser = new User()
        {
            Name = inputName,
            Username = inputUsername,
            Password = hashedPassword
        };

        var db = new AppDbContext();
        db.Users.Add(newUser);
        db.SaveChanges();

        Console.WriteLine("Kullanıcı kaydı tamamlandı.");

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
        
    }
    
    static string Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // Girdiyi byte dizisine çevir
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Byte dizisini hex string'e çevir
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2")); // "x2" => 2 karakterlik hex
            }
            return builder.ToString();
        }
    }
    
    // public static string HashPassword(string password)
    // {
    //     int iterations = 100_000;
    //     byte[] salt = RandomNumberGenerator.GetBytes(16); // 16 byte rastgele salt
    //
    //     using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512);
    //     byte[] hash = pbkdf2.GetBytes(64); // SHA-512 çıktısı = 64 byte
    //
    //     // Salt + Hash'ı Base64 formatında birleştirip sakla
    //     return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}:{iterations}";
    // }
    //
    // public static bool VerifyPassword(string password, string storedHash)
    // {
    //     var parts = storedHash.Split(':');
    //     if (parts.Length != 3)
    //         return false;
    //
    //     byte[] salt = Convert.FromBase64String(parts[0]);
    //     byte[] expectedHash = Convert.FromBase64String(parts[1]);
    //     int iterations = int.Parse(parts[2]);
    //
    //     using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512);
    //     byte[] actualHash = pbkdf2.GetBytes(64);
    //
    //     return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
    // }
    
}