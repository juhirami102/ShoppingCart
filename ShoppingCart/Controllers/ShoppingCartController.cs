using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Service.Interfaces;
using ShoppingCart.Web.ViewModels;

namespace ShoppingCart.Web.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IDiscountCodeService _discountCodeService;
        private readonly ICartService _cartService;

        public ShoppingCartController(IProductService productService, IDiscountCodeService discountCodeService, ICartService cartService)
        {
            _productService = productService;
            _discountCodeService = discountCodeService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {          
            var vm = new ShoppingCartVm();
            
            List<CartItemVm> items = new List<CartItemVm>();
            foreach (var cartItem in _cartService.GetCartItems(GetSessionId()))
            {
                var product = _productService.GetProduct(cartItem.ProductId);
                items.Add(new CartItemVm
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost.ToString("C"),
                    customcost = product.Cost
                    
                });
                
            }
            vm.CartItems = items;
            vm.TotalCost =(items.Sum(x => x.customcost));
            ViewBag.Totalct = vm.TotalCost;
            return View(vm);
        }
       
        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            _cartService.AddCartItem(GetSessionId(), productId);
            return RedirectToAction("Index", "ShoppingCart");
        }
        
        
        public IActionResult RemoveItem(int id)
        {
            _cartService.RemoveCartItem(GetSessionId(), id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult CheckDiscountCode(string code,decimal Tcost)
        {
            var discountCode = _discountCodeService.GetByCode(code);
            if (discountCode == null)
            {
                return new JsonResult(new { valid = false, TotalCost = Tcost });
            }

            var isValid = !discountCode.IsUsed && DateTime.Now < discountCode.Expiry;

            if (isValid)
            {
                Tcost = Tcost - discountCode.Value;
                return new JsonResult(new { valid = true, discount = discountCode.Value, TotalCost = Tcost });
            }

            return new JsonResult(new { valid = false , TotalCost = Tcost });
        }
    }
}