using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class ProgressBarController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
