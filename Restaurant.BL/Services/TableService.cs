using Restaurant.BL.Interfaces;
using Restaurant.DL.Interfaces;
using Restaurant.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.BL.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public Table Create(Table table)
        {
            var index = _tableRepository.GetAll()?.OrderByDescending(t => t.Id).FirstOrDefault()?.Id;

            table.Id = (int)(index != null ? index + 1 : 1);

            return _tableRepository.Create(table);
        }

        public Table Delete(int id)
        {
            return _tableRepository.Delete(id);
        }

        public IEnumerable<Table> GetAll()
        {
            return _tableRepository.GetAll();
        }

        public Table GetById(int id)
        {
            return _tableRepository.GetById(id);
        }

        public Table Update(Table table)
        {
            return _tableRepository.Update(table);
        }
    }
}
