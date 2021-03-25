using InveonWebUI.Business;
using InveonWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InveonWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger,IWebHostEnvironment webhostenviroment)
        {
            _webHostEnvironment = webhostenviroment;
            _logger = logger;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var token = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            List<Product> form = new ProductBusiness().GetProducts(token).Result;
            return View(form);
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var token = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            ProductViewModel form = new ProductBusiness().GetProductViewModel(new ProductViewModel { Id = id }, token).Result;
            return View(form);
        }

        [Authorize]
        public IActionResult EditSave(ProductViewModel productViewModel)
        {
            Product product = new Product() {
                Id = productViewModel.Id,
                ProductName = productViewModel.ProductName,
                ProductBarcode = productViewModel.ProductBarcode,
                ProductIsActive = true,
                ProductPrice = productViewModel.ProductPrice,
                ProductUnit = productViewModel.ProductUnit,
                ProductDescryption = productViewModel.ProductDescryption

            };
            if (productViewModel.ProductPhoto != null)
            {
                string folder = "Images/Product/";
                folder += Guid.NewGuid().ToString() + "_" + productViewModel.ProductPhoto.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                productViewModel.ProductPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                product.ProductImageUrl = '/' + folder;
            }
            else
            {
                product.ProductImageUrl = productViewModel.ProductImageUrl;
            }
            var token = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            Product edit = new ProductBusiness().EditProduct(product, token).Result;
            List<Product> form = new ProductBusiness().GetProducts(token).Result;
            return RedirectToAction("Index",form);
        }

        [Authorize]
        public IActionResult AddProduct()
        {
            return View();
        }

        [Authorize]
        public IActionResult Save(ProductViewModel productViewModel)
        {
            Product product = new Product()
            {
                ProductName = productViewModel.ProductName,
                ProductBarcode = productViewModel.ProductBarcode,
                ProductIsActive = true,
                ProductPrice = productViewModel.ProductPrice,
                ProductUnit = productViewModel.ProductUnit,
                ProductDescryption = productViewModel.ProductDescryption
            };

            if (productViewModel.ProductPhoto != null)
            {
                string folder = "Images/Product/";
                folder += Guid.NewGuid().ToString() + "_" + productViewModel.ProductPhoto.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                productViewModel.ProductPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                product.ProductImageUrl = '/' + folder;
            }
            else
            {
                product.ProductImageUrl = productViewModel.ProductImageUrl;
            }

            var token = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var add = new ProductBusiness().AddProduct(product, token).Result;
            List<Product> form = new ProductBusiness().GetProducts(token).Result;
            return View("Index", form);
        }

        [Authorize]
        public IActionResult DeleteProduct(int id)
        {
            var token = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var isOk = new ProductBusiness().DeleteProduct(new Product { Id=id},token).Result;
            List<Product> form = new ProductBusiness().GetProducts(token).Result;
            return View("Index",form);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
