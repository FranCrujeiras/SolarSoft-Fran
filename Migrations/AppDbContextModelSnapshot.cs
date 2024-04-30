﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SolarSoft_1._0.Context;

#nullable disable

namespace SolarSoft_1._0.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SolarSoft_1._0.Models.Bateria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Capacidad")
                        .HasColumnType("float");

                    b.Property<string>("ModeloBateria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Modulos")
                        .HasColumnType("int");

                    b.Property<double>("PotenciaSalida")
                        .HasColumnType("float");

                    b.Property<int>("VoltajeNominal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bateria");
                });

            modelBuilder.Entity("SolarSoft_1._0.Models.Inversor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("EficienciaEuropea")
                        .HasColumnType("float");

                    b.Property<string>("ModeloInversor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroMPPT")
                        .HasColumnType("int");

                    b.Property<double>("PotenciaEntrada")
                        .HasColumnType("float");

                    b.Property<double>("PotenciaSalida")
                        .HasColumnType("float");

                    b.Property<int>("VoltajeMaximoMPPT")
                        .HasColumnType("int");

                    b.Property<int>("VoltajeMinimoMPPT")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Inversor");
                });

            modelBuilder.Entity("SolarSoft_1._0.Models.Panel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ancho")
                        .HasColumnType("int");

                    b.Property<int>("Largo")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreModelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Potencia")
                        .HasColumnType("int");

                    b.Property<double>("Voltaje")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Panel");
                });

            modelBuilder.Entity("SolarSoft_1._0.Models.Terreno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AnchoTerreno")
                        .HasColumnType("float");

                    b.Property<int>("AnguloEstructura")
                        .HasColumnType("int");

                    b.Property<int?>("Arboles")
                        .HasColumnType("int");

                    b.Property<int>("Azimuth")
                        .HasColumnType("int");

                    b.Property<double?>("Emisiones")
                        .HasColumnType("float");

                    b.Property<bool>("InstalacionEstructura")
                        .HasColumnType("bit");

                    b.Property<double>("LargoTerreno")
                        .HasColumnType("float");

                    b.Property<double>("Latitud")
                        .HasColumnType("float");

                    b.Property<double>("Longitud")
                        .HasColumnType("float");

                    b.Property<int>("ModeloPanel")
                        .HasColumnType("int");

                    b.Property<double?>("PotenciaTotal")
                        .HasColumnType("float");

                    b.Property<double?>("Separacion")
                        .HasColumnType("float");

                    b.Property<int?>("TotalPaneles")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Terrenos");
                });
#pragma warning restore 612, 618
        }
    }
}
