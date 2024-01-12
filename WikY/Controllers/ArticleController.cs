using Microsoft.AspNetCore.Mvc;
using Entities;
using Business.Contracts;


namespace WikY.Controllers
{
	public class ArticleController : Controller
	{
		//static List<Article> Articles = new List<Article>(){
		//	new Article() { Id = 0, Auteur = "Lilyah", Theme="Les Réseaux Sociaux", Contenu ="Rien" } 
		//};

		//private readonly Context _context;
		//public ArticleController(Context context)
		//{
		//	_context = context;
		//}

		private IArticleBusiness _articleBusiness;
		private ILogger<ArticleController> _logger;
		public ArticleController(IArticleBusiness articleBusiness, ILogger<ArticleController> logger)
		{
			this._articleBusiness = articleBusiness;
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> AllArticles()
		{
			return View(await _articleBusiness.GetArticles());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Article article)
		{
			await _articleBusiness.Create(article);
			TempData["Message"] = "Article créé";

			//return RedirectToAction("Read", new { id = article.Id });
			return RedirectToAction("ReadAll");
		}

		public async Task<IActionResult> Read(int id)
		{
			var article = await _articleBusiness.Read(id);
			if (article == null) return NotFound();
			return View(article);
		}

		public async Task<IActionResult> Update(int id)
		{
			return View(await _articleBusiness.Read(id));
		}
		[HttpPost]
		public async Task<IActionResult> Update(Article article)
		{
			await _articleBusiness.Update(article);
			TempData["Message"] = "Article modifié";
			return RedirectToAction("Read", new { id = article.Id });
		}
		public async Task<IActionResult> Delete(int id)
		{
			await _articleBusiness.Delete(id);
			TempData["Message"] = "Article modifié";
			return RedirectToAction("AllArticles");
		}

		public ActionResult IsThemeUnique(string Theme)
		{
			bool res = false;

			var truc = (_articleBusiness.GetArticles().Result).FirstOrDefault(e => e.Theme == Theme);

			if (truc == null)
			{
				res = true;
			}

			return Json(res);
		}
	}
}
