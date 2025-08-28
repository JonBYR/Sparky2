using Microsoft.EntityFrameworkCore;
using Sparky2.Models.Models;

namespace Sparky2.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Category> Categories { get; set; } // Replace with your actual DbSet properties
        public DbSet<Product> Products { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Pineapple" },
                    new Category { Id = 2, Name = "Tomato" },
                    new Category { Id = 3, Name = "Celery" }
                );
            
        }
    }
}
