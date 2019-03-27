using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Common.Models
{
    public partial class TestGeorgeContext : DbContext
    {
        //Scaffold-DbContext "Server=LAPTOP-P43ISKIL\\SQLEXPRESS;Database=TestGeorge;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
        public TestGeorgeContext()
        {
        }

        public TestGeorgeContext(DbContextOptions<TestGeorgeContext> options) : base(options)
        {
        }

        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblSubCategory> TblSubCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-P43ISKIL\\SQLEXPRESS;Database=TestGeorge;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.ToTable("tblCategory");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.ToTable("tblProduct");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_tblProduct_tblSubCategory");
            });

            modelBuilder.Entity<TblSubCategory>(entity =>
            {
                entity.ToTable("tblSubCategory");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblSubCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSubCategory_tblCategory");
            });
        }
    }
}
