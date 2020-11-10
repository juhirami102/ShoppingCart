using System.Collections.Generic;
using ShoppingCart.Domain;

namespace ShoppingCart.Service.Interfaces
{
    public interface ICartService
    {
        IEnumerable<CartItem> GetCartItems(string sessionId);
        void RemoveCartItem(string sessionId, int productId);
        void AddCartItem(string sessionId, int productId);
    }
}