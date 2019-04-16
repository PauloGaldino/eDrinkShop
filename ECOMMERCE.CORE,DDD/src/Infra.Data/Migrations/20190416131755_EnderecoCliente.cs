using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class EnderecoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoPessoa_Endereco_EnderecoId",
                table: "EnderecoPessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoPessoa_Pessoa_PessoaId",
                table: "EnderecoPessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfissaoCliente_Pessoa_PessoaId",
                table: "ProfissaoCliente");

            migrationBuilder.DropIndex(
                name: "IX_ProfissaoCliente_PessoaId",
                table: "ProfissaoCliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoPessoa",
                table: "EnderecoPessoa");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "ProfissaoCliente");

            migrationBuilder.RenameTable(
                name: "EnderecoPessoa",
                newName: "EnderecoCliente");

            migrationBuilder.RenameIndex(
                name: "IX_EnderecoPessoa_PessoaId",
                table: "EnderecoCliente",
                newName: "IX_EnderecoCliente_PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_EnderecoPessoa_EnderecoId",
                table: "EnderecoCliente",
                newName: "IX_EnderecoCliente_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoCliente",
                table: "EnderecoCliente",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EnderecoClientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    EnderecoId = table.Column<int>(nullable: false),
                    PessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoClientes_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecoClientes_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecoClientes_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoClientes_ClienteId",
                table: "EnderecoClientes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoClientes_EnderecoId",
                table: "EnderecoClientes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoClientes_PessoaId",
                table: "EnderecoClientes",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoCliente_Endereco_EnderecoId",
                table: "EnderecoCliente",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoCliente_Pessoa_PessoaId",
                table: "EnderecoCliente",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoCliente_Endereco_EnderecoId",
                table: "EnderecoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoCliente_Pessoa_PessoaId",
                table: "EnderecoCliente");

            migrationBuilder.DropTable(
                name: "EnderecoClientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoCliente",
                table: "EnderecoCliente");

            migrationBuilder.RenameTable(
                name: "EnderecoCliente",
                newName: "EnderecoPessoa");

            migrationBuilder.RenameIndex(
                name: "IX_EnderecoCliente_PessoaId",
                table: "EnderecoPessoa",
                newName: "IX_EnderecoPessoa_PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_EnderecoCliente_EnderecoId",
                table: "EnderecoPessoa",
                newName: "IX_EnderecoPessoa_EnderecoId");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "ProfissaoCliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoPessoa",
                table: "EnderecoPessoa",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProfissaoCliente_PessoaId",
                table: "ProfissaoCliente",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoPessoa_Endereco_EnderecoId",
                table: "EnderecoPessoa",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoPessoa_Pessoa_PessoaId",
                table: "EnderecoPessoa",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfissaoCliente_Pessoa_PessoaId",
                table: "ProfissaoCliente",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
