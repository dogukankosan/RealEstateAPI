using Microsoft.AspNetCore.Mvc;

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