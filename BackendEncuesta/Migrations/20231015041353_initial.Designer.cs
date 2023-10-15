﻿// <auto-generated />
using System;
using BackendEncuesta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendEncuesta.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231015041353_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendEncuesta.Entities.ComunaResidencia", b =>
                {
                    b.Property<int>("ComunaResidenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComunaResidenciaId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComunaResidenciaId");

                    b.ToTable("ComunasResidencia");
                });

            modelBuilder.Entity("BackendEncuesta.Entities.ComunaTrabajo", b =>
                {
                    b.Property<int>("ComunaTrabajoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComunaTrabajoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComunaTrabajoId");

                    b.ToTable("ComunasTrabajo");
                });

            modelBuilder.Entity("BackendEncuesta.Entities.Encuesta", b =>
                {
                    b.Property<int>("EncuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EncuestaId"));

                    b.Property<string>("Pregunta1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pregunta2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pregunta3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pregunta4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pregunta5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pregunta6")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoTransporteId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecharealizacion")
                        .HasColumnType("datetime2");

                    b.HasKey("EncuestaId");

                    b.HasIndex("TipoTransporteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Encuestas");
                });

            modelBuilder.Entity("BackendEncuesta.Entities.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("BackendEncuesta.Entities.ModalidadTrabajo", b =>
                {
                    b.Property<int>("ModalidadTrabajoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModalidadTrabajoId"));

                    b.Property<string>("Mombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModalidadTrabajoId");

                    b.ToTable("ModalidadTrabajos");
                });

            modelBuilder.Entity("BackendEncuesta.Entities.TipoTransporte", b =>
                {
                    b.Property<int>("TipoTransporteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoTransporteId"));

                    b.Property<string>("Comparte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoTransporteId");

                    b.ToTable("TipoTransportes");
                });

            modelBuilder.Entity("BackendEncuesta.Entities.Usuario", b =>
                {
                    b.Property<int>("usuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("usuarioId"));

                    b.Property<int>("ComunaResidenciaId")
                        .HasColumnType("int");

                    b.Property<int>("ComunaTrabajoId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<int>("ModalidadTrabajoId")
                        .HasColumnType("int");

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("recuperar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trabaja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("usuarioId");

                    b.HasIndex("ComunaResidenciaId");

                    b.HasIndex("ComunaTrabajoId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("ModalidadTrabajoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BackendEncuesta.Entities.Encuesta", b =>
                {
                    b.HasOne("BackendEncuesta.Entities.TipoTransporte", "TipoTransporte")
                        .WithMany()
                        .HasForeignKey("TipoTransporteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendEncuesta.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoTransporte");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("BackendEncuesta.Entities.Usuario", b =>
                {
                    b.HasOne("BackendEncuesta.Entities.ComunaResidencia", "ComunaResidencia")
                        .WithMany()
                        .HasForeignKey("ComunaResidenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendEncuesta.Entities.ComunaTrabajo", "ComunaTrabajo")
                        .WithMany()
                        .HasForeignKey("ComunaTrabajoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendEncuesta.Entities.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendEncuesta.Entities.ModalidadTrabajo", "ModalidadTrabajo")
                        .WithMany()
                        .HasForeignKey("ModalidadTrabajoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComunaResidencia");

                    b.Navigation("ComunaTrabajo");

                    b.Navigation("Estado");

                    b.Navigation("ModalidadTrabajo");
                });
#pragma warning restore 612, 618
        }
    }
}
