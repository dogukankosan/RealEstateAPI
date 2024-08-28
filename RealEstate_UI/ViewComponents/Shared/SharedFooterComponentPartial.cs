using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.Shared
{
    public class SharedFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}