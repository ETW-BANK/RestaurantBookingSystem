using Restaurant.Data.Access.Data;
using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Data.Access.Repository.Services;
using Restaurant.Data.Access.Repository.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly RestaurantDbContext _context;
        public ICustomerRepository Customer { get; private set; }

        public ICustomerServiceRepository CustomerService { get; private set; }


        public UnitOfWork(RestaurantDbContext context)
        {
            _context = context;

            Customer=new CustomerRepository(_context);
            CustomerService=new CustomerServiceRepository(Customer);     
        

            
        }
    }
}
