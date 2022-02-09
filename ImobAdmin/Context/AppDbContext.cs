using ImobAdmin.Models;
using Microsoft.EntityFrameworkCore;

namespace ImobAdmin.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet <Imovel> Imoveis { get; set; }
        public DbSet <Imagem> Imagens { get; set; }
        public DbSet <Cidade> Cidades { get; set; }
        public DbSet <Bairro> Bairros { get; set; }
    }
}
