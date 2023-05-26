﻿// <auto-generated />
using System;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingAPI.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20230526113600_booking-second-migration")]
    partial class bookingsecondmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookingAPI.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"), 1L, 1);

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("NumOfDays")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<double?>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            BookingId = 101,
                            HotelID = 101,
                            NumOfDays = 1,
                            RoomId = 102,
                            UserId = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
