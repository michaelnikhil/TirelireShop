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
    public class ClientController : Controller
    {
        private IRepository<Client> repoClient;
        private DBTirelireShopContext ctx;

        public ClientController()
        {
            ctx = new DBTirelireShopContext();
            repoClient = new RepositoryTirelire<Client>(ctx);
        }

        // GET: ClientController
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(repoClient.GetAll());
        }

        // GET: ClientController/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int id)
        {
            return View(repoClient.GetItem(id));
        }

        // GET: ClientController/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Client client)
        {
            try
            {
                repoClient.InsertItem(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            return View(repoClient.GetItem(id));
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Client client)
        {
            try
            {
                repoClient.UpdateItem(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            return View(repoClient.GetItem(id));
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(Client client)
        {
            try
            {
                repoClient.DeleteItem(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
