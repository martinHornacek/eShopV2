using Basket.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Basket.API.Data
{
    public class BasketContext : DbContext
    {
        public BasketContext(DbContextOptions<BasketContext> options) : base(options)
        {
        }

        public DbSet<Model.Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Model.Basket>()
                .HasMany(b => b.BasketItems)
                .WithOne(b => b.Basket!)
                .HasForeignKey(b => b.new_basketid);

            modelBuilder
                .Entity<BasketItem>()
                .HasOne(bi => bi.Basket)
                .WithMany(bi => bi.BasketItems)
                .HasForeignKey(bi => bi.new_basketid);
        }
    }
}
