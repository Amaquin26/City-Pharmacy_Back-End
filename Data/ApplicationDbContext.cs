using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CityPharmacyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CityPharmacyAPI.Data
{
    public class DbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderItem>().HasNoKey();

            modelBuilder.Entity<OrderItem>()
                    .HasKey(pc => new { pc.MedicineId, pc.OrderId, pc.ProductId });
            modelBuilder.Entity<OrderItem>()
                    .HasOne(p => p.Product)
                    .WithMany(pc => pc.OrderItems)
                    .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<OrderItem>()
                    .HasOne(p => p.Order)
                    .WithMany(pc => pc.OrderItems)
                    .HasForeignKey(c => c.OrderId);
            modelBuilder.Entity<OrderItem>()
                    .HasOne(p => p.Medicine)
                    .WithMany(pc => pc.OrderItems)
                    .HasForeignKey(c => c.MedicineId);
        }
    }
}
