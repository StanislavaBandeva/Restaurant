using Restaurant.Models.DTO;
using System.Collections.Generic;

namespace Restaurant.DL.Interfaces
{
    public interface ITableRepository
    {
        Table Create(Table table);

        Table Update(Table table);

        Table Delete(int id);

        Table GetById(int id);

        IEnumerable<Table> GetAll();
    }
}
