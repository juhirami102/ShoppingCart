using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Domain;
using ShoppingCart.Service.Interfaces;

namespace ShoppingCart.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(int productId)
        {
            return _productRepository.GetProducts().Single(p => p.Id == productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public void RemoveProduct(int id)
        {
            _productRepository.RemoveProduct(id);
        }
    }
}
