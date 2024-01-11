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
	public class CommentaireBusiness : ICommentaireBusiness
	{
		public ICommentaireRepository _commentaireRepository;
		public CommentaireBusiness(ICommentaireRepository CommentaireRepository)
		{
			_commentaireRepository = CommentaireRepository;

		}
		public List<Commentaire> GetCommentaires()
		{

			return _commentaireRepository.GetCommentaires();
		}
		public void Create(string Theme, string Auteur, string Contenu)
		{
			throw new NotImplementedException();
		}

		public void Create(Commentaire commentaire)
		{
			_commentaireRepository.Create(commentaire);
		}

		public Commentaire Read(int id)
		{
			return _commentaireRepository.Read(id);
		}



		public void Update(Commentaire commentaire)
		{
			try
			{
				_commentaireRepository.Update(commentaire);
			}
			catch (Exception Ex)
			{

				throw new Exception(Ex.Message);
			};
		}
		public void Delete(Commentaire commentaire)
		{
			throw new NotImplementedException();
		}
	}
}
