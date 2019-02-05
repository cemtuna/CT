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

    //[Authorize(Policy = "RequireProductAccess")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Policy = "AccessPolicy")]
        public IActionResult Index()
        {
            //var products = _productService.GetProductListStarsWith("A");
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(ProductAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(model.Product);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ProductUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(model.Product);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}