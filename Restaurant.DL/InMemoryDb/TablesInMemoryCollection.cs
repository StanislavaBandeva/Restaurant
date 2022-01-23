using Restaurant.Models.DTO;
using System.Collections.Generic;

namespace Restaurant.DL.InMemoryDb
{
    public static class TablesInMemoryCollection
    {
        public static List<Table> TablesCollection = new List<Table>
        {
            new Table
            {
                Id = 1,
                Orders = new List<int>
                {
                    1,
                    2
                }
            }
        };
    }
}
