using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class COntato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Contato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contato_EnderecoId",
                table: "Contato",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Endereco_EnderecoId",
                table: "Contato",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Endereco_EnderecoId",
                table: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Contato_EnderecoId",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Contato");
        }
    }
}
