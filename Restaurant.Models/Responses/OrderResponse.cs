using System;
using System.Collections.Generic;

namespace Restaurant.Models.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? FinishedOn { get; set; }

        public List<int> Products { get; set; }
    }
}
