using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Service.Interfaces;
using ShoppingCart.Web.ViewModels;

namespace ShoppingCart.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetProducts().Select(p => new ProductVm
            {
                Id = p.Id,
                Cost = p.Cost,                
                Name = p.Name,
                StockLevel = p.StockLevel
            }).ToList();
            return View(products);
        }
    }
}