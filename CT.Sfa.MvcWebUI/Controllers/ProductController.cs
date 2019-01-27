using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT.Sfa.Business.Abstract;
using CT.Sfa.Entities.Concrete;
using CT.Sfa.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CT.Sfa.MvcWebUI.Controllers
{
    
    [Authorize(Policy = "RequireProductAccess")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            //var products = _productService.GetProductListStarsWith("A");
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }
    }
}