using ConsoleChatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleChatApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=159.253.37.34\\MSSQLSERVER2019;Database=akadem67_chat;User Id=akadem67_chatuser;Password=o?5Nn76j6;TrustServerCertificate=True;");
    }
}