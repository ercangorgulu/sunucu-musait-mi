﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SunucuMusaitMi.Persistance;

namespace SunucuMusaitMi.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200726213434_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("SunucuMusaitMi.Domain.ServerAvailability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConnectedUser")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerIp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServerAvailability");
                });
#pragma warning restore 612, 618
        }
    }
}
