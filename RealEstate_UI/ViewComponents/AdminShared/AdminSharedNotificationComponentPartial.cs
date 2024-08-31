using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.AdminShared
{
    public class AdminSharedNotificationComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}