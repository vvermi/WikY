using Microsoft.AspNetCore.Mvc;
using Entities;

namespace Repositories.Contracts
{
	public interface IArticleRepository
	{
		Task<List<Article>> GetArticles();
		Task<bool> Create(Article article);
		Task<Article> Read(int id);
		Task<bool> Update(Article article);
		Task<bool> Delete(int id);



		Task<List<Article>> Search(string name);

		Task<List<Article>> GetAllAsync();

	}
}
