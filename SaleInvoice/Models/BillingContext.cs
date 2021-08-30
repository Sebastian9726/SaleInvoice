using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SaleInvoice.Models
{
    public partial class BillingContext : DbContext
    {
        public BillingContext()
        {
        }

        public BillingContext(DbContextOptions<BillingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductSold> ProductSold { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Sold> Sold { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CONTABILIDAD03\\SQLEXPRESS;Database=Billing;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PK__Customer__DB43864ACB93F23F");

                entity.Property(e => e.DateCustomer)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NameCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK_Product_1");

                entity.Property(e => e.DescriptionProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameProduct)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductSold>(entity =>
            {
                entity.Property(e => e.RegisterSold).HasColumnType("datetime");

                entity.HasOne(d => d.IdProductSoldNavigation)
                    .WithMany(p => p.ProductSold)
                    .HasForeignKey(d => d.IdProductSold)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSold_Sold");

                entity.HasOne(d => d.IdProductSold1)
                    .WithMany(p => p.ProductSold)
                    .HasForeignKey(d => d.IdProductSold)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSold_Product");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.IdSeller)
                    .HasName("PK__Seller__B25ADA38A2635493");

                entity.Property(e => e.IdCard)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameSeller)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sold>(entity =>
            {
                entity.Property(e => e.Registration).HasColumnType("datetime");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Sold)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sold_Customer");

                entity.HasOne(d => d.IdSellerNavigation)
                    .WithMany(p => p.Sold)
                    .HasForeignKey(d => d.IdSeller)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sold_Seller");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
