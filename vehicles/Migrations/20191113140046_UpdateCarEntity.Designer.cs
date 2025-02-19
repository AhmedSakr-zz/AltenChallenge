﻿// <auto-generated />
using System;
using Infrastructure.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace vehicles.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191113140046_UpdateCarEntity")]
    partial class UpdateCarEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("CurrentStatusId");

                    b.Property<int>("CustomerId");

                    b.Property<int?>("DeletedById");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("RegNo")
                        .HasMaxLength(6);

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("VehicleId")
                        .HasMaxLength(17);

                    b.HasKey("Id");

                    b.HasIndex("CurrentStatusId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5107),
                            CurrentStatusId = 1,
                            CustomerId = 1,
                            RegNo = "ABC123",
                            VehicleId = "YS2R4X20005399401"
                        },
                        new
                        {
                            Id = 2,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5165),
                            CurrentStatusId = 1,
                            CustomerId = 1,
                            RegNo = "DEF456",
                            VehicleId = "VLUR4X20009093588"
                        },
                        new
                        {
                            Id = 3,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5169),
                            CurrentStatusId = 2,
                            CustomerId = 1,
                            RegNo = "GHI789",
                            VehicleId = "VLUR4X20009048066"
                        },
                        new
                        {
                            Id = 4,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5170),
                            CurrentStatusId = 1,
                            CustomerId = 2,
                            RegNo = "JKL012",
                            VehicleId = "YS2R4X20005388011"
                        },
                        new
                        {
                            Id = 5,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5175),
                            CurrentStatusId = 1,
                            CustomerId = 2,
                            RegNo = "MNO345",
                            VehicleId = "YS2R4X20005387949"
                        },
                        new
                        {
                            Id = 6,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5182),
                            CurrentStatusId = 1,
                            CustomerId = 3,
                            RegNo = "PQR678",
                            VehicleId = "VLUR4X20009048066"
                        },
                        new
                        {
                            Id = 7,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5184),
                            CurrentStatusId = 2,
                            CustomerId = 3,
                            RegNo = "STU901",
                            VehicleId = "YS2R4X20005387055"
                        });
                });

            modelBuilder.Entity("Domain.Entities.CarStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("CarStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Connected"
                        },
                        new
                        {
                            Id = 2,
                            Name = "DisConnected"
                        });
                });

            modelBuilder.Entity("Domain.Entities.CarStatusTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedById");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<int>("StatusId");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("StatusId");

                    b.ToTable("CarStatusTransactions");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(400);

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DeletedById");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("FullName")
                        .HasMaxLength(150);

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Cementvägen 8, 111 11 Södertälje",
                            CreatedById = -1,
                            CreatedDate = new DateTime(2019, 11, 13, 16, 0, 46, 557, DateTimeKind.Local).AddTicks(4947),
                            FullName = "Kalles Grustransporter AB"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Balkvägen 12, 222 22 Stockholm",
                            CreatedById = -1,
                            CreatedDate = new DateTime(2019, 11, 13, 16, 0, 46, 561, DateTimeKind.Local).AddTicks(7806),
                            FullName = "Johans Bulk AB"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Budgetvägen 1, 333 33 Uppsala",
                            CreatedById = -1,
                            CreatedDate = new DateTime(2019, 11, 13, 16, 0, 46, 561, DateTimeKind.Local).AddTicks(7839),
                            FullName = "Haralds Värdetransporter AB"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.HasOne("Domain.Entities.CarStatus", "CarStatus")
                        .WithMany("Cars")
                        .HasForeignKey("CurrentStatusId");

                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany("Cars")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.CarStatusTransaction", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("StatusTransactions")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.CarStatus", "CarStatus")
                        .WithMany("StatusTransactions")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
