using Entities;
using Microsoft.AspNetCore.Mvc;
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
		public async Task<List<Commentaire>> GetCommentaires()
		{
			return await _context.Commentaires.ToListAsync();
		}

		public async Task<bool> Create(Commentaire commentaire)
		{
			try
			{
				_context.Commentaires.Add(commentaire);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}



		public async Task<Commentaire> Read(int id)
		{
			return await _context.Commentaires.FirstOrDefaultAsync(a => a.Id == id);
		}

		public async Task<bool> Update(Commentaire commentaire)
		{
			try
			{
				var commentaireToEdit = await _context.Commentaires.FirstOrDefaultAsync(a => a.Id == commentaire.Id);
				commentaireToEdit.Auteur = commentaire.Auteur;
				commentaireToEdit.Contenu = commentaire.Contenu;
				commentaireToEdit.DateMod = DateTime.Now;
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}

		}

		public async Task<bool> Delete(int id)
		{
			bool deleted = false;
			try
			{
				_context.Commentaires.Remove(await _context.Commentaires.FirstOrDefaultAsync(a => a.Id == id));
				await _context.SaveChangesAsync();
				deleted = true;
			}
			catch (Exception ex)
			{
				deleted = false;
			}
			return deleted;
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
