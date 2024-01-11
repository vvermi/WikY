using Microsoft.AspNetCore.Mvc;
using Entities;

namespace Repositories.Contracts
{
	public interface ICommentaireRepository
	{
		List<Commentaire> GetCommentaires();
		void Create(Commentaire commentaire);
		Commentaire Read(int id);
		bool Update(Commentaire commentaire);
		bool Delete(int id);



		Task<List<Commentaire>> Search(string name);

		Task<List<Commentaire>> GetAllAsync();

	}
}
