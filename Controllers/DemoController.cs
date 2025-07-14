using DeMoMVC.Models;
using DeMoMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using StudentModel = DeMoMVC.Models.Entities.Student;

namespace DeMoMVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            string strOutput = "Hello, this is a demo view!";
            ViewBag.Message = strOutput;
            return View();
        }
        [HttpGet]
        public IActionResult SendData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendData(StudentModel std)
        {
            string strOutput = "Hello " + std.FullName + "-" + std.Address + "!";
            ViewBag.Message = strOutput;
            return View();
        }
    }
}