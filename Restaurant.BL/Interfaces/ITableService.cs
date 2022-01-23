using Restaurant.Models.DTO;
using System.Collections.Generic;

namespace Restaurant.BL.Interfaces
{
    public interface ITableService
    {
        Table Create(Table table);

        Table Update(Table table);

        Table Delete(int id);

        Table GetById(int id);

        IEnumerable<Table> GetAll();
    }
}
