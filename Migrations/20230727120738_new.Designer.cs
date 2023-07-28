﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _3DModels.Models;

#nullable disable

namespace _3DModels.Migrations
{
    [DbContext(typeof(ModelDbContext))]
    [Migration("20230727120738_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_3DModels.Models.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModelId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ModelId");

                    b.ToTable("model");
                });

            modelBuilder.Entity("_3DModels.Models.ModelAccessories", b =>
                {
                    b.Property<int>("Accessories_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Accessories_id"), 1L, 1);

                    b.Property<string>("Accessories_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Filepath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Accessories_id");

                    b.ToTable("ModelAccessories");
                });

            modelBuilder.Entity("_3DModels.Models.ModelCoordinator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExperienceYears")
                        .HasColumnType("int");

                    b.Property<DateTime?>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsibilities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ModelCoordinators");
                });

            modelBuilder.Entity("_3DModels.Models.ModelDesigner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ModelDesigners");
                });

            modelBuilder.Entity("_3DModels.Models.Orders", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("order_id"), 1L, 1);

                    b.Property<int>("Accessories_id")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("cancelled_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("completed_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("order_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("shipping_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shipping_method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tracking_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("transaction_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("order_id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("_3DModels.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductCategoryid")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("_3DModels.Models.ProductCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("_3DModels.Models.ThreeDModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfVertices")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ThreeDModels");
                });

            modelBuilder.Entity("_3DModels.Models.Users", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("_3DModels.Models.Product", b =>
                {
                    b.HasOne("_3DModels.Models.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
