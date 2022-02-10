using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImobAdmin.Migrations
{
    public partial class PopularImoveis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Imoveis(CategoriaId, NomeImovel, ImagemId, Preco, NomeContato, TelContato, TipoAcao, EstaEmDestaque) " + 
                "Descricao,Dormitorios,Banheiros,Sala,Cozinha,Vagas,Churrasqueira,Piscina,Edicula) " +
                "VALUES(1)");

            migrationBuilder.Sql("INSERT INTO Imoveis(CategoriaId, NomeImovel, ImagemId, Preco, NomeContato, TelContato, TipoAcao, EstaEmDestaque) " +
                 "Descricao,Dormitorios,Banheiros,Sala,Cozinha,Vagas,Churrasqueira,Piscina,Edicula) " +
                 "VALUES(1)");

            migrationBuilder.Sql("INSERT INTO Imoveis(CategoriaId, NomeImovel, ImagemId, Preco, NomeContato, TelContato, TipoAcao, EstaEmDestaque) " +
                "Descricao,Dormitorios,Banheiros,Sala,Cozinha,Vagas,Churrasqueira,Piscina,Edicula) " +
                "VALUES(1)");

            migrationBuilder.Sql("INSERT INTO Imoveis(CategoriaId, NomeImovel, ImagemId, Preco, NomeContato, TelContato, TipoAcao, EstaEmDestaque) " +
                 "Descricao,Dormitorios,Banheiros,Sala,Cozinha,Vagas,Churrasqueira,Piscina,Edicula) " +
                 "VALUES(1)");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Imoveis");
        }
    }
}
