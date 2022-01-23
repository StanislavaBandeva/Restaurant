using Restaurant.Models.Enums;

namespace Restaurant.Models.DTO
{
    public class Product
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public ProductType Name { get; set; }
    }
}
