using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostoCombustivel.Migrations
{
    /// <inheritdoc />
    public partial class PostoCombustivel05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Movimentacoes_movimentacaoId",
                table: "Fornecedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Fornecedores_fornecedorId1",
                table: "Movimentacoes");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacoes_fornecedorId1",
                table: "Movimentacoes");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_movimentacaoId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "fornecedorId1",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "movimentacaoId",
                table: "Fornecedores");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_fornecedorId",
                table: "Movimentacoes",
                column: "fornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Fornecedores_fornecedorId",
                table: "Movimentacoes",
                column: "fornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "fornecedorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Fornecedores_fornecedorId",
                table: "Movimentacoes");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacoes_fornecedorId",
                table: "Movimentacoes");

            migrationBuilder.AddColumn<int>(
                name: "fornecedorId1",
                table: "Movimentacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "movimentacaoId",
                table: "Fornecedores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_fornecedorId1",
                table: "Movimentacoes",
                column: "fornecedorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_movimentacaoId",
                table: "Fornecedores",
                column: "movimentacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Movimentacoes_movimentacaoId",
                table: "Fornecedores",
                column: "movimentacaoId",
                principalTable: "Movimentacoes",
                principalColumn: "movimentacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Fornecedores_fornecedorId1",
                table: "Movimentacoes",
                column: "fornecedorId1",
                principalTable: "Fornecedores",
                principalColumn: "fornecedorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
