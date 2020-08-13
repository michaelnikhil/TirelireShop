using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TirelireShop.DataAccess;
using TirelireShop.Models;
using TirelireShop.Repository;

namespace TirelireShop.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Produit> repoProduit;
        private DBTirelireShopContext ctx;
        private readonly ILogger<HomeController> _logger;

        public HomeController(  ILogger<HomeController> logger)
        {
            ctx = new DBTirelireShopContext();
            repoProduit = new RepositoryTirelire<Produit>(ctx);
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(repoProduit.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
