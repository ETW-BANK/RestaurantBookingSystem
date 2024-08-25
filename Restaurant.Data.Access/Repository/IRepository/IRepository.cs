using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task AddItemAsync(T item);

        Task <T> GetSingleAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllBookingAsync(params Expression<Func<T, object>>[] includes);
        Task RemoveAsync(int id);
      
        Task SaveAsync();
    }
}
