using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
    public class LayoutHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
             return View();
        }
    }
}
