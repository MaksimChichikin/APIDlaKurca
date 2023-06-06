using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lerkorin.Models
{
    public partial class _130123_ChichikinContext : DbContext
    {
        public _130123_ChichikinContext()
        {
        }

        public _130123_ChichikinContext(DbContextOptions<_130123_ChichikinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<All> Alls { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Catalog> Catalogs { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserActivity> UserActivities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=81.177.6.104, 1433; Database=130123_Chichikin; User ID=is221; Password =Student1234; Trusted_Connection=False; Integrated Security=False; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<All>(entity =>
            {
                entity.ToTable("All");

                entity.HasOne(d => d.IdTaskNavigation)
                    .WithMany(p => p.Alls)
                    .HasForeignKey(d => d.IdTask)
                    .HasConstraintName("FK_All_Task");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Alls)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_All_User");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.AddressBrand).HasMaxLength(100);

                entity.Property(e => e.BrandName).HasMaxLength(100);

                entity.Property(e => e.PhoneBrand).HasMaxLength(100);
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.ToTable("Catalog");

                entity.Property(e => e.NameOfProduct).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.Catalogs)
                    .HasForeignKey(d => d.IdBrand)
                    .HasConstraintName("FK_Catalog_Brand");

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithMany(p => p.Catalogs)
                    .HasForeignKey(d => d.IdUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalog_Unit1");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(100);
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_Delivery_Status");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdCatalogNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCatalog)
                    .HasConstraintName("FK_Order_Catalog1");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCompany)
                    .HasConstraintName("FK_Order_Company1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.HasOne(d => d.IdDeliveryNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdDelivery)
                    .HasConstraintName("FK_Task_Delivery1");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_Task_Order");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Login).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_User_Role");

                entity.HasOne(d => d.IdUserActivityNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdUserActivity)
                    .HasConstraintName("FK_User_UserActivity");
            });

            modelBuilder.Entity<UserActivity>(entity =>
            {
                entity.ToTable("UserActivity");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
