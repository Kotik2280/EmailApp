using Microsoft.EntityFrameworkCore;

namespace EmailApp.Models
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
