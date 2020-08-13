using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TirelireShop.Controllers
{
    public class CouleurController : Controller
    {
        // GET: CouleurController
        public ActionResult Index()
        {
            DBTirelireShopContext ctx = new DBTirelireShopContext();
            return View(ctx.Couleur);
        }

        // GET: CouleurController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CouleurController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CouleurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: CouleurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: CouleurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
