using Restaurant.Data.Access.Data;
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
    public class CustomerService : ICustomerService

    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepo = customerRepository;
        }

        public async Task AddItemAsync(CustomerDto item)
        {
            var customer = new Customer
            {
                FirstName = item.FirstName,
                LasttName = item.LasttName,
                Email = item.Email,
                Phone = item.Phone
            };

            await _customerRepo.AddItemAsync(customer);
            await _customerRepo.SaveAsync();
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerRepo.GetAllAsync();
            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LasttName = c.LasttName,
                Email = c.Email,
                Phone = c.Phone
            }).ToList();
        }
    

        public async Task<CustomerDto> GetSingleAsync(int id)
        {
            var customer = await _customerRepo.GetSingleAsync(id);
            if (customer != null)
            {
                return new CustomerDto
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LasttName = customer.LasttName,
                    Email = customer.Email,
                    Phone = customer.Phone
                };
            }
            return null;
        }

        public async Task RemoveAsync(int id)
        {
            Customer customeer=await _customerRepo.GetSingleAsync(id);

            if (customeer != null)
            {
                await _customerRepo.RemoveAsync(id);
            }
        
            await _customerRepo.SaveAsync();
        }

        public async Task UpdateCustomerAsync(CustomerDto customer)
        {
          Customer existingcustomer= await _customerRepo.GetSingleAsync(customer.Id);   

            if (existingcustomer != null)
            {
                existingcustomer.FirstName = customer.FirstName;    
                existingcustomer.LasttName = customer.LasttName;    
                existingcustomer.Email = customer.Email;
                existingcustomer.Phone = customer.Phone;

                await _customerRepo.UpdateCustomerAsync(existingcustomer);
            }
        }
    }
    }
    

