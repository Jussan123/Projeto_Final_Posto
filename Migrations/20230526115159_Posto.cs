using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostoCombustivel.Migrations
{
    /// <inheritdoc />
    public partial class Posto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    fornecedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contato = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    endereco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.fornecedorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lojas",
                columns: table => new
                {
                    lojaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    endereco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lojas", x => x.lojaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposCombustivel",
                columns: table => new
                {
                    tipoCombustivelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeCombustivel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCombustivel", x => x.tipoCombustivelId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    funcionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    funcao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lojaId = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.funcionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Lojas_lojaId",
                        column: x => x.lojaId,
                        principalTable: "Lojas",
                        principalColumn: "lojaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Combustiveis",
                columns: table => new
                {
                    combustivelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipocombustivelId = table.Column<int>(type: "int", nullable: false),
                    quantidadeEstoque = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustiveis", x => x.combustivelId);
                    table.ForeignKey(
                        name: "FK_Combustiveis_TiposCombustivel_tipocombustivelId",
                        column: x => x.tipocombustivelId,
                        principalTable: "TiposCombustivel",
                        principalColumn: "tipoCombustivelId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    movimentacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    combustivelId = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    tipoOperacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataHora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    lojaId = table.Column<int>(type: "int", nullable: false),
                    fornecedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.movimentacaoId);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Combustiveis_combustivelId",
                        column: x => x.combustivelId,
                        principalTable: "Combustiveis",
                        principalColumn: "combustivelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Fornecedores_fornecedorId",
                        column: x => x.fornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "fornecedorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Lojas_lojaId",
                        column: x => x.lojaId,
                        principalTable: "Lojas",
                        principalColumn: "lojaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bombas",
                columns: table => new
                {
                    bombaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipoCombustivelId = table.Column<int>(type: "int", nullable: false),
                    limiteMaximo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    limiteMinimo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    movimentacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bombas", x => x.bombaId);
                    table.ForeignKey(
                        name: "FK_Bombas_Movimentacoes_movimentacaoId",
                        column: x => x.movimentacaoId,
                        principalTable: "Movimentacoes",
                        principalColumn: "movimentacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bombas_TiposCombustivel_tipoCombustivelId",
                        column: x => x.tipoCombustivelId,
                        principalTable: "TiposCombustivel",
                        principalColumn: "tipoCombustivelId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Bombas_movimentacaoId",
                table: "Bombas",
                column: "movimentacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bombas_tipoCombustivelId",
                table: "Bombas",
                column: "tipoCombustivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Combustiveis_tipocombustivelId",
                table: "Combustiveis",
                column: "tipocombustivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_lojaId",
                table: "Funcionarios",
                column: "lojaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_combustivelId",
                table: "Movimentacoes",
                column: "combustivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_fornecedorId",
                table: "Movimentacoes",
                column: "fornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_lojaId",
                table: "Movimentacoes",
                column: "lojaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bombas");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Combustiveis");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Lojas");

            migrationBuilder.DropTable(
                name: "TiposCombustivel");
        }
    }
}
