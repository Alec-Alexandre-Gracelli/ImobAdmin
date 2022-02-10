using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImobAdmin.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(NomeCategoria)" +
                "VALUES('Casas')");

            migrationBuilder.Sql("INSERT INTO Categorias(NomeCategoria) " +
                "VALUES('Apartamentos')");

            migrationBuilder.Sql("INSERT INTO Categorias(NomeCategoria) " +
                "VALUES('Terrenos')");

            migrationBuilder.Sql("INSERT INTO Categorias(NomeCategoria) " +
                "VALUES('Chácaras')");

            migrationBuilder.Sql("INSERT INTO Categorias(NomeCategoria) " +
                "VALUES('Galpões')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
