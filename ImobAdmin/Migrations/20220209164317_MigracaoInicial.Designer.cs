﻿// <auto-generated />
using ImobAdmin.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImobAdmin.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220209164317_MigracaoInicial")]
    partial class MigracaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ImobAdmin.Models.Bairro", b =>
                {
                    b.Property<int>("BairroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BairroId"), 1L, 1);

                    b.Property<string>("BairroNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.HasKey("BairroId");

                    b.HasIndex("CidadeId");

                    b.ToTable("Bairros");
                });

            modelBuilder.Entity("ImobAdmin.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("NomeCategoria")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ImobAdmin.Models.Cidade", b =>
                {
                    b.Property<int>("CidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CidadeId"), 1L, 1);

                    b.Property<string>("CidadeNome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CidadeId");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("ImobAdmin.Models.Imagem", b =>
                {
                    b.Property<int>("ImagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImagemId"), 1L, 1);

                    b.Property<bool>("EhDestaque")
                        .HasColumnType("bit");

                    b.Property<string>("ImagemNome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImagemId");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("ImobAdmin.Models.Imovel", b =>
                {
                    b.Property<int>("ImovelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImovelId"), 1L, 1);

                    b.Property<int>("BairroId")
                        .HasColumnType("int");

                    b.Property<int>("Banheiros")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<bool>("Churrasqueira")
                        .HasColumnType("bit");

                    b.Property<int>("Cozinha")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dormitorios")
                        .HasColumnType("int");

                    b.Property<bool>("Edicula")
                        .HasColumnType("bit");

                    b.Property<bool>("EhVenda")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaEmDestaque")
                        .HasColumnType("bit");

                    b.Property<int>("ImagemId")
                        .HasColumnType("int");

                    b.Property<string>("NomeContato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Piscina")
                        .HasColumnType("bit");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Sala")
                        .HasColumnType("int");

                    b.Property<int>("TelContato")
                        .HasColumnType("int");

                    b.Property<int>("TipoAcao")
                        .HasColumnType("int");

                    b.Property<int>("Vagas")
                        .HasColumnType("int");

                    b.HasKey("ImovelId");

                    b.HasIndex("BairroId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ImagemId");

                    b.ToTable("Imoveis");
                });

            modelBuilder.Entity("ImobAdmin.Models.Bairro", b =>
                {
                    b.HasOne("ImobAdmin.Models.Cidade", "Cidade")
                        .WithMany("Bairros")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("ImobAdmin.Models.Imovel", b =>
                {
                    b.HasOne("ImobAdmin.Models.Bairro", "Bairro")
                        .WithMany()
                        .HasForeignKey("BairroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImobAdmin.Models.Categoria", "Categoria")
                        .WithMany("Imoveis")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImobAdmin.Models.Imagem", "Imagem")
                        .WithMany("Imoveis")
                        .HasForeignKey("ImagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bairro");

                    b.Navigation("Categoria");

                    b.Navigation("Imagem");
                });

            modelBuilder.Entity("ImobAdmin.Models.Categoria", b =>
                {
                    b.Navigation("Imoveis");
                });

            modelBuilder.Entity("ImobAdmin.Models.Cidade", b =>
                {
                    b.Navigation("Bairros");
                });

            modelBuilder.Entity("ImobAdmin.Models.Imagem", b =>
                {
                    b.Navigation("Imoveis");
                });
#pragma warning restore 612, 618
        }
    }
}
