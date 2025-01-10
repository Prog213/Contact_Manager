using Contact_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact_Manager.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Contact> Contacts { get; set; } = null!;
    }
}
