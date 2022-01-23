using Restaurant.Models.DTO;
using System.Collections.Generic;

namespace Restaurant.BL.Interfaces
{
    public interface IProductService
    {
        Product Create(Product product);

        Product Update(Product product);

        Product Delete(int id);

        Product GetById(int id);

        IEnumerable<Product> GetAll();
    }
}
