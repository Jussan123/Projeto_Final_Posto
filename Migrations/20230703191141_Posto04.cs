using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostoCombustivel.Migrations
{
    /// <inheritdoc />
    public partial class Posto04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "combustivelId",
                table: "Movimentacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fornecedorId",
                table: "Movimentacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fornecedorId1",
                table: "Movimentacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_combustivelId",
                table: "Movimentacoes",
                column: "combustivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_fornecedorId1",
                table: "Movimentacoes",
                column: "fornecedorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Combustiveis_combustivelId",
                table: "Movimentacoes",
                column: "combustivelId",
                principalTable: "Combustiveis",
                principalColumn: "combustivelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Fornecedores_fornecedorId1",
                table: "Movimentacoes",
                column: "fornecedorId1",
                principalTable: "Fornecedores",
                principalColumn: "fornecedorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Combustiveis_combustivelId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Fornecedores_fornecedorId1",
                table: "Movimentacoes");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacoes_combustivelId",
                table: "Movimentacoes");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacoes_fornecedorId1",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "combustivelId",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "fornecedorId",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "fornecedorId1",
                table: "Movimentacoes");
        }
    }
}
