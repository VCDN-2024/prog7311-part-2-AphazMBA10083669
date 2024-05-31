using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergy_PROG7311POE2_ST10083669.Models;

public partial class AgriEnergyConnectPlatformContext : DbContext
{
    public AgriEnergyConnectPlatformContext()
    {
    }

    public AgriEnergyConnectPlatformContext(DbContextOptions<AgriEnergyConnectPlatformContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeLogin> EmployeeLogins { get; set; }

    public virtual DbSet<Farmer> Farmers { get; set; }

    public virtual DbSet<FarmerProduct> FarmerProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=AgriEnergyConnectPlatform; Encrypt=False; Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1F14D18C6");

            entity.HasIndex(e => e.Email, "UQ__Employee__A9D105343109EDB3").IsUnique();

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeLogin>(entity =>
        {
            entity.HasKey(e => e.LoginId).HasName("PK__Employee__4DDA28384059B013");

            entity.HasIndex(e => e.Username, "UQ__Employee__536C85E4156636C7").IsUnique();

            entity.Property(e => e.LoginId)
                .ValueGeneratedNever()
                .HasColumnName("LoginID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeLogins)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__EmployeeL__Emplo__7C4F7684");
        });

        modelBuilder.Entity<Farmer>(entity =>
        {
            entity.HasKey(e => e.FarmerId).HasName("PK__Farmers__731B88E8B9D65F3C");

            entity.HasIndex(e => e.Email, "UQ__Farmers__A9D1053436C63769").IsUnique();

            entity.Property(e => e.FarmerId)
                .ValueGeneratedNever()
                .HasColumnName("FarmerID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FarmAddress)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<FarmerProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__FarmerPr__B40CC6EDB60FCB58");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Farmer).WithMany(p => p.FarmerProducts)
                .HasForeignKey(d => d.FarmerId)
                .HasConstraintName("FK__FarmerPro__Farme__74AE54BC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
