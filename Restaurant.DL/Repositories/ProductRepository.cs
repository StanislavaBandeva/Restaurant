using Restaurant.DL.InMemoryDb;
using Restaurant.DL.Interfaces;
using Restaurant.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.DL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product Create(Product product)
        {
            ProductsInMemoryCollection.ProductsCollection.Add(product);

            return product;
        }

        public Product Delete(int id)
        {
            var productFromDb = ProductsInMemoryCollection.ProductsCollection.FirstOrDefault(p => p.Id == id);

            if (productFromDb != null)
            {
                ProductsInMemoryCollection.ProductsCollection.Remove(productFromDb);
            }

            return productFromDb;
        }

        public IEnumerable<Product> GetAll()
        {
            return ProductsInMemoryCollection.ProductsCollection;
        }

        public Product GetById(int id)
        {
            return ProductsInMemoryCollection.ProductsCollection.FirstOrDefault(p => p.Id == id);
        }

        public Product Update(Product product)
        {
            var productFromDb = ProductsInMemoryCollection.ProductsCollection.FirstOrDefault(p => p.Id == product.Id);

            ProductsInMemoryCollection.ProductsCollection.Remove(productFromDb);

            productFromDb.Price = product.Price;
            productFromDb.Name = product.Name;

            ProductsInMemoryCollection.ProductsCollection.Add(productFromDb);

            return productFromDb;
        }
    }
}
