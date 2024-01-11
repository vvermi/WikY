using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private Context _context;
        public ArticleRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<Article>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        public void Create(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

       

        public Article Read(int id)
        {
            return _context.Articles.FirstOrDefault(a => a.Id == id);
        }

        public bool Update(Article article)
        {
            bool ok;
            try
            {
                var articleToEdit = _context.Articles.FirstOrDefault(a => a.Id == article.Id);
				articleToEdit.Auteur = article.Auteur;
				articleToEdit.Contenu = article.Contenu;
				articleToEdit.DateMod = DateTime.Now;
                _context.SaveChanges();
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;

            }
            return ok;
        }

		public bool Delete(int id)
		{
			bool ok;
			try
			{
				_context.Articles.Remove(_context.Articles.FirstOrDefault(a => a.Id == id));
				_context.SaveChangesAsync();
				ok = true;
			}
			catch (Exception ex)
			{
				ok = false;
			}
			return ok;

		}
		public async Task<List<Article>> Search(string name)
        {
            //return await petContext.Pets.Where(p => EF.Functions.Like(p.Name, $"%{name}%")).ToListAsync();
            return await _context.Articles.Where(p => p.Auteur.Contains(name)).ToListAsync();
        }

        public async Task<List<Article>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
        }
    }
}
