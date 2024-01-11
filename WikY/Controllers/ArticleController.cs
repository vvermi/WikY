using Microsoft.AspNetCore.Mvc;
using Entities;
using Business;
using Repositories;
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
		public ArticleController(IArticleBusiness articleBusiness)
		{
			this._articleBusiness = articleBusiness;
		}

		public IActionResult Index()
        {
            return View();
        }

		public IActionResult AllArticles()
		{
			return View(_articleBusiness.GetArticles());
		}

		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		public IActionResult Create(Article article)
		{
			_articleBusiness.Create(article);

			TempData["Message"] = "Article créé";

			//return RedirectToAction("Read", new { id = article.Id });
			return RedirectToAction("ReadAll");

		}

		public IActionResult Read(int id) {

            var article = _articleBusiness.Read(id);
            if (article == null) return NotFound();
            return View(article); }

		
		public IActionResult Update(int id)
		{
			var article = _articleBusiness.Read(id);
			return View(article);
		}
		[HttpPost]
		public IActionResult Update(Article article)
		{
			_articleBusiness.Update(article);

			TempData["Message"] = "Article modifié";
			return RedirectToAction("Read", new { id = article.Id });
		}
		public IActionResult Delete(int id) 
		{
			_articleBusiness.Delete(id);
			TempData["Message"] = "Article modifié";
			return RedirectToAction("AllArticles");
		}

		public ActionResult IsThemeUnique(string Theme)
		{
			bool res = false;

			var truc = _articleBusiness.GetArticles().FirstOrDefault(e => e.Theme == Theme);

			if (truc == null)
			{
				res = true;
			}

			return Json(res);
		}
	}
}
