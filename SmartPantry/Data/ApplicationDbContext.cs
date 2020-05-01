using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartPantry.Models;

namespace SmartPantry.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pantry> Pantries { get; set; }
        public DbSet<GroceryList> GroceryLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplicationUser user = new ApplicationUser
            {
                Name = "Admina Straytor",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Beverages"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Bread/Grains"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Canned Goods"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Refrigerated Goods"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Dairy"
                },
                 new Category()
                 {
                     Id = 6,
                     Name = "Dry Goods"
                 },
                new Category()
                {
                    Id = 7,
                    Name = "Frozen Foods"
                },
                new Category()
                {
                    Id = 8,
                    Name = "Meat"
                },
                new Category()
                {
                    Id = 9,
                    Name = "Produce"
                },
                new Category()
                {
                    Id = 10,
                    Name = "Snacks"
                },
                new Category()
                {
                    Id = 11,
                    Name = "Spices"
                },
                new Category()
                {
                    Id = 12,
                    Name = "Other"
                }
            );


        }

    }
}
