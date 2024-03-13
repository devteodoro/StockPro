using StockPro.Data.Mappings;
using StockPro.Models;
using Microsoft.EntityFrameworkCore;

namespace StockPro.Data
{
    public class StockProDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=DESKTOP-NBS1IAP\SQLEXPRESS;Initial Catalog=StockPro;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}