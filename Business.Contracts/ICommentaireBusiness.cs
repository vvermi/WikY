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
		public Task<List<Commentaire>> GetCommentaires();
		public Task<bool> Create(Commentaire article);
		public Task<Commentaire> Read(int id);
		public Task<bool> Update(Commentaire article);
		public Task<bool> Delete(int id);
	}
}
