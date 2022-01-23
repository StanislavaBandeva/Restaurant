using Restaurant.Models.DTO;
using Restaurant.Models.Enums;
using System.Collections.Generic;

namespace Restaurant.DL.InMemoryDb
{
    public static class ProductsInMemoryCollection
    {
        public static List<Product> ProductsCollection = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 2.99m,
            },
            new Product
            {
                Id = 2,
                Name = ProductType.Pasta,
                Price = 21.80m,
            },
            new Product
            {
                Id = 3,
                Name = ProductType.Pizza,
                Price = 14.24m,
            },
            new Product
            {
                Id = 4,
                Name = ProductType.OrangeJuice,
                Price = 5.23m,
            },
            new Product
            {
                Id = 5,
                Name = ProductType.Cake,
                Price = 56.55m,
            },
        };
    }
}
