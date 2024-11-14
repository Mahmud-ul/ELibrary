using ELibraryApp.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Database.Database
{
    public class ELibraryAppDB : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source = TIPU\SQLEXPRESS;
                                        Database = ELibraryAppDB;
                                        Trusted_Connection = True;
                                        Encrypt = False;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(b => b.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(b => b.Name).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(b => b.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(b => b.UserName).IsUnique();
            modelBuilder.Entity<User>().HasIndex(b => b.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(b => b.Phone).IsUnique();
            modelBuilder.Entity<PaymentMethod>().HasIndex(b => b.Name).IsUnique();
            modelBuilder.Entity<Publisher>().HasIndex(b => b.Name).IsUnique();
            modelBuilder.Entity<Writer>().HasIndex(b => b.Name).IsUnique();

            modelBuilder.Entity<SaleProduct>().HasKey(c => new { c.SaleID, c.ProductID });

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
