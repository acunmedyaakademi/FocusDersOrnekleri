using ConsoleStudentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleStudentManagement.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Todo> Todos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost;Database=ConsoleStudentManagementAppDb;User Id=sa;Password=StrongPass123;TrustServerCertificate=True;");
    }
}
