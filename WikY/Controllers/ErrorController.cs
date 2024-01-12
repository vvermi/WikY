using Microsoft.AspNetCore.Mvc;

namespace WikY.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}


	}
}
