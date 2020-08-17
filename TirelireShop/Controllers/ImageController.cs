using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using TirelireShop.DataAccess;
using TirelireShop.Repository;

namespace TirelireShop.Controllers
{
    public class ImageController : Controller
    {
        IRepository<Image> repoImage;
        DBTirelireShopContext ctx;
        // GET: ImageController

        public ImageController()
        {
            ctx = new DBTirelireShopContext();
            repoImage = new RepositoryTirelire<Image>(ctx);
        }

        public ActionResult Index()
        {
            return View(repoImage.GetAll());
        }

        // GET: ImageController/Details/5
        public ActionResult Details(int id)
        {
            return View(repoImage.GetItem(id));
        }

        // GET: ImageController/Create  //on remplit le formulaire
        public ActionResult Create()
        {

            return View();
        }

        // POST: ImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Image image)
        {
            try
            {
                repoImage.InsertItem(image);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImageController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(repoImage.GetItem(id));
        }

        // POST: ImageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Image image)
        {
            try
            {
                repoImage.UpdateItem(image);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repoImage.GetItem(id));
        }

        // POST: ImageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Image image)
        {
            try
            {
                repoImage.DeleteItem(image);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}