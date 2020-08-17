using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using TirelireShop.DataAccess;
using TirelireShop.Models;
using TirelireShop.Repository;


namespace TirelireShop.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Produit> repoProduit;
        private DBTirelireShopContext ctx;
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _environment;


        public HomeController(  ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            ctx = new DBTirelireShopContext();
            repoProduit = new RepositoryTirelire<Produit>(ctx);
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            string imagePath = _environment.WebRootPath + "\\images\\";
            ViewBag.imagePath = imagePath;

            return View(repoProduit.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //TODO pour plusieurs images
        public IActionResult GetImage(int id)
        {
            Produit requestedProduit = repoProduit.GetItem(id);
            if (requestedProduit != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";

                string im = requestedProduit.Image.OrderByDescending(i => i.CheminAcces).Select(i => i.CheminAcces).SingleOrDefault();

                string fullPath = webRootpath + folderPath + im;

                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    //get content type    
                    var provider = new FileExtensionContentTypeProvider();
                    string contentType;
                    if (!provider.TryGetContentType(fullPath, out contentType))
                    {
                        contentType = "application/octet-stream";
                    }
                    return File(fileBytes, contentType);
                }
                else
                    return NotFound();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
