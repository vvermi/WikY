using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Contracts;
using Business.Contracts;
using Entities;
using Repositories;

namespace Business
{
	public class ArticleBusiness : IArticleBusiness
	{
		public IArticleRepository _articleRepository;
		public ArticleBusiness(IArticleRepository ArticleRepository)
		{
			_articleRepository = ArticleRepository;

		}
		public List<Article> GetArticles()
		{

			return _articleRepository.GetArticles();
		}
		public void Create(string Theme, string Auteur, string Contenu)
		{
			throw new NotImplementedException();
		}

		public void Create(Article article)
		{
			_articleRepository.Create(article);
		}

		public Article Read(int id)
		{
			return _articleRepository.Read(id);
		}



		public void Update(Article article)
		{
			try
			{
				_articleRepository.Update(article);
			}
			catch (Exception Ex)
			{

				throw new Exception(Ex.Message);
			};
		}
		public void Delete(int id)
		{
			try
			{
				_articleRepository.Delete(id);
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);

			}
		}
	}
}
