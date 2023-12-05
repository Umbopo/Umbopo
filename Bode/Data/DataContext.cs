using Bode.Models;
using Microsoft.EntityFrameworkCore;

namespace Bode.Data
{
    class DataContext : DbContext
    {
        public DbSet<Province> Provinces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BodeDB.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().ToTable("Provinces");
        }
    }
}
