﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentCarSystem.Data;

#nullable disable

namespace RentCarSystem.Migrations
{
    [DbContext(typeof(RentCarSystemContext))]
    partial class RentCarSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("RentCarSystem.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("RentCarSystem.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreditCardNumber")
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<double>("CreditLimit")
                        .HasColumnType("REAL");

                    b.Property<string>("IdentificationCard")
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("RentCarSystem.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CommissionPercentage")
                        .HasColumnType("REAL");

                    b.Property<string>("IdentificationCard")
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkSchedule")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("RentCarSystem.Models.FuelTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("RentCarSystem.Models.Inspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountOfFuel")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasBrokenGlass")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasHydraulicJack")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasReplacementWheel")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasScratches")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VehiculeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WheelState1")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WheelState2")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WheelState3")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WheelState4")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VehiculeId");

                    b.ToTable("Inspection");
                });

            modelBuilder.Entity("RentCarSystem.Models.RentAndDevolution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AmountPerDay")
                        .HasColumnType("REAL");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DevolutionDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("RentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VehiculeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VehiculeId");

                    b.ToTable("RentAndDevolution");
                });

            modelBuilder.Entity("RentCarSystem.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("VehiculeType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("RentCarSystem.Models.Vehicule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChasisNumber")
                        .HasMaxLength(17)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FuelTypesId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRented")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MotorNumber")
                        .HasMaxLength(17)
                        .HasColumnType("TEXT");

                    b.Property<string>("PlateNumber")
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VehiculeModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VehiculeTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("FuelTypesId");

                    b.HasIndex("VehiculeModelId");

                    b.HasIndex("VehiculeTypeId");

                    b.ToTable("Vehicule");
                });

            modelBuilder.Entity("RentCarSystem.Models.VehiculeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("VehiculeModel");
                });

            modelBuilder.Entity("RentCarSystem.Models.VehiculeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("VehiculeType");
                });

            modelBuilder.Entity("RentCarSystem.Models.Inspection", b =>
                {
                    b.HasOne("RentCarSystem.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("RentCarSystem.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RentCarSystem.Models.Vehicule", "Vehicule")
                        .WithMany()
                        .HasForeignKey("VehiculeId");

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("Vehicule");
                });

            modelBuilder.Entity("RentCarSystem.Models.RentAndDevolution", b =>
                {
                    b.HasOne("RentCarSystem.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("RentCarSystem.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RentCarSystem.Models.Vehicule", "Vehicule")
                        .WithMany()
                        .HasForeignKey("VehiculeId");

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("Vehicule");
                });

            modelBuilder.Entity("RentCarSystem.Models.Vehicule", b =>
                {
                    b.HasOne("RentCarSystem.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("RentCarSystem.Models.FuelTypes", "FuelTypes")
                        .WithMany()
                        .HasForeignKey("FuelTypesId");

                    b.HasOne("RentCarSystem.Models.VehiculeModel", "VehiculeModel")
                        .WithMany()
                        .HasForeignKey("VehiculeModelId");

                    b.HasOne("RentCarSystem.Models.VehiculeType", "VehiculeType")
                        .WithMany()
                        .HasForeignKey("VehiculeTypeId");

                    b.Navigation("Brand");

                    b.Navigation("FuelTypes");

                    b.Navigation("VehiculeModel");

                    b.Navigation("VehiculeType");
                });
#pragma warning restore 612, 618
        }
    }
}
