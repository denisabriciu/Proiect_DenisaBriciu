﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_DenisaBriciu.Data;

#nullable disable

namespace Proiect_DenisaBriciu.Migrations
{
    [DbContext(typeof(Proiect_DenisaBriciuContext))]
    [Migration("20230118155000_Member")]
    partial class Member
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_DenisaBriciu.Models.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Proiect_DenisaBriciu.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("BrandID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ManufacturingYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Proiect_DenisaBriciu.Models.CarCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("CategoryID");

                    b.ToTable("CarCategory");
                });

            modelBuilder.Entity("Proiect_DenisaBriciu.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Proiect_DenisaBriciu.Models.Car", b =>
                {
                    b.HasOne("Proiect_DenisaBriciu.Models.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandID");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Proiect_DenisaBriciu.Models.CarCategory", b =>
                {
                    b.HasOne("Proiect_DenisaBriciu.Models.Car", "Car")
                        .WithMany("CarCategories")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_DenisaBriciu.Models.Category", "Category")
                        .WithMany("CarCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Proiect_DenisaBriciu.Models.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Proiect_DenisaBriciu.Models.Car", b =>
                {
                    b.Navigation("CarCategories");
                });

            modelBuilder.Entity("Proiect_DenisaBriciu.Models.Category", b =>
                {
                    b.Navigation("CarCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
