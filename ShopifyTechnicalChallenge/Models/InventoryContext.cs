using Microsoft.EntityFrameworkCore;

namespace ShopifyTechnicalChallenge.Models
{
    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<Category> Category { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(entity =>                
            {
                entity.HasKey(e => e.Id);
                
                entity.HasData(new Inventory
                {
                    Id = 1,
                    Name = "Item 1",
                    Description = "Item 1",
                    Category = "Home",
                    Price = 19.99,
                    Quantity = 10
                });

            });



            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasData(
                    new Category { Id = 1, Name = "Food" },
                    new Category { Id = 2, Name = "Clothing" },
                    new Category { Id = 3, Name = "Beauty" },
                    new Category { Id = 4, Name = "Home" },
                    new Category { Id = 5, Name = "Electronics" }
                    );

            });


            base.OnModelCreating(modelBuilder);
        }


   
    }
}
