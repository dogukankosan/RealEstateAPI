using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.Shared
{
    public class SharedConsulationComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}