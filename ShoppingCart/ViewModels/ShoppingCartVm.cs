using System.Collections.Generic;

namespace ShoppingCart.Web.ViewModels
{
    public class ShoppingCartVm
    {
        public List<CartItemVm> CartItems { get; set; } = new List<CartItemVm>();
        public decimal TotalCost { get;set; }
    }
}
