using Microsoft.AspNetCore.Mvc;
using Entities;

namespace Repositories.Contracts
{
	public interface IArticleRepository
	{
		Task<List<Article>> GetArticles();
		void Create(Article article);
		Article Read(int id);
		bool Update(Article article);
		bool Delete(int id);



		Task<List<Article>> Search(string name);

		Task<List<Article>> GetAllAsync();

	}
}
