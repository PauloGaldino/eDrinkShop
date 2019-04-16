using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class ProfissaoCliente1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "ProfissaoCliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProfissaoCliente_PessoaId",
                table: "ProfissaoCliente",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfissaoCliente_Pessoa_PessoaId",
                table: "ProfissaoCliente",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfissaoCliente_Pessoa_PessoaId",
                table: "ProfissaoCliente");

            migrationBuilder.DropIndex(
                name: "IX_ProfissaoCliente_PessoaId",
                table: "ProfissaoCliente");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "ProfissaoCliente");
        }
    }
}
