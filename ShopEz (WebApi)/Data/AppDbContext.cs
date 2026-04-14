using Microsoft.EntityFrameworkCore;
using ShopEz;
using ShopEz.Models;

namespace ShopEz.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Total).HasPrecision(18, 2);

                entity.HasMany(e => e.Items)
                    .WithOne()
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Qty).IsRequired();
                entity.Property(e => e.Price).HasPrecision(18, 2);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(e => e.ProductId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Desc).HasMaxLength(1000);
                entity.Property(e => e.Price).HasPrecision(18, 2);
                entity.Property(e => e.Stock).IsRequired();
            });

            modelBuilder.Entity<Product>().HasData(
       new Product { Id = 1, Name = "Laptop", Desc = "Dell Laptop", Price = 50000, Stock = 10 },
       new Product { Id = 2, Name = "Mobile", Desc = "Samsung Mobile", Price = 20000, Stock = 15 },
       new Product { Id = 3, Name = "Headphones", Desc = "Sony Headphones", Price = 3000, Stock = 20 }
   );
        }
    }
}