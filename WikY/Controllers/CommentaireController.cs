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
			if (ModelState.IsValid)
			{
				await _commentaireBusiness.Create(commentaire);
				TempData["Message"] = "Commentaire Ajouté en .net";
				return RedirectToAction("Read", "Article", new { id = commentaire.ArticleId });
			}
			else
			{
				TempData["Message"] = "Commentaire non Ajouté";
				return RedirectToAction("Read", "Article", new { id = commentaire.ArticleId });
			}
		}
		public async Task<IActionResult> Read(int id)
		{
			var commentaire = await _commentaireBusiness.Read(id);
			if (commentaire == null) return NotFound();
			return View(commentaire);
		}

		public async Task<IActionResult> Update(int id)
		{
			return View(await _commentaireBusiness.Read(id));
		}

		[HttpPost]
		public async Task<IActionResult> Update(Commentaire commentaire)
		{
			if (ModelState.IsValid)
			{
				await _commentaireBusiness.Update(commentaire);
				TempData["Message"] = "Commentaire Modifié";
				return RedirectToAction("Read", new { id = commentaire.Id });
			}
			else
			{
				TempData["Message"] = "Commentaire non Modifié";
				return RedirectToAction("Read", new { id = commentaire.Id });
			}

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

			return RedirectToAction("Read", "Article", new { id = articleId });
		}
		[HttpPost]
		public async Task<IActionResult> Creajax(string auteur, string contenu, int articleId)
		{
			Commentaire commentaire = new Commentaire() { ArticleId = articleId, Auteur = auteur, Contenu = contenu };

			if (await _commentaireBusiness.Create(commentaire))
			{
				TempData["Message"] = "Commentaire Ajouté en Ajax";
			}

			var coms = (await _commentaireBusiness.AllCommentaires()).Where(c => c.ArticleId == articleId).ToList();

			return PartialView("_DisplayCommentairesPartial", coms);
		}
		[HttpPost]
		public async Task<IActionResult> DeleteFullAjax(int commentaireId)
		{
			bool res = false;
			if (await _commentaireBusiness.Delete(commentaireId))
			{
				res = true;
				TempData["Message"] = "Suppr. Ajax et delete row";
			}
			else
			{

				TempData["Message"] = "";

			}

			return Json(res);
		}
		[HttpPost]
		public async Task<IActionResult> DeleteAspAjax(int commentaireId)
		{
			var com = await _commentaireBusiness.Read(commentaireId);
			int articleId = com.ArticleId;

			if (await _commentaireBusiness.Delete(commentaireId))
			{
				TempData["Message"] = "Suppr. Ajax et MAJ vue partielle";
			}
			else
			{
				TempData["Message"] = "";

			}

			var coms = (await _commentaireBusiness.AllCommentaires()).Where(c => c.ArticleId == articleId).ToList();

			return PartialView("_DisplayCommentairesPartial", coms);
		}
	}
}
