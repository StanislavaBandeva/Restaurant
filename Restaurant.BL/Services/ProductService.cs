using Restaurant.BL.Interfaces;
using Restaurant.DL.Interfaces;
using Restaurant.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Create(Product product)
        {
            var index = _productRepository.GetAll()?.OrderByDescending(p => p.Id).FirstOrDefault()?.Id;

            product.Id = (int)(index != null ? index + 1 : 1);

            return _productRepository.Create(product);
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product Update(Product product)
        {
            return _productRepository.Update(product);
        }
    }
}
