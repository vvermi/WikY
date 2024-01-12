using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Business.Contracts
{
    public interface IArticleBusiness
    {
		public Task<List<Article>> GetArticles();
		public Task<bool> Create(Article article);
		public Task<Article> Read(int id);
        public Task<bool> Update(Article article);
        public Task<bool> Delete(int id);

		Task<List<Article>> Search(string name);
	}
}
