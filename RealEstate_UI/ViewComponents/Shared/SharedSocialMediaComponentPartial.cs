using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.Shared
{
    public class SharedSocialMediaComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}