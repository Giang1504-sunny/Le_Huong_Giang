using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DeMoMVC.Models;

namespace DeMoMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(string Fullname, string Address)
    {
        string str0utput = "Xinchao" + Fullname + "Den tu" + Address;
        ViewBag.Message = str0utput;
        return View();
    }
}
