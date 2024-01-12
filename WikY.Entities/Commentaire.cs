using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
	/// <summary>
	///• Auteur (obligatoire)
	///• Date de création(Date générée automatiquement côté serveur lors de la création)
	///• Date de modification(Date générée automatiquement côté serveur lors de la modification)
	///• Contenu(taille max 100 caractères)
	///• Un et un seul article
	/// </summary>
	public class Commentaire
	{
		public int Id { get; set; }
		[Required]
		[StringLength(30, ErrorMessage = "Max 30 caractères")]
		public string Auteur { get; set; }
		public DateTime DateCre { get; set; } = DateTime.Now;
		public DateTime? DateMod { get; set; }
		public string Contenu { get; set; }
		[ForeignKey("Article")]
		public int ArticleId { get; set; }
	}
}
