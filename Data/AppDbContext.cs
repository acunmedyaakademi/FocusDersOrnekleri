using Microsoft.EntityFrameworkCore;
using UserRoles.Models;

namespace UserRoles.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    // eğer rolleri sabit bir yapı üzerinde yönetmek istiyorsak
    // enumları veritabanına göndermemize gerek yok
    // neden? çünkü güncelleme olmayacak
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost;Database=UserRolesDb;User Id=sa;Password=StrongPass123;TrustServerCertificate=True;");
    }
}