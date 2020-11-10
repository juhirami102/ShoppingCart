using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Domain;
using ShoppingCart.Service.Interfaces;

namespace ShoppingCart.Service
{
    public class CartService : ICartService
    {
        private readonly Dictionary<string, List<CartItem>> _cartRepository = new Dictionary<string, List<CartItem>>();
            
        
        public void AddCartItem(string sessionId, int productId)
        {
            var session = GetSessionCart(sessionId);

            if (session.All(x => x.ProductId != productId))
                session.Add(new CartItem{ProductId = productId});
        }

        public IEnumerable<CartItem> GetCartItems(string sessionId)
        {
            return GetSessionCart(sessionId);
        }

        public void RemoveCartItem(string sessionId, int productId)
        {
            CartItem obj = new CartItem();
            var session = GetSessionCart(sessionId);
            
            var item = (from i in session
                        where i.ProductId != productId
                        select i).ToList();

            List<CartItem> objlist = new List<CartItem>();
            //objlist = item as (List<CartItem>);
            if (_cartRepository.ContainsKey(sessionId))
                _cartRepository.Remove(sessionId);

            if (!_cartRepository.ContainsKey(sessionId))
                _cartRepository.Add(sessionId, item);


            //throw new NotImplementedException();
        }
        
        private List<CartItem> GetSessionCart(string sessionId)
        {
            if (!_cartRepository.ContainsKey(sessionId))
                _cartRepository.Add(sessionId, new List<CartItem>());

            return _cartRepository[sessionId];
        }
    }
}
