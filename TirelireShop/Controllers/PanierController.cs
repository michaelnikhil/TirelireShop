using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TirelireShop.DataAccess;
using TirelireShop.Repository;
using TirelireShop.ViewModels;

namespace TirelireShop.Controllers
{
    public class PanierController : Controller
    {
        private IRepository<Produit> repoProduit;
        private IRepository<Commande> repoCommande;
        private IRepository<DetailsCommande> repoDetailsCommande;
        private DBTirelireShopContext ctx;

        public PanierController()
        {
            ctx = new DBTirelireShopContext();
            repoProduit = new RepositoryTirelire<Produit>(ctx);
            repoCommande = new RepositoryTirelire<Commande>(ctx);
            repoDetailsCommande = new RepositoryTirelire<DetailsCommande>(ctx);
        }

        public IActionResult Index()
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Session.GetString("panier") != null)
                    {
                        Commande panier_courant = JsonConvert.DeserializeObject<Commande>(HttpContext.Session.GetString("panier"));

                        //associer table commande et produit en passant par detailProduit, pour afficher nom, poids 
                        foreach (DetailsCommande detail in panier_courant.DetailsCommande)
                        {
                            detail.IdproduitNavigation = repoProduit.GetItem(detail.Idproduit);
                        }
                        return View(panier_courant.DetailsCommande);
                    }
                }
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult ResetShoppingCart()
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Session.GetString("panier") != null)
                    {
                        HttpContext.Session.Clear();
                    }
                }
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult Order()
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Session.GetString("panier") != null)
                    {
                        Commande panier_courant = JsonConvert.DeserializeObject<Commande>(HttpContext.Session.GetString("panier"));
                        repoCommande.InsertItem(panier_courant);

                        //reset shopping cart
                        HttpContext.Session.Clear();
                    }
                }
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}




