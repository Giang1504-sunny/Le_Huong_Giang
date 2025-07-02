using DeMoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        // GET: /Person/
        public IActionResult Index()
        {
            return View();
        }
        // GET: /Person/Welcome/ 
        [HttpPost]
    public IActionResult Index(Person ps)
    {
        string str0utput = "Xinchao" + ps.PersonID + "-" + ps.Fullname + "-" + ps.Address;
        ViewBag.infoPerson = str0utput;
        return View();
    }
    }
}
