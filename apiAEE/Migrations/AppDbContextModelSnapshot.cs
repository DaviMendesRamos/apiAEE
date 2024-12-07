﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiAEE.Context;

#nullable disable

namespace apiAEE.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UrlImagem")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("apiAEE.Entities.Equipe", b =>
                {
                    b.Property<int>("CodEquipe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodEquipe"));

                    b.Property<string>("Modalidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEquipe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodEquipe");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("apiAEE.Entities.Evento", b =>
                {
                    b.Property<int>("CodEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodEvento"));

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocalEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodEvento");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("apiAEE.Entities.Pertence", b =>
                {
                    b.Property<int>("CodEquipe")
                        .HasColumnType("int");

                    b.Property<int>("CodUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("Aceito")
                        .HasColumnType("bit");

                    b.HasKey("CodEquipe", "CodUsuario");

                    b.HasIndex("CodUsuario");

                    b.ToTable("Pertences");
                });

            modelBuilder.Entity("apiAEE.Entities.Pertence", b =>
                {
                    b.HasOne("apiAEE.Entities.Equipe", "Equipe")
                        .WithMany("Pertences")
                        .HasForeignKey("CodEquipe")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Usuario", "Usuario")
                        .WithMany("Pertences")
                        .HasForeignKey("CodUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Equipe");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Usuario", b =>
                {
                    b.Navigation("Pertences");
                });

            modelBuilder.Entity("apiAEE.Entities.Equipe", b =>
                {
                    b.Navigation("Pertences");
                });
#pragma warning restore 612, 618
        }
    }
}
