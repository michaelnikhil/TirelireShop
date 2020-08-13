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
        public ActionResult Index()
        {
            return View(repoFabricant.GetAll());

        }

        // GET: FabricantController/Details/5
        public ActionResult Details(int id)
        {
            return View(repoFabricant.GetItem(id));
        }

        // GET: FabricantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FabricantController/Create
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

        // GET: FabricantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FabricantController/Edit/5
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

        // GET: FabricantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FabricantController/Delete/5
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
