using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class AdminController : Controller
{
    public string Index()
    {
        return $"Testando o método Index. A hora nesse momento é {DateTime.Now}";
    }
}
