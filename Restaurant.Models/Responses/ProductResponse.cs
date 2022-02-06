using Restaurant.Models.Enums;

namespace Restaurant.Models.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public ProductType Name { get; set; }
    }
}
