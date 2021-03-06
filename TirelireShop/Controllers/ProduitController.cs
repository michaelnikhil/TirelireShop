﻿using System;
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
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace TirelireShop.Controllers
{
    
    public class ProduitController : Controller
    {

        private IRepository<Produit> repoProduit;
        private IRepository<Image> repoImage;
        private IRepository<Client> repoClient;
        private DBTirelireShopContext ctx;
        private IWebHostEnvironment _environment;
        private UserManager<IdentityUser> _userManager;


        public ProduitController(IWebHostEnvironment environment, UserManager<IdentityUser> userManager)
        {
            ctx = new DBTirelireShopContext();
            repoProduit = new RepositoryTirelire<Produit>(ctx);
            repoImage = new RepositoryTirelire<Image>(ctx);
            repoClient = new RepositoryTirelire<Client>(ctx);
            _userManager = userManager;
            _environment = environment;
        }

        // GET: ProduitController
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(repoProduit.GetAll());
        }

        // GET: ProduitController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View(repoProduit.GetItem(id));
        }

        // GET: ProduitController/Create
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            return View(repoProduit.GetItem(id));
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
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

        [HttpPost]
        public ActionResult AddToCart(int id, int qte)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //check if client is associated to user
                    string IdClient = HttpContext.Session.GetString("IdClient");

                    if (IdClient != null) 
                    {
                        if (HttpContext.Session.GetString("panier") == null) //check if shopping cart exists
                        {
                            Commande panier = new Commande();
                            panier.Idclient = int.Parse(IdClient);
                            panier.Date = DateTime.Now;
                            panier.IdstatutCommande = 1; //statut1 = commande preparee
                            panier.DetailsCommande = new List<DetailsCommande>();
                            string str_panier = JsonConvert.SerializeObject(panier);
                            HttpContext.Session.SetString("panier", str_panier);
                        }
                        Commande panier_courant = JsonConvert.DeserializeObject<Commande>(HttpContext.Session.GetString("panier"));

                        //create a new detailCommande and associate to commande
                        //test si detail commande existe
                        DetailsCommande detail = panier_courant.DetailsCommande.Where(d => d.Idproduit == id).FirstOrDefault();
                        if (detail == null)
                        {
                            detail = new DetailsCommande() { Idproduit=id, Quantite=qte, Prix= repoProduit.GetItem(id).Prix};
                            panier_courant.DetailsCommande.Add(detail);
                        }
                        else
                        {
                            detail.Quantite += qte;
                        }

                        string str_panier_courant = JsonConvert.SerializeObject(panier_courant);
                        HttpContext.Session.SetString("panier", str_panier_courant);
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return RedirectToAction("Index", "Panier"); 
 
        }
    }
}
