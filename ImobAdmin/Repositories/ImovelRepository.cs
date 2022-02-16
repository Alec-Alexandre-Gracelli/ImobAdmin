using ImobAdmin.Context;
using ImobAdmin.Models;
using ImobAdmin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImobAdmin.Repositories
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly AppDbContext _context;

        public ImovelRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Imovel> Imoveis => _context.Imoveis.Include(c => c.Categoria);

        public IEnumerable<Imovel> EmDestaques => _context.Imoveis.Where(p =>
        p.EstaEmDestaque).Include(c => c.Categoria);

        public Imovel GetImovelById(int ImovelId) => _context.Imoveis.FirstOrDefault(I => I.ImovelId == ImovelId);
    }
}