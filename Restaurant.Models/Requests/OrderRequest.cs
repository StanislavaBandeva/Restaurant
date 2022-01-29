using System;
using System.Collections.Generic;
namespace Restaurant.Models.Requests
{
    public class OrderRequest
    {
        public decimal TotalPrice { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? FinishedOn { get; set; }

        public List<int> Products { get; set; }
    }
}
