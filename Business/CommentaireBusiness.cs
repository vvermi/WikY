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
		public async Task<List<Commentaire>> AllCommentaires()
		{

			return await _commentaireRepository.AllCommentaires();
		}

		public async Task<bool> Create(Commentaire commentaire)
		{
			return await _commentaireRepository.Create(commentaire);
		}

		public async Task<Commentaire> Read(int id)
		{
			return await _commentaireRepository.Read(id);
		}

		public async Task<bool> Update(Commentaire commentaire)
		{
			return await _commentaireRepository.Update(commentaire);
		}
		public async Task<bool> Delete(int id)
		{
			return await _commentaireRepository.Delete(id);
		}
	}
}
