using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TirelireShop;
using TirelireShop.Controllers;
using TirelireShop.Repository;
using System.Linq;

namespace NUnitTestProject2
{
    public class Tests
    {
        private RepositoryTirelire<Couleur> repoCouleur;
        private List<string> couleurs = new List<string>() { "vert", "bleu", "rouge" };

        private DBTirelireShopContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DBTirelireShopContext>()
                .UseInMemoryDatabase(databaseName: "DBTirelireShop")
                .Options;
            var databaseContext = new DBTirelireShopContext(options);
            databaseContext.Database.EnsureCreated();

            if (databaseContext.Couleur.Count() <= 0)
            {
                for (int i = 0; i <= 2; i++)
                {
                    databaseContext.Couleur.Add(new Couleur()
                    {
                        Couleur1 = couleurs[i]
                    });
                    databaseContext.SaveChanges();
                }
            }
            return databaseContext;
        }

        [SetUp]
        public void Setup()
        {
            var dbContext = GetDatabaseContext();
            repoCouleur = new RepositoryTirelire<Couleur>(dbContext);
        }

        [Test]
        public void Test1() //method getall
        {
            var result = repoCouleur.GetAll().Select(c => c.Couleur1).ToList();
            Assert.AreEqual(couleurs, result);
        }

        [Test]
        public void Test2() //method getitem
        {
            var result = repoCouleur.GetItem(1).Couleur1.ToString();
            string expected = couleurs[0];
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test3() //method delete
        {
            Couleur couleur_remove = repoCouleur.GetItem(1);
            repoCouleur.DeleteItem(couleur_remove);
            var result = repoCouleur.GetAll().Select(c => c.Couleur1).ToList();
            List<string> expected = new List<string>() { "bleu", "rouge" };
            Assert.AreEqual(expected, result);
        }
    }
}