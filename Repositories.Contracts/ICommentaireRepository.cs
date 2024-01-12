using Microsoft.AspNetCore.Mvc;
using Entities;

namespace Repositories.Contracts
{
	public interface ICommentaireRepository
	{
		public Task<List<Commentaire>> AllCommentaires();
		public Task<bool> Create(Commentaire commentaire);
		public Task<Commentaire> Read(int id);
		public Task<bool> Update(Commentaire commentaire);
		public Task<bool> Delete(int id);



		Task<List<Commentaire>> Search(string name);

		Task<List<Commentaire>> GetAllAsync();

	}
}
