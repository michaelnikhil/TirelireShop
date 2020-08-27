using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using TirelireShop;
using TirelireShop.Repository;
using System.Linq;

namespace UnitTests
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
        public void Test1()
        {
            var result = repoCouleur.GetAll().Select(c => c.Couleur1).ToList();
            Assert.AreEqual(couleurs, result);
        }
    }
}