using Microsoft.EntityFrameworkCore;

namespace PhonebookApp.Models;

public class ContactContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LC-THINKPAD\\SQLEXPRESS;Database=PhonebookDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Encrypt=False");
    }
}