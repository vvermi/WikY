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
		public Task<List<Commentaire>> AllCommentaires();
		public Task<bool> Create(Commentaire commentaire);
		public Task<Commentaire> Read(int id);
		public Task<bool> Update(Commentaire commentaire);
		public Task<bool> Delete(int id);
	}
}
