using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.Shared
{
    public class SharedMailSubscripeComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}