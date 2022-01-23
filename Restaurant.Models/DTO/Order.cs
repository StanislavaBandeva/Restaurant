using System;
using System.Collections.Generic;

namespace Restaurant.Models.DTO
{
    public class Order
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? FinishedOn { get; set; }

        public List<int> Products { get; set; }
    }
}
