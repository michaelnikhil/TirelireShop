using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using TirelireShop.DataAccess;
using TirelireShop.Repository;

namespace TirelireShop.Controllers
{
    public class CouleurController : Controller
    {
        IRepository<Couleur> repoCouleur;
        DBTirelireShopContext ctx;
        // GET: CouleurController

        public CouleurController()
        {
            ctx = new DBTirelireShopContext();
            repoCouleur = new RepositoryTirelire<Couleur>(ctx);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(repoCouleur.GetAll());
        }

        // GET: CouleurController/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int id)
        {
            return View(repoCouleur.GetItem(id));
        }

        // GET: CouleurController/Create  //on remplit le formulaire
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {

            return View();
        }

        // POST: CouleurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Couleur couleur)
        {
            try
            {
                repoCouleur.InsertItem(couleur);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouleurController/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {

            return View(repoCouleur.GetItem(id));
        }

        // POST: CouleurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Couleur couleur)
        {
            try
            {
                repoCouleur.UpdateItem(couleur);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouleurController/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            return View(repoCouleur.GetItem(id));
        }

        // POST: CouleurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(Couleur couleur)
        {
            try
            {
                repoCouleur.DeleteItem(couleur);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
