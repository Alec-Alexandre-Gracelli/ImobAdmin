using ImobAdmin.Context;
using ImobAdmin.Extensions;
using ImobAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ImobAdmin.Controllers
{
    public class BairrosController : Controller
    {
        private readonly AppDbContext _context;

        public BairrosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Bairros.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bairro = await _context.Bairros
                .FirstOrDefaultAsync(m => m.BairroId == id);
            if (bairro == null)
            {
                return NotFound();
            }

            return View(bairro);
        }

        public async Task<IActionResult> Create()
        {

            ViewBag.CidadeId = new SelectList(await DropDown.RetornaCidades(_context), "ID", "Nome");

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                _context.Bairros.Add(bairro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CidadeId = new SelectList(await DropDown.RetornaCidades(_context), "ID", "Nome", bairro.CidadeId);



            return View(bairro);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bairro = await _context.Bairros.FindAsync(id);
            if (bairro == null)
            {
                return NotFound();
            }
            ViewBag.CidadeId = new SelectList(await DropDown.RetornaCidades(_context), "ID", "Nome", bairro.CidadeId);



            return View(bairro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,BairroNome")] Bairro bairro)
        {
            if (id != bairro.BairroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bairro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BairroExists(bairro.BairroId))
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
            ViewBag.CidadeId = new SelectList(await DropDown.RetornaCidades(_context), "ID", "Nome", bairro.CidadeId);

            return View(bairro);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bairro = await _context.Bairros
                .FirstOrDefaultAsync(m => m.BairroId == id);
            if (bairro == null)
            {
                return NotFound();
            }

            return View(bairro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bairro = await _context.Bairros.FindAsync(id);
            _context.Bairros.Remove(bairro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BairroExists(int id)
        {
            return _context.Bairros.Any(e => e.BairroId == id);
        }
    }
}
