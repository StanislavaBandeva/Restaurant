using System.Collections.Generic;

namespace Restaurant.Models.Responses
{
    public class TableResponse
    {
        public int Id { get; set; }

        public List<int> Orders { get; set; }
    }
}
