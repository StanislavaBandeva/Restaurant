using System.Collections.Generic;

namespace Restaurant.Models.DTO
{
    public class Table
    {
        public int Id { get; set; }

        public List<int> Orders { get; set; }
    }
}
