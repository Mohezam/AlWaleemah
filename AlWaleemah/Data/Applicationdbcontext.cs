using AlWaleemah.Models;
using Microsoft.EntityFrameworkCore;

namespace AlWaleemah.Data
{
    public class Applicationdbcontext : DbContext

    {
        public Applicationdbcontext(DbContextOptions<Applicationdbcontext> options) : base(options)
        {
        }


        public DbSet<Category> Categories { get; set; }

        public DbSet<Cat2> Categorie2 { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat2>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic gadgets and devices", price = 50 },
                new Category { Id = 2, Name = "Clothing", Description = "Apparel and accessories", price = 30 },
                new Category { Id = 3, Name = "Books", Description = "Fiction and non-fiction books", price = 20 }
            );

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }




    }
}
