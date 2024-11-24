using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.Models;
using Restaurant.Utility;
using RestaurantApp.ViewModels;

namespace RetsurantBookingAppFront.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TablesController : Controller
    {

        private readonly HttpClient _httpClient;

        public TablesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7232/api/Table/");
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> GetAllTables()
        {
            var response = await _httpClient.GetAsync("GetAllTables");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<List<TablesVM>>>(data);
                return Json(serviceResponse.Success ? new { data = serviceResponse.Data } : new { data = new List<TablesVM>(), error = serviceResponse.Message });
            }

            return Json(new { data = new List<TablesVM>(), error = "Unable to retrieve Tables from the server." });
        }

    }
}