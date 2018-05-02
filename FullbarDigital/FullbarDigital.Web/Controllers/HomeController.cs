using FullbarDigital.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FullbarDigital.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Aluno");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}