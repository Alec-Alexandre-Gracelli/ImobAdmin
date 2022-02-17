using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImobAdmin.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(NomeCategoria) " +
                "VALUES('Apartamento')");

            migrationBuilder.Sql("INSERT INTO Categorias(NomeCategoria) " +
               "VALUES('Casas')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
