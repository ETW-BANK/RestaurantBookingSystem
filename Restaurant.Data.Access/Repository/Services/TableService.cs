using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Data.Access.Repository.Services.IServices;
using Restaurant.Models;
using Restaurant.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository.Services
{
    public class TableService : ITableService

    {
        private readonly ITableRepository _tablerepo;

        public TableService(ITableRepository tablerepo)
        {
            _tablerepo = tablerepo;
        }
        public async Task AddItemAsync(TablesDto item)
        {
            var table = new Tables
            {
                Id = item.Id,
                NumberOfSeats = item.NumberOfSeats,
                TableNumber = item.TableNumber,
                isAvialable=item.isAvialable,


            };
            await _tablerepo.AddItemAsync(table);
            await _tablerepo.SaveAsync();
        }

        public async Task<IEnumerable<TablesDto>> GetAllAsync()
        {
             var tableList=await _tablerepo.GetAllAsync();  

             if (tableList != null)
             {
                return tableList.Select(x => new TablesDto

                {
                    Id = x.Id,
                    TableNumber = x.TableNumber,
                    NumberOfSeats= x.NumberOfSeats,
                    isAvialable= x.isAvialable
                }).ToList();

                
            }
            return new List<TablesDto>();

        }

        public async Task<TablesDto> GetSingleAsync(int id)
        {
         var table= await _tablerepo.GetSingleAsync(id);    

            if (table != null)
            {
                return new TablesDto
                {
                    Id = table.Id,
                    TableNumber= table.TableNumber,
                    NumberOfSeats= table.NumberOfSeats,
                    isAvialable = table.isAvialable

                };
               
            }
            return null;
        }

        public async Task RemoveAsync(int id)
        {
            var result = await _tablerepo.GetSingleAsync(id);

            if(result != null)
            {
             await _tablerepo.RemoveAsync(id);
            }
            await _tablerepo.SaveAsync();
        }

        public async Task UpdateTableAsync(TablesDto table)
        {
            Tables existingtable = await _tablerepo.GetSingleAsync(table.Id);

            if (existingtable != null)
            {
                existingtable.TableNumber = table.TableNumber;
                existingtable.NumberOfSeats = table.NumberOfSeats;  
                existingtable.isAvialable= table.isAvialable;   
            }

           await _tablerepo.UpdateTableAsync(existingtable);

        }
    }
}
