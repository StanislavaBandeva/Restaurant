using Restaurant.DL.InMemoryDb;
using Restaurant.DL.Interfaces;
using Restaurant.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.DL.Repositories
{
    public class TableRepository : ITableRepository
    {
        public Table Create(Table table)
        {
            TablesInMemoryCollection.TablesCollection.Add(table);

            return table;
        }

        public Table Delete(int id)
        {
            var tableFromDb = TablesInMemoryCollection.TablesCollection.FirstOrDefault(t => t.Id == id);

            if (tableFromDb != null)
            {
                TablesInMemoryCollection.TablesCollection.Remove(tableFromDb);
            }

            return tableFromDb;
        }

        public IEnumerable<Table> GetAll()
        {
            return TablesInMemoryCollection.TablesCollection;
        }

        public Table GetById(int id)
        {
            return TablesInMemoryCollection.TablesCollection.FirstOrDefault(t => t.Id == id);
        }

        public Table Update(Table table)
        {
            var tableFromDb = TablesInMemoryCollection.TablesCollection.FirstOrDefault(t => t.Id == table.Id);
           
            TablesInMemoryCollection.TablesCollection.Remove(tableFromDb);
            
            tableFromDb.Orders = table.Orders;

            TablesInMemoryCollection.TablesCollection.Add(tableFromDb);

            return tableFromDb;
        }
    }
}
