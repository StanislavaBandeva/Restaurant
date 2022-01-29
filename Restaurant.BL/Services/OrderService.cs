using Restaurant.BL.Interfaces;
using Restaurant.DL.Interfaces;
using Restaurant.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Create(Order order)
        {
            var index = _orderRepository.GetAll()?.OrderByDescending(o => o.Id).FirstOrDefault()?.Id;

            order.Id = (int)(index != null ? index + 1 : 1);

            return _orderRepository.Create(order);
        }

        public Order Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public Order Update(Order order)
        {
            return _orderRepository.Update(order);
        }
    }
}
