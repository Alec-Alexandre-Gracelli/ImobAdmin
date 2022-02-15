using ImobAdmin.Models;
using ImobAdmin.Repositories.Interfaces;
using ImobAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ImobAdmin.Controllers
{
    public class ImovelController : Controller
    {
        private readonly IImovelRepository _imovelRepository;
        public ImovelController(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        public IActionResult List(string categoria)
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
    }
}