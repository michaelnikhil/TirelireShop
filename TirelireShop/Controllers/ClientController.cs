using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TirelireShop.DataAccess;
using TirelireShop.Repository;

namespace TirelireShop.Controllers
{
    public class ClientController : Controller
    {
        private IRepository<Client> repoClient;
        private DBTirelireShopContext ctx;
        private UserManager<Client> _userManager;

        public ClientController(UserManager<Client> userManager)
        {
            ctx = new DBTirelireShopContext();
            repoClient = new RepositoryTirelire<Client>(ctx);
            _userManager = userManager;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            return View(repoClient.GetAll());
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View(repoClient.GetItem(id));
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Edit(int id)
        {
            return View(repoClient.GetItem(id));
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Delete(int id)
        {
            return View(repoClient.GetItem(id));
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
