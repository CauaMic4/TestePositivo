using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestePositivo.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlunoModelId",
                table: "Endereco",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_AlunoModelId",
                table: "Endereco",
                column: "AlunoModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Aluno_AlunoModelId",
                table: "Endereco",
                column: "AlunoModelId",
                principalTable: "Aluno",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Aluno_AlunoModelId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_AlunoModelId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "AlunoModelId",
                table: "Endereco");
        }
    }
}
