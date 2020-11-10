using System.Collections.Generic;
using ShoppingCart.Domain;

namespace ShoppingCart.Data.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void RemoveProduct(int id);
    }
}