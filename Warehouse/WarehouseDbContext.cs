﻿using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse;

public partial class WarehouseDbContext : DbContext
{
    public WarehouseDbContext()
    {
    }

    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderMethod> OrderMethods { get; set; }

    public virtual DbSet<OrderReturn> OrderReturns { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<ReturnReason> ReturnReasons { get; set; }

    public virtual DbSet<Voivodeship> Voivodeships { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sqlserver,1433;Database=WarehouseDB;User Id=sa;Password=zaq1@WSX;MultipleActiveResultSets=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2A1B7BE2926E");

            entity.ToTable("Address");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.CityId).HasColumnName("CityID");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_City");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21A9681D93BCF");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.VoivodeshipId).HasColumnName("VoivodeshipID");

            entity.HasOne(d => d.Voivodeship).WithMany(p => p.Cities)
                .HasForeignKey(d => d.VoivodeshipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Voivodeship");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D160BFB5A1AD1C");

            entity.ToTable("Country");

            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CountryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B87EB3C008");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.CustomerLastName).HasMaxLength(100);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customers_Address");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFD0F8ABE5");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderMethodId).HasColumnName("OrderMethodID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.OrderMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_OrderMethod");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C06294680");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<OrderMethod>(entity =>
        {
            entity.HasKey(e => e.OrderMethodId).HasName("PK__OrderMet__C8FAE16D50DEF0C8");

            entity.ToTable("OrderMethod");

            entity.Property(e => e.OrderMethodId).HasColumnName("OrderMethodID");
            entity.Property(e => e.MethodName).HasMaxLength(100);
        });

        modelBuilder.Entity<OrderReturn>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__OrderRet__F445E988199E15C1");

            entity.ToTable("OrderReturn");

            entity.Property(e => e.ReturnId).HasColumnName("ReturnID");
            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnReasonId).HasColumnName("ReturnReasonID");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.OrderReturns)
                .HasForeignKey(d => d.OrderDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Returns_OrderDetails");

            entity.HasOne(d => d.ReturnReason).WithMany(p => p.OrderReturns)
                .HasForeignKey(d => d.ReturnReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Returns_ReturnReason");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED9A140558");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductType");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("PK__ProductT__A1312F4EDE42ED52");

            entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");
            entity.Property(e => e.ProductTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<ReturnReason>(entity =>
        {
            entity.HasKey(e => e.ReturnReasonId).HasName("PK__ReturnRe__CEA351AEE365BE71");

            entity.ToTable("ReturnReason");

            entity.Property(e => e.ReturnReasonId).HasColumnName("ReturnReasonID");
            entity.Property(e => e.ReasonDescription).HasMaxLength(200);
        });

        modelBuilder.Entity<Voivodeship>(entity =>
        {
            entity.HasKey(e => e.VoivodeshipId).HasName("PK__Voivodes__5F80A66C68D02626");

            entity.ToTable("Voivodeship");

            entity.Property(e => e.VoivodeshipId).HasColumnName("VoivodeshipID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.VoivodeshipName).HasMaxLength(100);

            entity.HasOne(d => d.Country).WithMany(p => p.Voivodeships)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Voivodeship_Country");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
