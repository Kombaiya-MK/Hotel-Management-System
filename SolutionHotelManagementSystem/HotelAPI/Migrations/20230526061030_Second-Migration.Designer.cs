﻿// <auto-generated />
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelAPI.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20230526061030_Second-Migration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelAPI.Models.Branch", b =>
                {
                    b.Property<int>("Branch_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Branch_Id"), 1L, 1);

                    b.Property<string>("Branch_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branch_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branch_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Branch_Id");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            Branch_Id = 101,
                            Branch_Location = "Sholinganallur",
                            Branch_Name = "Sholinganallur",
                            Branch_Phone = "9877262516"
                        });
                });

            modelBuilder.Entity("HotelAPI.Models.Hotel", b =>
                {
                    b.Property<int>("Hotel_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Hotel_Id"), 1L, 1);

                    b.Property<int>("Branch_id")
                        .HasColumnType("int");

                    b.Property<string>("Hotel_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Hotel_Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Hotel_Id = 101,
                            Branch_id = 101,
                            Hotel_Name = "XYZ Hotel"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
