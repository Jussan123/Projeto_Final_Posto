/* Módulo SGBD(Sitema de Gerenciamento de Banco de Dados) Conexão com o Banco
* Descrição : Classe responsável pela conexão com o banco de dados
* Autor : Jussan Igor da Silva
* Data : 23/05/2023
* Versão : 1.2
*/

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model;
using System.Data.SqlClient;
using System.Linq;

namespace Banco
{
    public class DataBase : DbContext
    {
        // criação das tabelas no banco de dados pelo Entity Framework
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<TipoCombustivel> TiposCombustivel { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Combustivel> Combustiveis { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Bomba> Bombas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // criação das chaves primárias e estrangeiras das tabelas no banco de dados pelo Entity Framework
            modelBuilder.Entity<Loja>(entity =>
            {
                entity.HasKey(e => e.lojaId);//chave primária
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.fornecedorId);//chave primária
            });

            modelBuilder.Entity<TipoCombustivel>(entity =>
            {
                entity.HasKey(e => e.tipoCombustivelId);//chave primária
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.funcionarioId);//chave primária
                // relacionar Funcionario com a loja
                entity.HasOne(e => e.loja)
                .WithMany()
                .HasForeignKey(e => e.lojaId);
            });

            modelBuilder.Entity<Combustivel>(entity =>
            {
                entity.HasKey(e => e.combustivelId);//chave primária
                // relacionar combustivel com o tipo de combustivel
                entity.HasOne(e => e.tipoCombustivel)
                .WithMany()
                .HasForeignKey(e => e.tipocombustivelId);
            });

            modelBuilder.Entity<Movimentacao>(entity =>
            {
                entity.HasKey(e => e.movimentacaoId);//chave primária
                // relacionar entrada/saida com o combustivel / Fornecedor / Loja
                entity.HasOne(e => e.Bomba)//relacionamento com a tabela combustivel
                .WithMany()//configurar um relacionamento de "muitos para um" ou "muitos para muitos" entre entidades.
                .HasForeignKey(e => e.bombaId);//chave estrangeira
                entity.HasOne(e => e.Fornecedor)
                .WithMany()
                .HasForeignKey(e => e.fornecedorId);
                entity.HasOne(e => e.Loja)
                .WithMany()
                .HasForeignKey(e => e.lojaId);
                entity.HasOne(e => e.Funcionario)
                .WithMany()
                .HasForeignKey(e => e.funcionarioId);
            });

            modelBuilder.Entity<Bomba>(entity =>
            {
                entity.HasKey(e => e.bombaId);//chave primária
                // relacionar bomba com tipo de combustivel / Movimentacao
                entity.HasOne(e => e.TipoCombustivel)
                .WithMany()
                .HasForeignKey(e => e.tipoCombustivelId);
                //entity.HasOne(e => e.Movimentacao)
                //.WithMany()
                //.HasForeignKey(e => e.movimentacaoId);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//configuração do banco de dados
        {
            if (!optionsBuilder.IsConfigured)//se não estiver configurado
            {
                try
                {
                    string connectionAWS = GetConnectionStringAWS();//conexão com o banco de dados na AWS
                    optionsBuilder.UseMySql(connectionAWS, ServerVersion.AutoDetect(connectionAWS));//configuração do banco de dados na AWS
                }
                catch
                {
                    Console.WriteLine("Não foi possível conectar a AWS");
                    try
                    {
                        string connectionLocal = GetConnectionStringLocal();//conexão com o banco de dados local
                        optionsBuilder.UseMySql(connectionLocal, ServerVersion.AutoDetect(connectionLocal));//configuração do banco de dados local
                    }
                    catch
                    {
                        Console.WriteLine("Não foi possível conectar ao banco de dados local");
                    }
                }
            }
        }

        public static string GetConnectionStringAWS()//conexão com o banco de dados na AWS
        {
            string serverName = "awsjussan.cbrcalzcoxol.us-east-1.rds.amazonaws.com";//nome do servidor
            //string serverName = "RDS MySQL";
            string databaseName = "PostosDeCombustivel"; //nome do banco de dados
            string username = "admin"; //nome do usuário
            string password = "jussan123"; //senha do usuário

            string connectionString = $"Server={serverName};Database={databaseName};User ID={username};Password={password};";//string de conexão com o banco de dados

            return connectionString;//retorna a string de conexão com o banco de dados
        }


        private static string GetConnectionStringLocal() //conexão com o banco de dados local
        {
            return "Server=localhost;User ID=root;Database=PostosDeCombustivel;";//string de conexão com o banco de dados
        }
    }
}