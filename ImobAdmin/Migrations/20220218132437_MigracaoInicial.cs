using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImobAdmin.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.CidadeId);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    ImagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagemNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EhDestaque = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.ImagemId);
                });

            migrationBuilder.CreateTable(
                name: "Bairros",
                columns: table => new
                {
                    BairroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeId = table.Column<int>(type: "int", nullable: false),
                    BairroNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairros", x => x.BairroId);
                    table.ForeignKey(
                        name: "FK_Bairros_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "CidadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    BairroId = table.Column<int>(type: "int", nullable: false),
                    ImagemId = table.Column<int>(type: "int", nullable: false),
                    NomeImovel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NomeContato = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TelContato = table.Column<int>(type: "int", nullable: false),
                    EhVenda = table.Column<bool>(type: "bit", nullable: false),
                    TipoAcao = table.Column<int>(type: "int", nullable: false),
                    EstaEmDestaque = table.Column<bool>(type: "bit", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Dormitorios = table.Column<int>(type: "int", nullable: false),
                    Banheiros = table.Column<int>(type: "int", nullable: false),
                    Sala = table.Column<int>(type: "int", nullable: false),
                    Cozinha = table.Column<int>(type: "int", nullable: false),
                    Vagas = table.Column<int>(type: "int", nullable: false),
                    Churrasqueira = table.Column<bool>(type: "bit", nullable: false),
                    Piscina = table.Column<bool>(type: "bit", nullable: false),
                    Edicula = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.ImovelId);
                    table.ForeignKey(
                        name: "FK_Imoveis_Bairros_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairros",
                        principalColumn: "BairroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Imoveis_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Imoveis_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "ImagemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bairros_CidadeId",
                table: "Bairros",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_BairroId",
                table: "Imoveis",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_CategoriaId",
                table: "Imoveis",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_ImagemId",
                table: "Imoveis",
                column: "ImagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imoveis");

            migrationBuilder.DropTable(
                name: "Bairros");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "Cidades");
        }
    }
}
