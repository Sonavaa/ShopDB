

using Microsoft.EntityFrameworkCore;
using ShopDB.Models;

namespace ShopDB.Context
{
    internal class ShopDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JFOAGE0\\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Categories>? Categories { get; set; }
        public DbSet<Products>? Products { get; set; }
    }
}
