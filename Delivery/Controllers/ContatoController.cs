using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers;

public class ContatoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
