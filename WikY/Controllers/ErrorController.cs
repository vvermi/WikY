using Microsoft.AspNetCore.Mvc;
using WikY.Models;

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
