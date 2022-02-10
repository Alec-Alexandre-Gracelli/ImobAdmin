using ImobAdmin.Models;

namespace ImobAdmin.Repositories.Interfaces
{
    public interface IImovelRepository
    {
        IEnumerable<Imovel> Imoveis { get; }
        IEnumerable<Imovel> EmDestaques { get; }
        Imovel GetImovelById(int ImovelId);

    }
}
