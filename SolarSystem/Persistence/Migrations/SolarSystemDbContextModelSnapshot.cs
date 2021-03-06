﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SolarSystem.Persistence;

namespace SolarSystem.Persistence.Migrations
{
    [DbContext(typeof(SolarSystemDbContext))]
    partial class SolarSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("SolarSystem.Domain.Entities.Planet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("Au")
                        .HasColumnType("REAL");

                    b.Property<double>("Density")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double>("Eccentricity")
                        .HasColumnType("REAL");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<double>("Inclination")
                        .HasColumnType("REAL");

                    b.Property<string>("Introduction")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<double>("Mass")
                        .HasColumnType("REAL");

                    b.Property<int>("Moons")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ordinal")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Period")
                        .HasColumnType("REAL");

                    b.Property<int>("Radius")
                        .HasColumnType("INTEGER");

                    b.Property<double>("RotationPeriod")
                        .HasColumnType("REAL");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Tilt")
                        .HasColumnType("REAL");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<double>("Velocity")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Planets");
                });
#pragma warning restore 612, 618
        }
    }
}
