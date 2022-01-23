using Restaurant.Models.DTO;
using System.Collections.Generic;

namespace Restaurant.DL.Interfaces
{
    public interface IOrderRepository
    {
        Order Create(Order order);

        Order Update(Order order);

        Order Delete(int id);

        Order GetById(int id);

        IEnumerable<Order> GetAll();
    }
}
