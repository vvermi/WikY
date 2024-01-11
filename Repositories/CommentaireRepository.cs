using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
	public class CommentaireRepository : ICommentaireRepository
	{
		private Context _context;
		public CommentaireRepository(Context context)
		{
			_context = context;
		}
		public List<Commentaire> GetCommentaires()
		{
			return _context.Commentaires.ToList();
		}

		public void Create(Commentaire commentaire)
		{
			_context.Commentaires.Add(commentaire);
			_context.SaveChanges();
		}



		public Commentaire Read(int id)
		{
			return _context.Commentaires.FirstOrDefault(a => a.Id == id);
		}

		public bool Update(Commentaire commentaire)
		{
			bool ok;
			try
			{
				var commentaireToEdit = _context.Commentaires.FirstOrDefault(a => a.Id == commentaire.Id);
				commentaireToEdit.Auteur = commentaire.Auteur;
				commentaireToEdit.Contenu = commentaire.Contenu;
				commentaireToEdit.DateMod = DateTime.Now;
				_context.SaveChanges();
				ok = true;
			}
			catch (Exception ex)
			{
				ok = false;

			}
			return ok;
		}

		public bool Delete(int id)
		{
			bool ok;
			try
			{
				_context.Commentaires.Remove(_context.Commentaires.FirstOrDefault(a => a.Id == id));
				_context.SaveChangesAsync();
				ok = true;
			}
			catch (Exception ex)
			{
				ok = false;
			}
			return ok;

		}
		public async Task<List<Commentaire>> Search(string name)
		{
			//return await petContext.Pets.Where(p => EF.Functions.Like(p.Name, $"%{name}%")).ToListAsync();
			return await _context.Commentaires.Where(p => p.Auteur.Contains(name)).ToListAsync();
		}

		public async Task<List<Commentaire>> GetAllAsync()
		{
			return await _context.Commentaires.ToListAsync();
		}
	}
}
