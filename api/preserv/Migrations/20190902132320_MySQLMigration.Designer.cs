﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PreservWebApi.Models;

namespace preserv.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190902132320_MySQLMigration")]
    partial class MySQLMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PreservWebApi.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("PreservWebApi.Models.Contrato", b =>
                {
                    b.Property<int>("IdContrato")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataEncerramento");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("IdContratado");

                    b.Property<int>("IdContratante");

                    b.Property<int>("IdProjeto");

                    b.Property<decimal>("ValorContratado")
                        .HasMaxLength(16);

                    b.HasKey("IdContrato");

                    b.HasIndex("IdContratado");

                    b.HasIndex("IdContratante");

                    b.HasIndex("IdProjeto");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("PreservWebApi.Models.Log", b =>
                {
                    b.Property<int>("IdLog")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Acao")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<int>("IdUsuario");

                    b.Property<string>("NomeUsuario");

                    b.Property<string>("Pagina")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("IdLog");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("PreservWebApi.Models.Perfil", b =>
                {
                    b.Property<int>("IdPerfil")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("IdPerfil");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("PreservWebApi.Models.Projeto", b =>
                {
                    b.Property<int>("IdProjeto")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("IdCategoria");

                    b.Property<int>("IdUnidadeTempo");

                    b.Property<int>("PrazoPrevistoMaximo");

                    b.Property<int>("PrazoPrevistoMinimo");

                    b.Property<decimal>("ValorPrevisto");

                    b.HasKey("IdProjeto");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdUnidadeTempo");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("PreservWebApi.Models.Tarefa", b =>
                {
                    b.Property<int>("IdTarefa")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataEncerramento");

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("IdProjeto");

                    b.Property<int>("IdUnidadeTempo");

                    b.Property<int>("PrazoPrevisto");

                    b.HasKey("IdTarefa");

                    b.HasIndex("IdProjeto");

                    b.HasIndex("IdUnidadeTempo");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("PreservWebApi.Models.UnidadeTempo", b =>
                {
                    b.Property<int>("IdUnidadeTempo")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("IdUnidadeTempo");

                    b.ToTable("UnidadeTempo");
                });

            modelBuilder.Entity("PreservWebApi.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("IdPerfil");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("PreservWebApi.Models.Contratado", b =>
                {
                    b.HasBaseType("PreservWebApi.Models.Usuario");

                    b.Property<int>("IdContratado");

                    b.HasDiscriminator().HasValue("Contratado");
                });

            modelBuilder.Entity("PreservWebApi.Models.Contratante", b =>
                {
                    b.HasBaseType("PreservWebApi.Models.Usuario");

                    b.Property<DateTime>("DataVigencia");

                    b.Property<int>("IdContratante");

                    b.HasDiscriminator().HasValue("Contratante");
                });

            modelBuilder.Entity("PreservWebApi.Models.Contrato", b =>
                {
                    b.HasOne("PreservWebApi.Models.Contratado", "Contratado")
                        .WithMany("Contratos")
                        .HasForeignKey("IdContratado")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PreservWebApi.Models.Contratante", "Contratante")
                        .WithMany("Contratos")
                        .HasForeignKey("IdContratante")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PreservWebApi.Models.Projeto", "Projeto")
                        .WithMany("Contratos")
                        .HasForeignKey("IdProjeto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PreservWebApi.Models.Log", b =>
                {
                    b.HasOne("PreservWebApi.Models.Usuario", "Usuario")
                        .WithMany("Logs")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PreservWebApi.Models.Projeto", b =>
                {
                    b.HasOne("PreservWebApi.Models.Categoria", "Categoria")
                        .WithMany("Projetos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PreservWebApi.Models.UnidadeTempo", "UnidadeTempo")
                        .WithMany("Projetos")
                        .HasForeignKey("IdUnidadeTempo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PreservWebApi.Models.Tarefa", b =>
                {
                    b.HasOne("PreservWebApi.Models.Projeto", "Projeto")
                        .WithMany("Tarefas")
                        .HasForeignKey("IdProjeto")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PreservWebApi.Models.UnidadeTempo", "UnidadeTempo")
                        .WithMany("Tarefas")
                        .HasForeignKey("IdUnidadeTempo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PreservWebApi.Models.Usuario", b =>
                {
                    b.HasOne("PreservWebApi.Models.Perfil", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
