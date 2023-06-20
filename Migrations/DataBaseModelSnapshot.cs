﻿// <auto-generated />
using System;
using Banco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PostoCombustivel.Migrations
{
    [DbContext(typeof(DataBase))]
    partial class DataBaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Bomba", b =>
                {
                    b.Property<int>("bombaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("combustivelId")
                        .HasColumnType("int");

                    b.Property<decimal>("limiteMaximo")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("limiteMinimo")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("lojaId")
                        .HasColumnType("int");

                    b.Property<decimal>("volume")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("bombaId");

                    b.HasIndex("combustivelId");

                    b.HasIndex("lojaId");

                    b.ToTable("Bombas");
                });

            modelBuilder.Entity("Model.Combustivel", b =>
                {
                    b.Property<int>("combustivelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("precoCompra")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("precoVenda")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("sigla")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("combustivelId");

                    b.ToTable("Combustiveis");
                });

            modelBuilder.Entity("Model.Fornecedor", b =>
                {
                    b.Property<int>("fornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("contato")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("movimentacaoId")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("fornecedorId");

                    b.HasIndex("movimentacaoId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Model.Funcionario", b =>
                {
                    b.Property<int>("funcionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("funcao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("lojaId")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("funcionarioId");

                    b.HasIndex("lojaId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Model.Loja", b =>
                {
                    b.Property<int>("lojaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("lojaId");

                    b.ToTable("Lojas");
                });

            modelBuilder.Entity("Model.Movimentacao", b =>
                {
                    b.Property<int>("movimentacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("bombaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("funcionarioId")
                        .HasColumnType("int");

                    b.Property<int>("lojaId")
                        .HasColumnType("int");

                    b.Property<decimal>("quantidade")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("tipoOperacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("movimentacaoId");

                    b.HasIndex("bombaId");

                    b.HasIndex("funcionarioId");

                    b.HasIndex("lojaId");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("Model.Bomba", b =>
                {
                    b.HasOne("Model.Combustivel", "combustivel")
                        .WithMany()
                        .HasForeignKey("combustivelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Loja", "loja")
                        .WithMany()
                        .HasForeignKey("lojaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("combustivel");

                    b.Navigation("loja");
                });

            modelBuilder.Entity("Model.Fornecedor", b =>
                {
                    b.HasOne("Model.Movimentacao", "movimentacao")
                        .WithMany()
                        .HasForeignKey("movimentacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movimentacao");
                });

            modelBuilder.Entity("Model.Funcionario", b =>
                {
                    b.HasOne("Model.Loja", "loja")
                        .WithMany()
                        .HasForeignKey("lojaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("loja");
                });

            modelBuilder.Entity("Model.Movimentacao", b =>
                {
                    b.HasOne("Model.Bomba", "bomba")
                        .WithMany()
                        .HasForeignKey("bombaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Funcionario", "funcionario")
                        .WithMany()
                        .HasForeignKey("funcionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Loja", "loja")
                        .WithMany()
                        .HasForeignKey("lojaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bomba");

                    b.Navigation("funcionario");

                    b.Navigation("loja");
                });
#pragma warning restore 612, 618
        }
    }
}
