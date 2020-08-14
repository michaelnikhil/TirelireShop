﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

        //TODO implementer image MimeType et photofile
        public IActionResult GetImage(int id)
        {
            Produit requestedProduit = repoProduit.GetItem(id);
            if (requestedProduit != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedProduit.Idimage;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, "image/png");
                }
                else
                    return NotFound();
                /*
                {
                    if (requestedProduit.PhotoFile.Length > 0)
                    {
                        return File(requestedProduit.PhotoFile, "image/png");
                    }
                    else
                    {
                        return NotFound();
                    }
                }*/
            }
            else
            {
                return NotFound();
            }
        }




    }
}
