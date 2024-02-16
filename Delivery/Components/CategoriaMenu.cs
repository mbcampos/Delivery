using Delivery.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.Categorias.OrderBy(x => x.CategoriaNome);
            return View(categorias);
        }
    }
}
