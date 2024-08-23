using Restaurant.Data.Access.Repository.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository.IRepository
{
    public interface IUnitOfWork
    {

        public ICustomerRepository Customer { get; }

        public ICustomerServiceRepository CustomerService { get; }
       
    }
}
