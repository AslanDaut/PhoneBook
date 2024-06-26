using Microsoft.EntityFrameworkCore;
using PhoneBook.Model;

namespace PhoneBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}