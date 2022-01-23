using Restaurant.DL.InMemoryDb;
using Restaurant.DL.Interfaces;
using Restaurant.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.DL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Order Create(Order order)
        {
            OrdersInMemoryCollection.OrdersCollection.Add(order);

            return order;
        }

        public Order Delete(int id)
        {
            var orderFromDb = OrdersInMemoryCollection.OrdersCollection.FirstOrDefault(o => o.Id == id);

            if (orderFromDb != null)
            {
                OrdersInMemoryCollection.OrdersCollection.Remove(orderFromDb);
            }

            return orderFromDb;
        }

        public IEnumerable<Order> GetAll()
        {
            return OrdersInMemoryCollection.OrdersCollection;
        }

        public Order GetById(int id)
        {
            return OrdersInMemoryCollection.OrdersCollection.FirstOrDefault(o => o.Id == id);
        }

        public Order Update(Order order)
        {
            var orderFromDb = OrdersInMemoryCollection.OrdersCollection.FirstOrDefault(o => o.Id == order.Id);

            OrdersInMemoryCollection.OrdersCollection.Remove(orderFromDb);

            orderFromDb.CreatedOn = order.CreatedOn;
            orderFromDb.FinishedOn = order.FinishedOn;
            orderFromDb.TotalPrice = order.TotalPrice;
            orderFromDb.Products = order.Products;

            OrdersInMemoryCollection.OrdersCollection.Add(orderFromDb);

            return orderFromDb;
        }
    }
}
