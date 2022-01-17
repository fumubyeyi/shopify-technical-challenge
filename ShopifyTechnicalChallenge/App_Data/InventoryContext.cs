using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ShopifyTechnicalChallenge.Models
{
    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(entity =>                
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Description);
                entity.Property(e => e.Price);
                entity.Property(e => e.Quantity);
                entity.Property(e => e.LastModified).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasData(new Inventory
                {
                    Id = 1,
                    Name = "Item 1",
                    Description = "Item 1",              
                    Price = 19.99,
                    Quantity = 10
                });

            });


            base.OnModelCreating(modelBuilder);
        }
   
    }
}
