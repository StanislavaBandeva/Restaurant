using Restaurant.Models.DTO;
using System.Collections.Generic;

namespace Restaurant.DL.Interfaces
{
    public interface IProductRepository
    {
        Product Create(Product product);

        Product Update(Product product);

        Product Delete(int id);

        Product GetById(int id);

        IEnumerable<Product> GetAll();
    }
}
