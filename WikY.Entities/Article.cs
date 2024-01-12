using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Entities
{
	/// <summary>
	///• Thème (unique)
	///• Auteur(obligatoire) (taille max 30 caractères)
	///• Date de création(Date générée automatiquement côté serveur lors de la création)
	///• Date de modification(Date générée automatiquement côté serveur lors de la modification)
	///• Contenu
	///• Liste de commentaires
	/// </summary>
	public class Article
	{
		public int Id { get; set; }
		[Remote("IsThemeUnique", "Article", ErrorMessage = "Error: Thème existant")]
		public string Theme { get; set; }
		[Required]
		[StringLength(30, ErrorMessage = "Max 30 caractères")]
		public string Auteur { get; set; }
		public string Contenu { get; set; }
		public DateTime DateCre { get; set; } = DateTime.Now;
		public DateTime? DateMod { get; set; }
		public List<Commentaire>? Commentaires { get; set; }

	}
}
