using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WPF_BO
{
    public partial class wpfManagementContext : DbContext
    {
        public wpfManagementContext()
        {
        }
        
        public wpfManagementContext(DbContextOptions<wpfManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Pc> Pcs { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config.GetConnectionString("DBConnect");
            return strConn;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());

                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("accounts_userid_primary");

                entity.HasIndex(e => e.UserId, "UQ__Accounts__CB9A1CDE1DC16B3F")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasIndex(e => e.CategoryId, "UQ__Category__23CAF1F9FCC8CB2B")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<Pc>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("electronics_productid_primary");

                entity.ToTable("PC");

                entity.HasIndex(e => e.ProductId, "UQ__PC__2D10D14BBF1A9D12")
                    .IsUnique();

                entity.HasIndex(e => e.CategoryId, "pc_categoryid_index");

                entity.HasIndex(e => e.StoreId, "pc_storeid_index");

                entity.HasIndex(e => e.UserId, "pc_userid_index");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.ImageLink)
                    .HasMaxLength(255)
                    .HasColumnName("imageLink");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Review).HasColumnName("review");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StoreId).HasColumnName("storeID");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pc_categoryid_foreign");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("pc_storeid_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("pc_userid_foreign");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.HasIndex(e => e.StoreId, "UQ__Store__1EA71632BD63B92D")
                    .IsUnique();

                entity.Property(e => e.StoreId).HasColumnName("storeID");

                entity.Property(e => e.StoreLocation)
                    .HasMaxLength(255)
                    .HasColumnName("storeLocation");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
