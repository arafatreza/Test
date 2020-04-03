using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyEShop.Data;
using PharmacyEShop.Models;

namespace PharmacyEShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductController(ApplicationDbContext dbContext,IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View(_dbContext.Products.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product,IFormFile image)
        {
            if(image!=null)
            {
                var name = Path.Combine(hostingEnvironment.WebRootPath + "/images", Path.GetFileName(image.FileName));
                await image.CopyToAsync(new FileStream(name, FileMode.Create));
                product.Image = "images/" + image.FileName;
            }
            _dbContext.Products.Add(product);
            bool isSaved = _dbContext.SaveChanges() > 0;
            if (isSaved)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }


    }
}