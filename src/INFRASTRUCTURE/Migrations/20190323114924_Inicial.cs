using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFRASTRUCTURE.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalogo_brando_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalogo_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalogo_tipo_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompraId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogoMarca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Marca = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoMarca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogTipo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentityGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompraId = table.Column<string>(nullable: true),
                    PedidoData = table.Column<DateTimeOffset>(nullable: false),
                    ShipToEndereco_Logradouro = table.Column<string>(nullable: true),
                    ShipToEndereco_Cidade = table.Column<string>(nullable: true),
                    ShipToEndereco_Estado = table.Column<string>(nullable: true),
                    ShipToEndereco_Pais = table.Column<string>(nullable: true),
                    ShipToEndereco_CEP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    CatalogoItemId = table.Column<int>(nullable: false),
                    CarrinhoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoItems_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalogo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    DescricaoCurta = table.Column<string>(nullable: true),
                    DescricaoLonga = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    FotoUri = table.Column<string>(nullable: true),
                    CatalogoTipoId = table.Column<int>(nullable: false),
                    CatalogoMarcaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogo_CatalogoMarca_CatalogoMarcaId",
                        column: x => x.CatalogoMarcaId,
                        principalTable: "CatalogoMarca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalogo_CatalogTipo_CatalogoTipoId",
                        column: x => x.CatalogoTipoId,
                        principalTable: "CatalogTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alias = table.Column<string>(nullable: true),
                    CartaoId = table.Column<string>(nullable: true),
                    Ultimo4 = table.Column<string>(nullable: true),
                    CompraId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetodoPagamento_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemPedido_CatalogoItemId = table.Column<int>(nullable: false),
                    ItemPedido_ProdutoNome = table.Column<string>(nullable: true),
                    ItemPedido_FotoUri = table.Column<string>(nullable: true),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    Unidades = table.Column<int>(nullable: false),
                    PedidoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItems_CarrinhoId",
                table: "CarrinhoItems",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogo_CatalogoMarcaId",
                table: "Catalogo",
                column: "CatalogoMarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogo_CatalogoTipoId",
                table: "Catalogo",
                column: "CatalogoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_MetodoPagamento_CompraId",
                table: "MetodoPagamento",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoItems");

            migrationBuilder.DropTable(
                name: "Catalogo");

            migrationBuilder.DropTable(
                name: "MetodoPagamento");

            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "CatalogoMarca");

            migrationBuilder.DropTable(
                name: "CatalogTipo");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropSequence(
                name: "catalogo_brando_hilo");

            migrationBuilder.DropSequence(
                name: "catalogo_hilo");

            migrationBuilder.DropSequence(
                name: "catalogo_tipo_hilo");
        }
    }
}
