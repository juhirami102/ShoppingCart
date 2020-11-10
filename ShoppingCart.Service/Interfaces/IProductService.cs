using System.Collections.Generic;
using ShoppingCart.Domain;

namespace ShoppingCart.Service.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        void RemoveProduct(int id);
        Product GetProduct(int productId);
    }
}