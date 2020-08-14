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
    public class StatutCommandeController : Controller
    {
        private IRepository<StatutCommande> repoStatutCommande;
        private DBTirelireShopContext ctx;

        public StatutCommandeController()
        {
            ctx = new DBTirelireShopContext();
            repoStatutCommande = new RepositoryTirelire<StatutCommande>(ctx);
        }

        // GET: StatutCommandeController
        public ActionResult Index()
        {
            return View(repoStatutCommande.GetAll());
        }

        // GET: StatutCommandeController/Details/5
        public ActionResult Details(int id)
        {
            return View(repoStatutCommande.GetItem(id));
        }

        // GET: StatutCommandeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatutCommandeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StatutCommande statutCommande)
        {
            try
            {
                repoStatutCommande.InsertItem(statutCommande);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatutCommandeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repoStatutCommande.GetItem(id));
        }

        // POST: StatutCommandeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StatutCommande statutCommande)
        {
            try
            {
                repoStatutCommande.UpdateItem(statutCommande);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatutCommandeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repoStatutCommande.GetItem(id));
        }

        // POST: StatutCommandeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(StatutCommande statutCommande)
        {
            try
            {
                repoStatutCommande.DeleteItem(statutCommande);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}