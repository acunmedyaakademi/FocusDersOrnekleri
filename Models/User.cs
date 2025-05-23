namespace UserRoles.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Roles Role { get; set; } = Roles.User;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

// enum kullanmamızın sebebi
// karşılaştırma yaparken kullanıyoruz
// avantajı okuduğumuzu anlamak
