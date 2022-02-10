using ImobAdmin.Models;

namespace ImobAdmin.ViewModel
{
    public class ImovelListViewModel
    {
        public IEnumerable<Imovel> Imoveis { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
