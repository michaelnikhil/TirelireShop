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

        private IRepository<DetailsCommande> repoCommande;
        private DBTirelireShopContext ctx;

        public PanierController()
        {
            ctx = new DBTirelireShopContext();
            repoCommande = new RepositoryTirelire<DetailsCommande>(ctx);
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
    }
}




