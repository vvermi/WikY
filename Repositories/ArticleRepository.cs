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

		public async Task<bool> Create(Article article)
		{
			bool created = false;
			try
			{
				_context.Articles.Add(article);
				await _context.SaveChangesAsync();
				created = true;
			}
			catch (Exception)
			{
				created = false;
			}
			return created;
		}



		public async Task<Article> Read(int id)
		{
			return await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);
		}

		public async Task<bool> Update(Article article)
		{
			bool updated;
			try
			{
				var articleToEdit = _context.Articles.FirstOrDefault(a => a.Id == article.Id);
				articleToEdit.Auteur = article.Auteur;
				articleToEdit.Contenu = article.Contenu;
				articleToEdit.DateMod = DateTime.Now;
				await _context.SaveChangesAsync();
				updated = true;
			}
			catch (Exception ex)
			{
				updated = false;
			}
			return updated;
		}

		public async Task<bool> Delete(int id)
		{
			bool deleted;
			try
			{
				_context.Articles.Remove(_context.Articles.FirstOrDefault(a => a.Id == id));
				await _context.SaveChangesAsync();
				deleted = true;
			}
			catch (Exception ex)
			{
				deleted = false;
			}
			return deleted;
		}
		public async Task<List<Article>> Search(string name)
		{
			return await _context.Articles.Where(a => a.Auteur.Contains(name)).ToListAsync();
		}

		public async Task<List<Article>> GetAllAsync()
		{
			return await _context.Articles.ToListAsync();
		}
	}
}
