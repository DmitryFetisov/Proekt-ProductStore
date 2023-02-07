

using Microsoft.EntityFrameworkCore;
using ProductStore.Data.Models;


namespace ProductStore.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<ShoppingCart> shoppingCarts { get; set; } = null!;

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
    }
}
