using ImobAdmin.Models;

namespace ImobAdmin.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
