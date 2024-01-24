﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkDataLayer.Model;

#nullable disable

namespace ParkDataLayer.Migrations
{
    [DbContext(typeof(ParkDbContext))]
    partial class ParkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkDataLayer.Model.Huis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Actief")
                        .HasColumnType("bit");

                    b.Property<int>("Nummer")
                        .HasColumnType("int");

                    b.Property<string>("ParkId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Straat")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ParkId");

                    b.ToTable("Huizen");
                });

            modelBuilder.Entity("ParkDataLayer.Model.Huurcontract", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("AantalDagen")
                        .HasColumnType("int");

                    b.Property<DateTime>("EindDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("HuisId")
                        .HasColumnType("int");

                    b.Property<int>("HuurderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HuisId");

                    b.HasIndex("HuurderId");

                    b.ToTable("Huurcontracten");
                });

            modelBuilder.Entity("ParkDataLayer.Model.Huurder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefoon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Huurders");
                });

            modelBuilder.Entity("ParkDataLayer.Model.Park", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Locatie")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Parks");
                });

            modelBuilder.Entity("ParkDataLayer.Model.Huis", b =>
                {
                    b.HasOne("ParkDataLayer.Model.Park", "Park")
                        .WithMany("Huizen")
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Park");
                });

            modelBuilder.Entity("ParkDataLayer.Model.Huurcontract", b =>
                {
                    b.HasOne("ParkDataLayer.Model.Huis", "Huis")
                        .WithMany("Huurcontracten")
                        .HasForeignKey("HuisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkDataLayer.Model.Huurder", "Huurder")
                        .WithMany()
                        .HasForeignKey("HuurderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Huis");

                    b.Navigation("Huurder");
                });

            modelBuilder.Entity("ParkDataLayer.Model.Huis", b =>
                {
                    b.Navigation("Huurcontracten");
                });

            modelBuilder.Entity("ParkDataLayer.Model.Park", b =>
                {
                    b.Navigation("Huizen");
                });
#pragma warning restore 612, 618
        }
    }
}
