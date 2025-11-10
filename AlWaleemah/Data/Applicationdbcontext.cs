using AlWaleemah.Models;
using Microsoft.EntityFrameworkCore;

namespace AlWaleemah.Data
{
    public class Applicationdbcontext : DbContext

    {
        public Applicationdbcontext(DbContextOptions<Applicationdbcontext> options) : base(options)
        {
        }


        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Utility> Utilities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CartItem> CartItems { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تكوين الـ Utility
            modelBuilder.Entity<Utility>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Value).IsRequired().HasMaxLength(200);
                entity.Property(u => u.Description).HasMaxLength(500);
                entity.Property(u => u.Category).HasMaxLength(100);
                entity.Property(u => u.Type).IsRequired().HasConversion<string>();
            });





            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    base.OnModelCreating(modelBuilder);
            //    modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Category)
            //     .WithMany(c => c.Products)   // ← مطابق لاسم ICollection في Category
            //      .HasForeignKey(p => p.CategoryId)
            //    .OnDelete(DeleteBehavior.Cascade); // Optional: Define delete behaviorz

            //}

        }
    }
}




        

