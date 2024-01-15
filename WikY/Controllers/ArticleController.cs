using Microsoft.AspNetCore.Mvc;
using Entities;
using Business.Contracts;
using Microsoft.AspNetCore.Server.HttpSys;


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
            if (await _articleBusiness.Create(article))
            {
                TempData["Message"] = "Article créé";
            }
            else
            {
                TempData["Message"] = "Article non créé";
            }

            //return RedirectToAction("Read", new { id = article.Id });
            return RedirectToAction("AllArticles");
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
            if (await _articleBusiness.Update(article))
            {
                TempData["Message"] = "Article modifié";
            }
            else
            {
                TempData["Message"] = "Article non modifié";
            }
            return RedirectToAction("Read", new { id = article.Id });
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (await _articleBusiness.Delete(id))
            {
                TempData["Message"] = "Article supprimé";
            }
            else
            {
                TempData["Message"] = "Article non supprimé";
            }
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

        public async Task<IActionResult> SearchAjax(string str)
        {
            return PartialView("_displayArticlesPartial", await _articleBusiness.Search(str));
        }

        [HttpGet]
        public async Task<IActionResult> Recherche(string str = "", int pageNumber = 1)
        {
            TempData["Page"] = pageNumber;

            var arts = await _articleBusiness.GetArticles();

            if (str == "")
            {

            }
            else
            {
                arts = await _articleBusiness.Search(str);

            }


            return View(arts.OrderBy(a => a.DateCre).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> RechercheAjax(string str = "", int pageNumber = 1)
        {
            TempData["Page"] = pageNumber;

            var arts = await _articleBusiness.GetArticles();

            if (str == "")
            {

            }
            else
            {
                arts = await _articleBusiness.Search(str);

            }


            return PartialView("_SearchArticlesPartial", arts.OrderBy(a => a.DateCre).ToList());
        }


    }
}
