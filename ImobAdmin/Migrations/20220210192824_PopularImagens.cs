using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImobAdmin.Migrations
{
    public partial class PopularImagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(ImagemNome, EhDestaque)" +
                "VALUES('', 1)");

            migrationBuilder.Sql("INSERT INTO Categorias((ImagemNome, EhDestaque))" +
                "VALUES('', 0)");

            migrationBuilder.Sql("INSERT INTO Categorias((ImagemNome, EhDestaque))" +
                "VALUES('', 0)");

            migrationBuilder.Sql("INSERT INTO Categorias((ImagemNome, EhDestaque))" +
                "VALUES('', 0)");

            migrationBuilder.Sql("INSERT INTO Categorias((ImagemNome, EhDestaque))" +
                "VALUES('', 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Imagens");
        }
    }
}
