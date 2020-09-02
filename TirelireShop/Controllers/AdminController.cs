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

            //top5 produit : get Idproduit in DetailCommande table
            IEnumerable < DetailsCommande > top5 = repoDetailsCommande
                .GetAll()
                .GroupBy(c => c.Idproduit)
                .Select(group => new DetailsCommande
                {
                    Idproduit = group.Key,
                    Quantite = group.Sum(hit => hit.Quantite),
                    IdproduitNavigation = new Produit { Nom = 
                    repoProduit.GetAll().Where(c=>c.Idproduit==group.Key).Select(d=>d.Nom).FirstOrDefault()
                    }
                })
                .OrderByDescending(hit => hit.Quantite)
                .Take(5);

            return View(top5);
                  
        }
        public IActionResult PalmaresClient()
        {
            //top5 client
            IEnumerable<Client> top5 = repoClient
                .GetAll()
                .Take(5);
            return View(top5);
        }

    }
}
