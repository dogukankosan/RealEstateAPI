using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.AdminShared
{
    public class AdminSharedSearchComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}