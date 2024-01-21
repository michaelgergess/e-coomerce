using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Context
{
    public class Context :DbContext
    {
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetails> CartDetails { get; set; }
       
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategorys { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MICHAEL-PC\\SQLEXPRESS;Initial Catalog=E-CommerceITI;Integrated Security=True;encrypt =false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
         .HasOne(a => a.admin)
         .WithMany()
         .HasForeignKey(a => a.AdmanId)
         .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
       .HasOne(p => p.ProductCategory)
       .WithMany(pc => pc.Products)
       .HasForeignKey(p => p.ProductCategoryId)
       .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
