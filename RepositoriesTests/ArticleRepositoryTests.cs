using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Tests
{
    [TestClass()]
    public class ArticleRepositoryTests
    {

        [TestMethod()]
        public async Task ReadTest()
        {

            var builder =new  DbContextOptionsBuilder<Context>().UseInMemoryDatabase("articles");

            var context = new Context(builder.Options);
            context.Database.EnsureDeleted();
            context.Articles.Add(new Entities.Article() { Id = 1, Auteur = "moi", Contenu="c1", Theme="t1" });
            context.Articles.Add(new Entities.Article() { Id = 2, Auteur = "toi" , Contenu="c2", Theme="t2"});

            context.SaveChanges();

            ArticleRepository articleRepository = new ArticleRepository(context);

            var article = await articleRepository.Read(2);

            Assert.AreEqual(article.Auteur, "toi");
        }
    }
}