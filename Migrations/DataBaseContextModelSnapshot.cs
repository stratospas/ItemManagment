﻿// <auto-generated />
using ItemManagment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ItemManagment.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ItemManagment.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            Number = 1
                        },
                        new
                        {
                            DepartmentId = 2,
                            Number = 2
                        },
                        new
                        {
                            DepartmentId = 3,
                            Number = 3
                        },
                        new
                        {
                            DepartmentId = 4,
                            Number = 4
                        });
                });

            modelBuilder.Entity("ItemManagment.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Internal_code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Serial_number")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lenovo H/Y i5",
                            Internal_code = "E/B/0000",
                            Serial_number = "AASSDD8875"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lenovo H/Y i5",
                            Internal_code = "E/B/0000",
                            Serial_number = "AASSDD8975"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lenovo Screen 24\"",
                            Internal_code = "E/B/1111",
                            Serial_number = "AASSDD2222"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Xiaomi RedMi Note 8",
                            Internal_code = "E/B/1110",
                            Serial_number = "AASSDD0000"
                        });
                });

            modelBuilder.Entity("ItemManagment.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            DepartmentId = 1,
                            Lastname = "Πασχαλίδης",
                            Name = "Στράτος"
                        },
                        new
                        {
                            PersonId = 2,
                            DepartmentId = 2,
                            Lastname = "Παπαδόπουλος",
                            Name = "Αλέξανδρος"
                        });
                });

            modelBuilder.Entity("ItemManagment.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");

                    b.HasData(
                        new
                        {
                            PlaceId = 1,
                            Floor = 14,
                            Number = 47
                        },
                        new
                        {
                            PlaceId = 2,
                            Floor = 14,
                            Number = 45
                        },
                        new
                        {
                            PlaceId = 3,
                            Floor = 14,
                            Number = 40
                        });
                });

            modelBuilder.Entity("ItemManagment.Models.Person", b =>
                {
                    b.HasOne("ItemManagment.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
