using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.AdminShared
{
    public class AdminSharedTopMenuUserInfoComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}