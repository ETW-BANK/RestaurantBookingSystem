using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Access.Repository.Services.IServices;
using Restaurant.Models.DTOs;

namespace RetaurantBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceRepository _customerService;
        public CustomerController(ICustomerServiceRepository customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        [Route("GetOneUser")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customerDto = await _customerService.GetSingleAsync(id);
            if (customerDto == null)
            {
                return NotFound("user Dosnt Exist");
            }
            return Ok(customerDto);
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customerDto = await _customerService.GetAllAsync();
            if (customerDto == null)
            {
                return NotFound("No Customer Found");
            }
            return Ok(customerDto);
        }


        [HttpPost]
        [Route("Create Customer")]

        public async Task<IActionResult> CreateNweCustomer([FromQuery] CustomerDto customer)
        {
            await _customerService.AddItemAsync(customer);
            
            return Ok("user Created Succesfully");
        }

        [HttpPut]
        [Route("UpdateUser")]

        public async Task<IActionResult> Update([FromQuery] CustomerDto customer)

        {

            var result=await _customerService.GetSingleAsync(customer.Id);   

          if (result== null)
            {
                return NotFound("Customer Not Found");
            }

             await _customerService.UpdateCustomerAsync(customer);
            

            return Ok("Customer Updated SuccessFully");

        }

        [HttpDelete]
        [Route("DeleteCustomer")]

        public async Task<IActionResult> DeleteUser(int id)

        {

            await _customerService.RemoveAsync(id); 


            return Ok("User Deleted Successfully");

        }
    }

}
