﻿// <auto-generated />
using System;
using Infraestructura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240204035818_InicializaiconDeBaseDeDatos")]
    partial class InicializaiconDeBaseDeDatos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Aerolineas.Aerolinea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Key")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Aereolinias", (string)null);
                });

            modelBuilder.Entity("Dominio.Ciudades.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Key")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Ciudades", (string)null);
                });

            modelBuilder.Entity("Dominio.Usuario.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Key")
                        .HasColumnType("int");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Dominio.Vuelos.Vuelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AerolineaId")
                        .HasColumnType("int");

                    b.Property<int>("CiudadDestinoId")
                        .HasColumnType("int");

                    b.Property<int>("CiudadOrigenId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HoraLlegada")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraSalida")
                        .HasColumnType("time");

                    b.Property<int>("Key")
                        .HasColumnType("int");

                    b.Property<int>("NumeroVuelo")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioActualizacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioCreacioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioCreacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AerolineaId");

                    b.HasIndex("CiudadDestinoId");

                    b.HasIndex("CiudadOrigenId");

                    b.HasIndex("UsuarioActualizacionId");

                    b.HasIndex("UsuarioCreacioId");

                    b.ToTable("Vuelos", (string)null);
                });

            modelBuilder.Entity("Dominio.Vuelos.Vuelo", b =>
                {
                    b.HasOne("Dominio.Aerolineas.Aerolinea", "Aerolinea")
                        .WithMany("Vuelos")
                        .HasForeignKey("AerolineaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Dominio.Ciudades.Ciudad", "CiudadDestino")
                        .WithMany("VuelosDestino")
                        .HasForeignKey("CiudadDestinoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Dominio.Ciudades.Ciudad", "CiudadOrigen")
                        .WithMany("VuelosOrigen")
                        .HasForeignKey("CiudadOrigenId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Dominio.Usuario.Usuario", "UsuarioActualizacion")
                        .WithMany()
                        .HasForeignKey("UsuarioActualizacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Usuario.Usuario", "UsuarioCreacio")
                        .WithMany()
                        .HasForeignKey("UsuarioCreacioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aerolinea");

                    b.Navigation("CiudadDestino");

                    b.Navigation("CiudadOrigen");

                    b.Navigation("UsuarioActualizacion");

                    b.Navigation("UsuarioCreacio");
                });

            modelBuilder.Entity("Dominio.Aerolineas.Aerolinea", b =>
                {
                    b.Navigation("Vuelos");
                });

            modelBuilder.Entity("Dominio.Ciudades.Ciudad", b =>
                {
                    b.Navigation("VuelosDestino");

                    b.Navigation("VuelosOrigen");
                });
#pragma warning restore 612, 618
        }
    }
}
