using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TirelireShop.DataAccess;
using TirelireShop.Repository;

namespace TirelireShop.Controllers
{
    public class ProduitController : Controller
    {

        private IRepository<Produit> repoProduit;
        private IRepository<Image> repoImage;
        private DBTirelireShopContext ctx;
        private IWebHostEnvironment _environment;

        public ProduitController(IWebHostEnvironment environment)
        {
            ctx = new DBTirelireShopContext();
            repoProduit = new RepositoryTirelire<Produit>(ctx);
            repoImage = new RepositoryTirelire<Image>(ctx);
            _environment = environment;
        }

        // GET: ProduitController
        public ActionResult Index()
        {
            return View(repoProduit.GetAll());
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            return View(repoProduit.GetItem(id));
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            //list des couleurs pour la select list
            ViewBag.couleurs = new RepositoryTirelire<Couleur>(ctx).GetAll().Select(
                c => new SelectListItem { Text = c.Couleur1, Value = c.Idcouleur.ToString() }
                );

            //liste des fabricants pour al select list 
            ViewBag.fabricants = new RepositoryTirelire<Fabricant>(ctx).GetAll().Select(
                c => new SelectListItem { Text = c.Nom, Value = c.Idfabricant.ToString() }
                );
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produit produit, IFormFile fichier)
        {
            try
            {
                repoProduit.InsertItem(produit);
                if (fichier != null)
                {
                    //TODO : OK with Chrome, but filename returns teh full path in Microsoft Edge
                    var uniqueFileName = fichier.FileName;                  
                    var uploads = Path.Combine(_environment.WebRootPath, "images");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    fichier.CopyTo(new FileStream(filePath, FileMode.Create));

                    //update DB
                    Image image = new Image();
                    image.CheminAcces = uniqueFileName;
                    image.IdproduitNavigation = produit;
                    repoImage.InsertItem(image);
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            //list des couleurs pour la select list
            ViewBag.couleurs = new RepositoryTirelire<Couleur>(ctx).GetAll().Select(
                c => new SelectListItem { Text = c.Couleur1, Value = c.Idcouleur.ToString() }
                );

            //liste des fabricants pour al select list 
            ViewBag.fabricants = new RepositoryTirelire<Fabricant>(ctx).GetAll().Select(
                c => new SelectListItem { Text = c.Nom, Value = c.Idfabricant.ToString() }
                );
            return View(repoProduit.GetItem(id));
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produit produit)
        {
            try
            {
                repoProduit.UpdateItem(produit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repoProduit.GetItem(id));
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Produit produit)
        {
            try
            {
                repoProduit.DeleteItem(produit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
