using Delivery.Models;
using Delivery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Delivery;

public class CarrinhoCompraResumo : ViewComponent
{
    private CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
    {
        _carrinhoCompra = carrinhoCompra;
    }

    public IViewComponentResult Invoke()
    {
        _carrinhoCompra.CarrinhoCompraItens = _carrinhoCompra.GetCarrinhoCompraItens();

        var carrinhoCompraViewModel = new CarrinhoCompraViewModel()
        {
            CarrinhoCompra = _carrinhoCompra,
            CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
        };

        return View(carrinhoCompraViewModel);
    }
}
