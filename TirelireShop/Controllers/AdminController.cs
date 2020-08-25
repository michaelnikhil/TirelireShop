using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TirelireShop.DataAccess;
using TirelireShop.Repository;

namespace TirelireShop.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<Produit> repoProduit;
        private IRepository<Commande> repoCommande;
        private IRepository<DetailsCommande> repoDetailsCommande;
        private IRepository<Client> repoClient;
        private DBTirelireShopContext ctx;

        public AdminController()
        {
            ctx = new DBTirelireShopContext();
            repoProduit = new RepositoryTirelire<Produit>(ctx);
            repoCommande = new RepositoryTirelire<Commande>(ctx);
            repoDetailsCommande = new RepositoryTirelire<DetailsCommande>(ctx);
            repoClient = new RepositoryTirelire<Client>(ctx);
        }

        // GET: AdminController
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PalmaresCommande()
        {
            IEnumerable<Produit> top5 = repoDetailsCommande.GetAll().Select(d =>  d.IdproduitNavigation).Take(5);
            //IEnumerable<Produit> top5 = repoDetailsCommande
            //    .GetAll()
            //    .Select(d => d.IdproduitNavigation)
            //    .Take(5);
            //var top5 = repoDetailsCommande
            //    .GetAll()
            //    .GroupBy(c=>c.Idproduit)
            //    .Select(c=> new 
            //    {
            //        Idproduit=
            //    })

            //    .Select(d => d.IdproduitNavigation)
            //    .Take(5);

            return View(top5);
            
            
            //List<Produit> top5 = repoDetailsCommande.GetAll()
            //    .OrderBy(c => c.Quantite)
            //    .GroupBy(c => c.Idproduit)
            //    .Select(c => new Produit { });
        }

    }
}
