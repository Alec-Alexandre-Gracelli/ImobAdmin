using ImobAdmin.Context;
using ImobAdmin.Models;
using ImobAdmin.Repositories.Interfaces;
using ImobAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImobAdmin.Controllers
{
    public class ImovelController : Controller
    {
        private readonly AppDbContext _context;

        public ImovelController(AppDbContext context)
        {
            _context = context;
        }

        private readonly IImovelRepository _imovelRepository;
        public ImovelController(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        public IActionResult Index(string categoria)
        {
            IEnumerable<Imovel> imoveis;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                imoveis = _imovelRepository.Imoveis.OrderBy(l => l.ImovelId);
                categoriaAtual = "Todos os Imoveis";
            }
            else
            {
                imoveis = _imovelRepository.Imoveis
                          .Where(l => l.Categoria.NomeCategoria.Equals(categoria))
                          .OrderBy(c => c.TipoAcao);

                categoriaAtual = categoria;
            }

            var imovelListViewModel = new ImovelListViewModel
            {
                Imoveis = imoveis,
                CategoriaAtual = categoriaAtual
            };

            return View(imoveis);
        }

        public IActionResult Details(int imovelId)
        {
            var imovel = _imovelRepository.Imoveis.FirstOrDefault(l => l.ImovelId == imovelId);
            return View(imovel);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Imovel> imoveis;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                imoveis = _imovelRepository.Imoveis.OrderBy(p => p.ImovelId);
                categoriaAtual = "Todos os Imoveis";
            }
            else
            {
                imoveis = _imovelRepository.Imoveis
                        .Where(p => p.NomeImovel.ToLower().Contains(searchString.ToLower()));
                if (imoveis.Any())
                    categoriaAtual = "Imoveis";
                else
                    categoriaAtual = "Nenhum imovel foi encontrado";
            }
            return View("~/Views/Imovel/List.cshtml", new ImovelListViewModel
            {
                Imoveis = imoveis,
                CategoriaAtual = categoriaAtual
            });
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Imoveis.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imovel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }
            return View(imovel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImovelId,NomeImovel,Preco,NomeContato,TelContato,TipoAcao,EstaEmDestaque,Descricao," +
            "Dormitorios,Banheiros,Sala,Cozinha,Vagas,Churrasqueira,Piscina,Edicula")] Imovel imovel)
        {
            if (id != imovel.ImovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.ImovelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(imovel);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .FirstOrDefaultAsync(m => m.ImovelId == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);
            _context.Imoveis.Remove(imovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
            return _context.Imoveis.Any(e => e.ImovelId == id);
        }
    }
}