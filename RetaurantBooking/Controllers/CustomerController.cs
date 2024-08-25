using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Access.Repository.Services.IServices;
using Restaurant.Models.DTOs;
using Restaurant.Utility;

namespace RetaurantBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        [Route("GetSingleCustomer")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var result = await _customerService.GetSingleAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerService.GetAllAsync();

            if (!result.Success )
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }


        [HttpPost]
        [Route("CreateCustomer")]

        public async Task<IActionResult> CreateNweCustomer([FromQuery] CustomerDto customer)
        {
      
            var response = await _customerService.AddItemAsync(customer);


            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);

          
            
            
            
            
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> Update([FromQuery] CustomerDto customer)
        {

            var result = await _customerService.UpdateCustomerAsync(customer);

            if (!result.Success)
            {

                return NotFound(result.Message);
            }
           

            return Ok(result.Message);
        }

        [HttpDelete]
        [Route("DeleteCustomer")]

        public async Task<IActionResult> DeleteUser(int id)

        {

           var result= await _customerService.RemoveAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);

        }
    }

}
