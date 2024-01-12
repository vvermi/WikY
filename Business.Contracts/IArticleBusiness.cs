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
		public Task Create(Article article);
		public Task<Article> Read(int id);
        public Task Update(Article article);
        public Task Delete(int id);
    }
}
