using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Departamentos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Departamento_DepartamentoId",
                table: "Endereco");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Endereco",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Departamento_DepartamentoId",
                table: "Endereco",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Departamento_DepartamentoId",
                table: "Endereco");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Endereco",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Departamento_DepartamentoId",
                table: "Endereco",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
