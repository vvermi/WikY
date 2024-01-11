using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Business.Contracts
{
	public interface ICommentaireBusiness
	{
		public List<Commentaire> GetCommentaires();
		public void Create(string Theme, string Auteur, string Contenu);
		public void Create(Commentaire article);
		public Commentaire Read(int id);

		public void Update(Commentaire article);
		public void Delete(Commentaire article);
	}
}
