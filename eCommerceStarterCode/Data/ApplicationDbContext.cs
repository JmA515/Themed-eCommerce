using eCommerceStarterCode.Configuration;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStarterCode.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {


        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasData(new Product { ProductId = 1, ProductName = "The Old Man and The Sea", ProductDescription = "By: Ernest Hemmingway", Genre = "Fiction", Price = 15}
                );
            modelBuilder.Entity<ShoppingCart>();
            modelBuilder.Entity<Review>();

            modelBuilder.ApplyConfiguration(new RolesConfiguration());
        }

    }
}
