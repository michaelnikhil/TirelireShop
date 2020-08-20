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
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

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

        public async Task<IActionResult> AddToCart(int id)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {

                    //retrieve user email and compare to Client table
                    Claim claim = User.Claims.ToList().FirstOrDefault();
                    string id_user = claim.Value;
                    IdentityUser user = await _userManager.FindByIdAsync(id_user);
                    string user_email = user.Email;

                    int? IdClient = repoClient.GetAll()
                        .Where(c => c.Email == user_email)
                        .Select(c => c.Idclient).FirstOrDefault();

                    if (IdClient != null) //check if client is associated to user
                    {
                        if (HttpContext.Session.GetString("panier") == null) //check if shopping cart exists
                        {
                            Commande panier = new Commande();
                            panier.Idclient = (int) IdClient;
                            panier.Date = DateTime.Now;
                            panier.IdstatutCommande = 1; //statut1 = commande preparee
                            string str_panier = JsonConvert.SerializeObject(panier);
                            HttpContext.Session.SetString("panier", str_panier);
                        }
                        Commande panier_courant = JsonConvert.DeserializeObject<Commande>(HttpContext.Session.GetString("panier"));

                        DetailsCommande detail = new DetailsCommande();
                        detail.Idproduit = id;
                        detail.Quantite = 1;
                        detail.Prix = repoProduit.GetItem(id).Prix;

                        panier_courant.DetailsCommande.Add(detail);
                        
                        string str_panier_courant = JsonConvert.SerializeObject(panier_courant);
                        HttpContext.Session.SetString("panier", str_panier_courant);


                        //string strDDLValue = form["ddlVendor"].ToString();



                        //ajouter les proprietes details commandes..
                        //ne renseigner que les ids, pas l'objet

                        //panier courant avec details commande ou pas ? incrementer selon la quantite ? 
                        //resialiser en json pour remettre dans le tableau de session



                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account", new { area = "" });
                }
            }

            return RedirectToAction("Index", "Home", new { area = "" }); 
        }





                    private void PopulateProductsList(List<int> Id = null)
        {
            var products = from p in repoProduit.GetAll()
                           orderby p.Nom
                           select p.Nom;

            ViewBag.ProductsList = new MultiSelectList(products);
        }


    }
}
