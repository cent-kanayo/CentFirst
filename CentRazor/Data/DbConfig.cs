using CentRazor.Models;
using Microsoft.EntityFrameworkCore;


namespace CentRazor.Data
{

    public class DbConfig : DbContext
    {
        public DbConfig(DbContextOptions<DbConfig> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SCI-FI", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}
