﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Product.Infrastructure.Persistence;

#nullable disable

namespace Product.Api.Migrations
{
    [DbContext(typeof(ProductDBContext))]
    [Migration("20230328191008_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Product.Domain.Entites.CategoryEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MinimumStock")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CreateDate = new DateTime(2023, 3, 28, 22, 10, 8, 238, DateTimeKind.Utc).AddTicks(168),
                            MinimumStock = 200,
                            Name = "Mobile Phone"
                        },
                        new
                        {
                            CategoryId = 2,
                            CreateDate = new DateTime(2023, 3, 28, 22, 10, 8, 238, DateTimeKind.Utc).AddTicks(206),
                            MinimumStock = 150,
                            Name = "PC"
                        });
                });

            modelBuilder.Entity("Product.Domain.Entites.ProductEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            CreateDate = new DateTime(2023, 3, 28, 22, 10, 8, 238, DateTimeKind.Utc).AddTicks(225),
                            Description = "Best mobile phone ever, buy it !",
                            Price = 0m,
                            Stock = 100,
                            Title = "iPhone 14"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            CreateDate = new DateTime(2023, 3, 28, 22, 10, 8, 238, DateTimeKind.Utc).AddTicks(227),
                            Description = "Best mobile phone ever, buy it !",
                            Price = 0m,
                            Stock = 100,
                            Title = "iPhone 14 PRO"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            CreateDate = new DateTime(2023, 3, 28, 22, 10, 8, 238, DateTimeKind.Utc).AddTicks(228),
                            Description = "Best personel computer ever, buy it !",
                            Price = 0m,
                            Stock = 100,
                            Title = "Mac M1 128GB"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            CreateDate = new DateTime(2023, 3, 28, 22, 10, 8, 238, DateTimeKind.Utc).AddTicks(229),
                            Description = "Best personel computer ever, buy it !",
                            Price = 0m,
                            Stock = 100,
                            Title = "Mac M2 256GB"
                        });
                });

            modelBuilder.Entity("Product.Domain.Entites.ProductEntity", b =>
                {
                    b.HasOne("Product.Domain.Entites.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Product.Domain.Entites.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
