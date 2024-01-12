using Microsoft.AspNetCore.Mvc;
using Business.Contracts;

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
