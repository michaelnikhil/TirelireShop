using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TirelireShop.DataAccess;
using TirelireShop.Repository;

namespace TirelireShop.Controllers
{
    public class FabricantController : Controller
    {

        private IRepository<Fabricant> repoFabricant;
        private DBTirelireShopContext ctx;


        public FabricantController()
        {
            ctx = new DBTirelireShopContext();
            repoFabricant = new RepositoryTirelire<Fabricant>(ctx);
        }


        // GET: FabricantController
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(repoFabricant.GetAll());

        }

        // GET: FabricantController/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int id)
        {
            return View(repoFabricant.GetItem(id));
        }

        // GET: FabricantController/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FabricantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Fabricant fabricant)
        {
            try
            {
                repoFabricant.InsertItem(fabricant);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FabricantController/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            return View(repoFabricant.GetItem(id));
        }

        // POST: FabricantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Fabricant fabricant)
        {
            try
            {
                repoFabricant.UpdateItem(fabricant);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FabricantController/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            return View(repoFabricant.GetItem(id));
        }

        // POST: FabricantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(Fabricant fabricant)
        {
            try
            {
                repoFabricant.DeleteItem(fabricant);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
