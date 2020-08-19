using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TirelireShop.DataAccess;
using TirelireShop.Repository;
using TirelireShop.ViewModels;

namespace TirelireShop.Controllers
{
    public class ShoppingCartController : Controller
    {

        private IRepository<DetailsCommande> repoCommande;

        private DBTirelireShopContext ctx;
        private List<DetailsCommande> commandes;
        private SessionStateViewModel sessionModel;

        public ShoppingCartController()
        {
            ctx = new DBTirelireShopContext();
            repoCommande = new RepositoryTirelire<DetailsCommande>(ctx);

        }


        public IActionResult Index()
        {
            return View(repoCommande.GetAll());
        }
    }
}
