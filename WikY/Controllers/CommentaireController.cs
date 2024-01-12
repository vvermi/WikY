using Microsoft.AspNetCore.Mvc;
using Business.Contracts;
using Business;
using Entities;

namespace WikY.Controllers
{
	public class CommentaireController : Controller
	{
		private ICommentaireBusiness _commentaireBusiness;
		private ILogger<CommentaireController> _logger;
		public CommentaireController(ICommentaireBusiness commentaireBusiness, ILogger<CommentaireController> logger)
		{
			this._commentaireBusiness = commentaireBusiness;
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Create(int articleId)
		{	
			ViewBag.articleId = articleId;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Commentaire commentaire)
		{
			await _commentaireBusiness.Create(commentaire);
			TempData["Message"] = "Commentaire créé";

			//return RedirectToAction("Read", new { id = article.Id });
			return RedirectToAction("Read", "Article", new { id = commentaire.ArticleId });
		}
		public async Task<IActionResult> Delete(int id)
		{
			//back to détail Article
			var com = await _commentaireBusiness.Read(id);
			int articleId = com.ArticleId;

			if (await _commentaireBusiness.Delete(id))
			{
				TempData["Message"] = "Commentaire Supprimé";
			}
			
			_logger.LogError("ERROR !");

			return RedirectToAction( "Read", "Article", new { id = articleId });
		}

	}
}
