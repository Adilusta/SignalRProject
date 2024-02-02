using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.MenuComponents
{
    public class MenuNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
