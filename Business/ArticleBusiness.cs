using Repositories.Contracts;
using Business.Contracts;
using Entities;

namespace Business
{
	public class ArticleBusiness : IArticleBusiness
	{
		public IArticleRepository _articleRepository;
		public ArticleBusiness(IArticleRepository ArticleRepository)
		{
			_articleRepository = ArticleRepository;

		}
		public async Task<List<Article>> GetArticles()
		{
			return await _articleRepository.GetArticles();
		}
		
		public async Task Create(Article article)
		{
			await _articleRepository.Create(article);
		}

		public async Task<Article> Read(int id)
		{
			return await _articleRepository.Read(id);
		}

		public async Task Update(Article article)
		{
			try
			{
				await _articleRepository.Update(article);
			}
			catch (Exception Ex)
			{

				throw new Exception(Ex.Message);
			};
		}
		public async Task Delete(int id)
		{
			try
			{
				await _articleRepository.Delete(id);
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);

			}
		}
	}
}
