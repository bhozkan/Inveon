using InveonService.Business;
using InveonService.DbContexts;
using InveonService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InveonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly InveonContext inveonContext;
        private readonly HttpContext hcontext;
        readonly User user;
        object response;
        private readonly ProductBusiness productBusiness;


        public ProductController(IHttpContextAccessor haccess, InveonContext _inveonContext)
        {
            inveonContext = _inveonContext;
            hcontext = haccess.HttpContext;
            user = ClaimIdentityBusiness.GetUser(hcontext.User);
            productBusiness = new ProductBusiness(inveonContext);
        }

        [HttpGet("Products")]
        public IActionResult Products() 
        {
            return new JsonResult(productBusiness.GetProducts());
        }

        [HttpPost("Product")]
        public IActionResult Product(Product product)
        {
            return new JsonResult(productBusiness.GetProduct(product));
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product product)
        {
            return new JsonResult(productBusiness.AddProduct(product));
        }
        
        [HttpPost("EditProduct")]
        public IActionResult EditProduct(Product product)
        {
            return new JsonResult(productBusiness.EditProduct(product));
        }
        
        [HttpPost("DeleteProduct")]
        public IActionResult DeleteProduct(Product product)
        {
            return new JsonResult(productBusiness.DeleteProduct(product));
        }


    }
}
