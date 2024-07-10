﻿// <auto-generated />
using ItemManagment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ItemManagment.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240709085923_InitialWithItem")]
    partial class InitialWithItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

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
                });
#pragma warning restore 612, 618
        }
    }
}
