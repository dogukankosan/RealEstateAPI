using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.Shared
{
    public class SharedHelpDeskComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}