﻿// <auto-generated />
using System;
using Entrelinhas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entrelinhas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240906175443_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entrelinhas.Models.Autor", b =>
                {
                    b.Property<Guid>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Biografia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutorId");

                    b.ToTable("Autores", (string)null);
                });

            modelBuilder.Entity("Entrelinhas.Models.Avaliacao", b =>
                {
                    b.Property<Guid>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LivroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AvaliacaoId");

                    b.HasIndex("LivroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Avaliacoes", (string)null);
                });

            modelBuilder.Entity("Entrelinhas.Models.Doacao", b =>
                {
                    b.Property<Guid>("DoacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Data")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("LivroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DoacaoId");

                    b.HasIndex("LivroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Doacoes", (string)null);
                });

            modelBuilder.Entity("Entrelinhas.Models.Evento", b =>
                {
                    b.Property<Guid>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Data")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos", (string)null);
                });

            modelBuilder.Entity("Entrelinhas.Models.Livro", b =>
                {
                    b.Property<Guid>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Nacional")
                        .HasColumnType("bit");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LivroId");

                    b.HasIndex("AutorId");

                    b.ToTable("Livros", (string)null);
                });

            modelBuilder.Entity("Entrelinhas.Models.Participacao", b =>
                {
                    b.Property<Guid>("ParticipacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ParticipacaoId");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Participacao", (string)null);
                });

            modelBuilder.Entity("Entrelinhas.Models.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Entrelinhas.Models.Avaliacao", b =>
                {
                    b.HasOne("Entrelinhas.Models.Livro", "Livro")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entrelinhas.Models.Usuario", "Usuario")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entrelinhas.Models.Doacao", b =>
                {
                    b.HasOne("Entrelinhas.Models.Livro", "Livro")
                        .WithMany("Doacoes")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entrelinhas.Models.Usuario", "Usuario")
                        .WithMany("Doacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entrelinhas.Models.Livro", b =>
                {
                    b.HasOne("Entrelinhas.Models.Autor", "Autor")
                        .WithMany("Livros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("Entrelinhas.Models.Participacao", b =>
                {
                    b.HasOne("Entrelinhas.Models.Evento", "Evento")
                        .WithMany("Participacoes")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entrelinhas.Models.Usuario", "Usuario")
                        .WithMany("Participacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entrelinhas.Models.Autor", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("Entrelinhas.Models.Evento", b =>
                {
                    b.Navigation("Participacoes");
                });

            modelBuilder.Entity("Entrelinhas.Models.Livro", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Doacoes");
                });

            modelBuilder.Entity("Entrelinhas.Models.Usuario", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Doacoes");

                    b.Navigation("Participacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
