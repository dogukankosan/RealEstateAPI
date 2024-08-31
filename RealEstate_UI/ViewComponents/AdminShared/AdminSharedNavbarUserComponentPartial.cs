using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.AdminShared
{
    public class AdminSharedNavbarUserComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}