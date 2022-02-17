using ImobAdmin.Context;
using ImobAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImobAdmin.Controllers
{
    public class ImagensController : Controller
    {
        private readonly AppDbContext _context;

        public ImagensController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Imagem imagem)
        {
            if (ModelState.IsValid)
            {
                _context.Imagens.Add(imagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imagem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagens.FindAsync(id);
            if (imagem == null)
            {
                return NotFound();
            }
            return View(imagem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImagemId,ImagemNome,EhDestaque")] Imagem imagem)
        {
            if (id != imagem.ImagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagemExists(imagem.ImagemId))
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
            return View(imagem);
        }

        public async Task<IActionResult> Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagem = await _context.Imagens.FindAsync(id);
            _context.Imagens.Remove(imagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagemExists(int id)
        {
            return _context.Imagens.Any(e => e.ImagemId == id);
        }
    }
}