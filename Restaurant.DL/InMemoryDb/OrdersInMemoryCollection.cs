using Restaurant.Models.DTO;
using System;
using System.Collections.Generic;

namespace Restaurant.DL.InMemoryDb
{
    public static class OrdersInMemoryCollection
    {
        public static List<Order> OrdersCollection = new List<Order>
        {
            new Order
            {
                Id = 1,
                CreatedOn = DateTime.Now,
                FinishedOn = DateTime.Now.AddHours(2),
                Products = new List<int>
                {
                    1,
                    2,
                    3
                }
            },
            new Order
            {
                Id = 2,
                CreatedOn = DateTime.Now,
                Products = new List<int>
                {
                    4,
                    5
                }
            }
        };
    }
}
