using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SonQuangHuy.Models;
namespace SonQuangHuy.Models
{
    public partial class but73756_butterflycarairContext : DbContext
    {
        public but73756_butterflycarairContext()
        {
        }

        public but73756_butterflycarairContext(DbContextOptions<but73756_butterflycarairContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ColorTable> ColorTables { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=112.78.2.154;Database=but73756_butterflycarair;User=but73756_but73756;password=Quyet1702@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("but73756_but73756");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product1");

                entity.Property(e => e.Avatar).HasMaxLength(300);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Details1).HasMaxLength(4000);
                entity.Property(e => e.Details2).HasMaxLength(4000);
                entity.Property(e => e.Details3).HasMaxLength(4000);
                entity.Property(e => e.Details4).HasMaxLength(4000);
                entity.Property(e => e.Details5).HasMaxLength(4000);
                entity.Property(e => e.Details6).HasMaxLength(4000);
                entity.Property(e => e.Details7).HasMaxLength(4000);
                entity.Property(e => e.Details8).HasMaxLength(4000);

                entity.Property(e => e.DetailsImage).HasMaxLength(300);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName).HasMaxLength(300);

                entity.Property(e => e.ProductType).HasMaxLength(300);

                entity.Property(e => e.Unit).HasMaxLength(200);
            });
             modelBuilder.Entity<ColorTable>(entity =>
            {
                entity.ToTable("ColorTable");
                entity.Property(e => e.ColorName).HasMaxLength(50);
                entity.Property(e => e.ColorCode).HasMaxLength(20);
            });
             modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Avatar).HasMaxLength(300);

                entity.Property(e => e.BlogTitle).HasMaxLength(300);
                entity.Property(e => e.CreateDate).HasColumnType("datetime");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Details1).HasMaxLength(4000);
                entity.Property(e => e.Details2).HasMaxLength(4000);
                entity.Property(e => e.Details3).HasMaxLength(4000);
                entity.Property(e => e.Details4).HasMaxLength(4000);
                entity.Property(e => e.Details5).HasMaxLength(4000);
                entity.Property(e => e.Details6).HasMaxLength(4000);
                entity.Property(e => e.Details7).HasMaxLength(4000);
                entity.Property(e => e.Details8).HasMaxLength(4000);


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<SonQuangHuy.Models.Blog> Blog { get; set; }
    }
}
