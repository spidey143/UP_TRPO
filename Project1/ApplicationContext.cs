using Microsoft.EntityFrameworkCore;

namespace Project1
{
    public class ApplicationContext : DbContext{

        public DbSet<User> Users { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ../../../employee.db");
        }
    }
}