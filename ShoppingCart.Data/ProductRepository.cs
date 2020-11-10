using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Domain;

namespace ShoppingCart.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Cost = 12m,
                    StockLevel = 5
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Cost = 10.50m,
                    StockLevel = 8
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    Cost = 5.50m,
                    StockLevel = 20
                },
                new Product
                {
                    Id = 4,
                    Name = "Product 4",
                    Cost = 2m,
                    StockLevel = 5
                },
                new Product
                {
                    Id = 5,
                    Name = "Product 5",
                    Cost = 5m,
                    StockLevel = 1
                }
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public void RemoveProduct(int id)
        {
            var productToRemove = _products.Single(x => x.Id == id);
            _products.Remove(productToRemove);
        }
    }
}
