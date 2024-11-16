using ELibrary_2._0.Model.ProductModels;
using ELibrary_2._0.Model.SaleModels;
using ELibrary_2._0.Model.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Database
{
    public class ELibrary2DB : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Writer> Writers { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = @"Server = TIPU\SQLEXPRESS;
                                        Database = ELibrary_2.0;
                                        Trusted_Connection = True;
                                        TrustServerCertificate = True;";

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Cover>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Publisher>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Writer>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Image>().HasIndex(c => c.ImageURL).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<PaymentMethod>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<Permission>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(c => c.UserName).IsUnique();
            modelBuilder.Entity<UserType>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<UserPermission>().HasOne(u => u.UserType)
                                                 .WithMany(up => up.UserPermissions)
                                                 .HasForeignKey(u => u.UserTypeID);

            modelBuilder.Entity<UserPermission>().HasOne(p => p.Permission)
                                                 .WithMany(up => up.UserPermissions)
                                                 .HasForeignKey(p => p.PermissionID);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
