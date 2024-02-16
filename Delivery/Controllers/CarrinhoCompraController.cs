using Delivery.Models;
using Delivery.ViewModels;
using Delivery.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers 
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public ActionResult Index()
        {            
            _carrinhoCompra.CarrinhoCompraItens = _carrinhoCompra.GetCarrinhoCompraItens();

            var carrinhoCompraViewModel = new CarrinhoCompraViewModel() 
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraViewModel);
        }

        public IActionResult AdicionarItemNoCarrinhoCompra(int itemId)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(x => x.LancheId == itemId);

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarItemAoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemDoCarrinho(int itemId)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(x => x.LancheId == itemId);

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }
    }
}