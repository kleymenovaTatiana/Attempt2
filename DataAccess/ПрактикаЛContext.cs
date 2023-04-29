﻿using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Models
{
    public partial class ПрактикаЛContext : DbContext
    {
        public ПрактикаЛContext()
        {
        }

        public ПрактикаЛContext(DbContextOptions<ПрактикаЛContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BasketBuyer> BasketBuyers { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Filter> Filters { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Products1> Products1s { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketBuyer>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.LtemNumber })
                    .HasName("PK__Basket_B__46D3E7A4C0B5BC19");

                entity.ToTable("Basket_Buyer");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.LtemNumber).HasColumnName("ltem_number");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.BasketBuyers)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Basket_Bu__id_us__3B75D760");

                entity.HasOne(d => d.LtemNumberNavigation)
                    .WithMany(p => p.BasketBuyers)
                    .HasForeignKey(d => d.LtemNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Basket_Bu__ltem___3C69FB99");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("Category_name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.ClieNtCode)
                    .HasName("PK__Customer__39C9B648518119B2");

                entity.Property(e => e.ClieNtCode)
                    .ValueGeneratedNever()
                    .HasColumnName("ClieNt_code");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("Middle_name");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Nickname).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(25)
                    .HasColumnName("Phone_number");

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<Filter>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__filter__6DB281364929E364");

                entity.ToTable("filter");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Category_id");

                entity.Property(e => e.Aquariums)
                    .HasMaxLength(50)
                    .HasColumnName("aquariums");

                entity.Property(e => e.Bowls).HasMaxLength(50);

                entity.Property(e => e.Feed).HasMaxLength(50);

                entity.Property(e => e.Toys)
                    .HasMaxLength(50)
                    .HasColumnName("toys");

                entity.HasOne(d => d.Category)
                    .WithOne(p => p.Filter)
                    .HasForeignKey<Filter>(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__filter__Category__29572725");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.OrderCode, e.IdUser, e.LtemNumber, e.EmployeeCode })
                    .HasName("PK__Orders__6B8A3A3237D948EF");

                entity.Property(e => e.OrderCode).HasColumnName("Order_code");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.LtemNumber).HasColumnName("ltem_number");

                entity.Property(e => e.EmployeeCode).HasColumnName("Employee_Code");

                entity.Property(e => e.DateAndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_and_time");

                entity.Property(e => e.DeliveryMethod)
                    .HasMaxLength(50)
                    .HasColumnName("Delivery_method");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.EmployeeCodeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Employee__412EB0B6");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__id_user__3F466844");

                entity.HasOne(d => d.LtemNumberNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LtemNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__ltem_num__403A8C7D");
            });

            modelBuilder.Entity<Products1>(entity =>
            {
                entity.HasKey(e => e.LtemNumber)
                    .HasName("PK__Products__402A1938CD57E949");

                entity.ToTable("Products1");

                entity.Property(e => e.LtemNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("ltem_number");

                entity.Property(e => e.ArticleNumber).HasColumnName("Article_number");

                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.Cost).HasColumnType("decimal(25, 2)");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.NumberInClade).HasColumnName("Number_in_clade");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products1s)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products1__Numbe__30F848ED");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasKey(e => e.EmployeeCode)
                    .HasName("PK__Staff__AB80DE19447E56BD");

                entity.ToTable("Staff");

                entity.Property(e => e.EmployeeCode)
                    .ValueGeneratedNever()
                    .HasColumnName("Employee_code");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("Middle_name");

                entity.Property(e => e.Namee).HasMaxLength(50);

                entity.Property(e => e.Nickname).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(25)
                    .HasColumnName("Phone_number");

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
