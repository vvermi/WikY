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
		public List<Article> GetArticles();
		public void Create(string Theme, string Auteur, string Contenu);
		public void Create(Article article);
		public Article Read(int id);
        
        public void Update(Article article);
        public void Delete(int id);
    }
}
