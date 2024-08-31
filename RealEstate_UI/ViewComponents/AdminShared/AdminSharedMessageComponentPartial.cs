using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.AdminShared
{
    public class AdminSharedMessageComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return  View();
        }
    }
}