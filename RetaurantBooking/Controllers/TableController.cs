using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Access.Repository.Services.IServices;
using Restaurant.Models.DTOs;

namespace RetaurantBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }


        [HttpGet]
        [Route("GetOneTable")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var tableDto = await _tableService.GetSingleAsync(id);
            if (tableDto == null)
            {
                return NotFound("user Dosn't Exist");
            }
            return Ok(tableDto);
        }

        [HttpGet]
        [Route("GetAllTables")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var tableDto = await _tableService.GetAllAsync();
            if (tableDto == null)
            {
                return NotFound("No Customer Found");
            }
            return Ok(tableDto);
        }


        [HttpPost]
        [Route("Create Table")]

        public async Task<IActionResult> CreateNweCustomer([FromQuery] TablesDto table)
        {
            await _tableService.AddItemAsync(table);
            
            return Ok("Table Created Succesfully");
        }

        [HttpPut]
        [Route("UpdateTable")]

        public async Task<IActionResult> Update([FromQuery] TablesDto table)

        {

            var result=await _tableService.GetSingleAsync(table.Id);   

          if (result== null)
            {
                return NotFound("Table Not Found");
            }

             await _tableService.UpdateTableAsync(table);
            

            return Ok("Table Updated SuccessFully");

        }

        [HttpDelete]
        [Route("DeleteTable")]

        public async Task<IActionResult> DeleteTable(int id)

        {

            await _tableService.RemoveAsync(id); 


            return Ok("Table Deleted Successfully");

        }
    }

}
