using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using TirelireShop.DataAccess;
using TirelireShop.Repository;

//TODO : verifier vue details commande, completer implementation edit (utiliser viewbag pour select list)

namespace TirelireShop.Controllers
{
    public class CommandeController : Controller
    {
        IRepository<Commande> repoCommande;
        DBTirelireShopContext ctx;
        // GET: CouleurController

        public CommandeController()
        {
            ctx = new DBTirelireShopContext();
            repoCommande = new RepositoryTirelire<Commande>(ctx);
        }

        public ActionResult Index()
        {
            return View(repoCommande.GetAll());
        }

        // GET: CouleurController/Details/5
        public ActionResult Details(int id)
        {
            IRepository<DetailsCommande>  repoDetails = new RepositoryTirelire<DetailsCommande>(ctx);
                
              

            return View(repoDetails.GetItem(id));
        }

        // GET: CouleurController/Create  //on remplit le formulaire
        public ActionResult Create()
        {

            return View();
        }

        // POST: CouleurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Commande commande)
        {
            try
            {
                repoCommande.InsertItem(commande);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouleurController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(repoCommande.GetItem(id));
        }

        // POST: CouleurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Commande commande)
        {
            try
            {
                repoCommande.UpdateItem(commande);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouleurController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repoCommande.GetItem(id));
        }

        // POST: CouleurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Commande commande)
        {
            try
            {
                repoCommande.DeleteItem(commande);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
