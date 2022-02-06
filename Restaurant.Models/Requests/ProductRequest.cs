using Restaurant.Models.Enums;

namespace Restaurant.Models.Requests
{
    public class ProductRequest
    {
        public decimal Price { get; set; }

        public ProductType Name { get; set; }
    }
}
