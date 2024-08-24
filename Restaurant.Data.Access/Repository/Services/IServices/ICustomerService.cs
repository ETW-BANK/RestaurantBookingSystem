using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Models;
using Restaurant.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository.Services.IServices
{
    public interface ICustomerService
    {

        Task AddItemAsync(CustomerDto item);
        Task<CustomerDto> GetSingleAsync(int id);
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task RemoveAsync(int id);
        Task UpdateCustomerAsync(CustomerDto customer);

    }
}
