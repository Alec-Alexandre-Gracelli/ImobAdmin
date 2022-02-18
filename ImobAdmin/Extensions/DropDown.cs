using ImobAdmin.Context;
using ImobAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ImobAdmin.Extensions
{
    public class DropDown
    {

        public static async Task<List<SelectListGenerica>> RetornaCidades(AppDbContext _context)
        {
            return await _context.Cidades
                .OrderBy(o => o.CidadeNome)
                .Select(s => new SelectListGenerica
                {
                    ID = s.CidadeId,
                    Nome = s.CidadeNome,

                }).ToListAsync();
        }

        public static async Task<List<SelectListGenerica>> RetornaBairros(AppDbContext _context)
        {
            return await _context.Bairros
                .OrderBy(o => o.Cidade.CidadeNome)
                .OrderBy(o => o.BairroNome)
                .Select(s => new SelectListGenerica
                {
                    ID = s.BairroId,
                    Nome = $"{s.Cidade.CidadeNome} - {s.BairroNome}",

                }).ToListAsync();



        }

        public static async Task<SelectList> RetornaCidadeNutella(AppDbContext _context, int? valorSelecionado = null)
        {
            var obj = await RetornaCidades(_context);


            return new SelectList(obj, "CidadeId", "CidadeNome", valorSelecionado);

        }
    }
}
