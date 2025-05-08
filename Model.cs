using Microsoft.EntityFrameworkCore;

namespace ConsoleDb;

public class AppDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost;Database=ConsoleAppDb;User Id=sa;Password=StrongPass123;TrustServerCertificate=True;");
    }
}

public class Todo
{
    public int Id { get; set; }
    public string Task { get; set; }
    public bool Completed { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
}