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
		public async Task<bool> Create(Article article)
		{
			return await _articleRepository.Create(article);
		}
		public async Task<Article> Read(int id)
		{
			return await _articleRepository.Read(id);
		}
		public async Task<bool> Update(Article article)
		{
			return await _articleRepository.Update(article);
		}
		public async Task<bool> Delete(int id)
		{
			return await _articleRepository.Delete(id);
		}
	}
}
