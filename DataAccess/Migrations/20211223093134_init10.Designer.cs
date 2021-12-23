﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(WebApiDbContext))]
    [Migration("20211223093134_init10")]
    partial class init10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Entities.AutPersonCredential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AutPersonCredentials");
                });

            modelBuilder.Entity("Entities.Buses.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BusId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.Cities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Entities.ContentArea", b =>
                {
                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductContentId")
                        .HasColumnType("int");

                    b.HasKey("AreaId", "ProductContentId");

                    b.HasIndex("ProductContentId");

                    b.ToTable("ContentAreas");
                });

            modelBuilder.Entity("Entities.Customers.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChildId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Entities.Expeditions.Expedition", b =>
                {
                    b.Property<int>("ExpeditionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArrivalCityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartureCityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ExpeditionId");

                    b.HasIndex("ArrivalCityId");

                    b.HasIndex("BusId");

                    b.HasIndex("DepartureCityId");

                    b.ToTable("Expeditions");
                });

            modelBuilder.Entity("Entities.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDetail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entities.ProductCom", b =>
                {
                    b.Property<int>("ProductComId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("ProductContentId")
                        .HasColumnType("int");

                    b.Property<string>("ProductNameForeignLan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductComId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ProductContentId");

                    b.ToTable("ProductComs");
                });

            modelBuilder.Entity("Entities.ProductContent", b =>
                {
                    b.Property<int>("ProductContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ProductContentId");

                    b.ToTable("ProductContents");
                });

            modelBuilder.Entity("Entities.ProductSupply", b =>
                {
                    b.Property<int>("ProductSupplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ProductContentId")
                        .HasColumnType("int");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductSupplyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductContentId");

                    b.ToTable("ProductSupplies");
                });

            modelBuilder.Entity("Entities.Reservation.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ExpeditionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExpeditionId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.ContentArea", b =>
                {
                    b.HasOne("Entities.Area", "Area")
                        .WithMany("ContentAreas")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.ProductContent", "ProductContent")
                        .WithMany("ContentAreas")
                        .HasForeignKey("ProductContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("ProductContent");
                });

            modelBuilder.Entity("Entities.Employee", b =>
                {
                    b.HasOne("Entities.Employee", "Parent")
                        .WithMany("SubChild")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Entities.Expeditions.Expedition", b =>
                {
                    b.HasOne("Entities.Cities.City", "City1")
                        .WithMany()
                        .HasForeignKey("ArrivalCityId");

                    b.HasOne("Entities.Buses.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Cities.City", "City")
                        .WithMany()
                        .HasForeignKey("DepartureCityId");

                    b.Navigation("Bus");

                    b.Navigation("City");

                    b.Navigation("City1");
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.HasOne("Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.ProductCom", b =>
                {
                    b.HasOne("Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.ProductContent", "ProductContent")
                        .WithMany()
                        .HasForeignKey("ProductContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("ProductContent");
                });

            modelBuilder.Entity("Entities.ProductSupply", b =>
                {
                    b.HasOne("Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.ProductContent", "ProductContent")
                        .WithMany()
                        .HasForeignKey("ProductContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("ProductContent");
                });

            modelBuilder.Entity("Entities.Reservation.Reservation", b =>
                {
                    b.HasOne("Entities.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Expeditions.Expedition", "Expedition")
                        .WithMany()
                        .HasForeignKey("ExpeditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Expedition");
                });

            modelBuilder.Entity("Entities.Area", b =>
                {
                    b.Navigation("ContentAreas");
                });

            modelBuilder.Entity("Entities.Employee", b =>
                {
                    b.Navigation("SubChild");
                });

            modelBuilder.Entity("Entities.ProductContent", b =>
                {
                    b.Navigation("ContentAreas");
                });
#pragma warning restore 612, 618
        }
    }
}
