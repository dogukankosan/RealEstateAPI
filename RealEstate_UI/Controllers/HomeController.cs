using Microsoft.AspNetCore.Mvc;
using RealEstate_UI.Models;
using System.Diagnostics;

namespace RealEstate_UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}