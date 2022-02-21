using ImobAdmin.Context;
using ImobAdmin.Extensions;
using ImobAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ImobAdmin.Controllers
{
    public class ImoveisController : Controller
    {
        private readonly AppDbContext _context;

        public ImoveisController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Imoveis.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagens
                .FirstOrDefaultAsync(m => m.ImagemId == id);
            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Cat = new SelectList(_context.Categorias.ToList(), "CategoriaId", "CategoriaNome");
            ViewBag.Bairro = new SelectList(await DropDown.RetornaBairros(_context), "ID", "Nome");


            ViewData["Status"] = this.MontarSelectListParaEnum(new TipoAcao());

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                imovel.ImagemId = 1;
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

            ViewBag.Cat = new SelectList(_context.Categorias.ToList(), "CategoriaId", "NomeCategoria", imovel.CategoriaId);
            ViewBag.Bairro = new SelectList(await DropDown.RetornaBairros(_context), "ID", "Nome", imovel.BairroId);


            ViewData["Status"] = this.MontarSelectListParaEnum(imovel.TipoAcao, true);

            return View(imovel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Imovel imovel)
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