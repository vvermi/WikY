using Microsoft.EntityFrameworkCore;
using Entities;
using System.ComponentModel.DataAnnotations;

namespace Repositories
{
	public class Context : DbContext
	{
		public DbSet<Article> Articles { get; set; }
		public DbSet<Commentaire> Commentaires { get; set; }

		public Context(DbContextOptions<Context> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseInMemoryDatabase("WikY_DB");
				optionsBuilder.LogTo(Console.WriteLine);
			}

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var arts = new List<Article>()
			{
				new Article() { Id = 1, Auteur = "Lilyah", Theme = "Les Réseaux Sociaux", Contenu = "Rien", DateCre = new DateTime(2012, 01, 10) },
				new Article() { Id = 2, Auteur = "Kezyah", Theme = "Des licornes dans les contes de fées", Contenu = "Y en a plein, c'est beau une licorne", DateCre = new DateTime(2016, 06, 04) },
				new Article() { Id = 3, Auteur = "Wakko", Theme = "C# rocks !", Contenu = "But does it djent ?", DateCre = new DateTime(1981, 07, 10) }
			};

			var coms = new List<Commentaire>()
			{
				new Commentaire() { Id = 1,ArticleId=1, Auteur="Wakko", Contenu="Lâche ton tel",  DateCre = DateTime.Now },
				new Commentaire() { Id = 2,ArticleId=1, Auteur="Lilyah", Contenu="Mais c'est ma vie sociale",  DateCre = DateTime.Now },
				new Commentaire() { Id = 3,ArticleId=3, Auteur="Jared", Contenu="Everything djent",  DateCre = DateTime.Now }
			};

			modelBuilder.Entity<Article>().HasData(arts);
			modelBuilder.Entity<Commentaire>().HasData(coms);

			base.OnModelCreating(modelBuilder);
		}
	}
}
