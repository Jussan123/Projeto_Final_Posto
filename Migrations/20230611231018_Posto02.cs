using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostoCombustivel.Migrations
{
    /// <inheritdoc />
    public partial class Posto02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bombas_TiposCombustivel_tipoCombustivelId",
                table: "Bombas");

            migrationBuilder.DropForeignKey(
                name: "FK_Combustiveis_TiposCombustivel_tipocombustivelId",
                table: "Combustiveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Combustiveis_combustivelId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Fornecedores_fornecedorId",
                table: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "TiposCombustivel");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacoes_combustivelId",
                table: "Movimentacoes");

            migrationBuilder.DropIndex(
                name: "IX_Combustiveis_tipocombustivelId",
                table: "Combustiveis");

            migrationBuilder.DropColumn(
                name: "combustivelId",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "tipocombustivelId",
                table: "Combustiveis");

            migrationBuilder.RenameColumn(
                name: "fornecedorId",
                table: "Movimentacoes",
                newName: "funcionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Movimentacoes_fornecedorId",
                table: "Movimentacoes",
                newName: "IX_Movimentacoes_funcionarioId");

            migrationBuilder.RenameColumn(
                name: "quantidadeEstoque",
                table: "Combustiveis",
                newName: "precoVenda");

            migrationBuilder.RenameColumn(
                name: "preco",
                table: "Combustiveis",
                newName: "precoCompra");

            migrationBuilder.RenameColumn(
                name: "tipoCombustivelId",
                table: "Bombas",
                newName: "lojaId");

            migrationBuilder.RenameIndex(
                name: "IX_Bombas_tipoCombustivelId",
                table: "Bombas",
                newName: "IX_Bombas_lojaId");

            migrationBuilder.AddColumn<decimal>(
                name: "valor",
                table: "Movimentacoes",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "movimentacaoId",
                table: "Fornecedores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "Combustiveis",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Combustiveis",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "sigla",
                table: "Combustiveis",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "combustivelId",
                table: "Bombas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Bombas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_movimentacaoId",
                table: "Fornecedores",
                column: "movimentacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bombas_combustivelId",
                table: "Bombas",
                column: "combustivelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bombas_Combustiveis_combustivelId",
                table: "Bombas",
                column: "combustivelId",
                principalTable: "Combustiveis",
                principalColumn: "combustivelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bombas_Lojas_lojaId",
                table: "Bombas",
                column: "lojaId",
                principalTable: "Lojas",
                principalColumn: "lojaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Movimentacoes_movimentacaoId",
                table: "Fornecedores",
                column: "movimentacaoId",
                principalTable: "Movimentacoes",
                principalColumn: "movimentacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Funcionarios_funcionarioId",
                table: "Movimentacoes",
                column: "funcionarioId",
                principalTable: "Funcionarios",
                principalColumn: "funcionarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bombas_Combustiveis_combustivelId",
                table: "Bombas");

            migrationBuilder.DropForeignKey(
                name: "FK_Bombas_Lojas_lojaId",
                table: "Bombas");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Movimentacoes_movimentacaoId",
                table: "Fornecedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Funcionarios_funcionarioId",
                table: "Movimentacoes");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_movimentacaoId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Bombas_combustivelId",
                table: "Bombas");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "movimentacaoId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "descricao",
                table: "Combustiveis");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "Combustiveis");

            migrationBuilder.DropColumn(
                name: "sigla",
                table: "Combustiveis");

            migrationBuilder.DropColumn(
                name: "combustivelId",
                table: "Bombas");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "Bombas");

            migrationBuilder.RenameColumn(
                name: "funcionarioId",
                table: "Movimentacoes",
                newName: "fornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Movimentacoes_funcionarioId",
                table: "Movimentacoes",
                newName: "IX_Movimentacoes_fornecedorId");

            migrationBuilder.RenameColumn(
                name: "precoVenda",
                table: "Combustiveis",
                newName: "quantidadeEstoque");

            migrationBuilder.RenameColumn(
                name: "precoCompra",
                table: "Combustiveis",
                newName: "preco");

            migrationBuilder.RenameColumn(
                name: "lojaId",
                table: "Bombas",
                newName: "tipoCombustivelId");

            migrationBuilder.RenameIndex(
                name: "IX_Bombas_lojaId",
                table: "Bombas",
                newName: "IX_Bombas_tipoCombustivelId");

            migrationBuilder.AddColumn<int>(
                name: "combustivelId",
                table: "Movimentacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipocombustivelId",
                table: "Combustiveis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TiposCombustivel",
                columns: table => new
                {
                    tipoCombustivelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nomeCombustivel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCombustivel", x => x.tipoCombustivelId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_combustivelId",
                table: "Movimentacoes",
                column: "combustivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Combustiveis_tipocombustivelId",
                table: "Combustiveis",
                column: "tipocombustivelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bombas_TiposCombustivel_tipoCombustivelId",
                table: "Bombas",
                column: "tipoCombustivelId",
                principalTable: "TiposCombustivel",
                principalColumn: "tipoCombustivelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Combustiveis_TiposCombustivel_tipocombustivelId",
                table: "Combustiveis",
                column: "tipocombustivelId",
                principalTable: "TiposCombustivel",
                principalColumn: "tipoCombustivelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Combustiveis_combustivelId",
                table: "Movimentacoes",
                column: "combustivelId",
                principalTable: "Combustiveis",
                principalColumn: "combustivelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Fornecedores_fornecedorId",
                table: "Movimentacoes",
                column: "fornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "fornecedorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
