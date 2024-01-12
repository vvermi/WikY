using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
			return await _context.Articles.Include(a => a.Commentaires).ToListAsync();
		}
		public async Task<bool> Create(Article article)
		{
			try
			{
				_context.Articles.Add(article);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public async Task<Article> Read(int id)
		{
			return await _context.Articles.Include(a => a.Commentaires).FirstOrDefaultAsync(a => a.Id == id);
		}
		public async Task<bool> Update(Article article)
		{
			try
			{
				var articleToEdit = _context.Articles.FirstOrDefault(a => a.Id == article.Id);
				articleToEdit.Auteur = article.Auteur;
				articleToEdit.Contenu = article.Contenu;
				articleToEdit.DateMod = DateTime.Now;
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public async Task<bool> Delete(int id)
		{
			try
			{
				_context.Articles.Remove(await _context.Articles.FirstOrDefaultAsync(a => a.Id == id));
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
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
