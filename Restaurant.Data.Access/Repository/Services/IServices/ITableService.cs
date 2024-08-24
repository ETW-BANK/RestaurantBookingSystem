using Restaurant.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository.Services.IServices
{
   public interface ITableService
    {
        Task AddItemAsync(TablesDto item);
        Task<TablesDto> GetSingleAsync(int id);
        Task<IEnumerable<TablesDto>> GetAllAsync();
        Task RemoveAsync(int id);
        Task UpdateTableAsync(TablesDto table);
    }
}
