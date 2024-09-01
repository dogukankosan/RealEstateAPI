using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.EmployeeDtos;
using System.Text;

namespace RealEstate_UI.Controllers
{
    [Route("AdminEmlakci")]
    public class AdminEmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminEmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Liste")]
        [HttpGet]
        public async Task<IActionResult> List()
        {//todo canlıya taşınınca değiştirilecek
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44312/api/Employees");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<ResultEmployeeDto> values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("Ekle")]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [Route("Ekle")]
        public async Task<IActionResult> Add(CreateEmployeeDto createEmployeeDto)
        {  //todo canlıya taşınınca değiştirilecek
            createEmployeeDto.EmployeeStatus = Request.Form["EmployeeStatus"] == "1" ? true : false;
            HttpClient client = _httpClientFactory.CreateClient();
            string jsonData = JsonConvert.SerializeObject(createEmployeeDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:44312/api/Employees", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Liste", "AdminEmlakci", "");
            return View();
        }
        [Route("Sil/{id:int}")]
        public async Task<IActionResult> Delete(byte id)
        {  //todo canlıya taşınınca değiştirilecek
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:44312/api/Employees/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Liste", "AdminEmlakci", "");
            return RedirectToAction("Liste", "AdminEmlakci", "");
        }
        [HttpGet]
        [Route("Guncelle/{id:int}")]
        public async Task<IActionResult> Update(byte id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:44312/api/Employees/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                UpdateEmployeeDto values = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("Liste", "AdminEmlakci", "");
        }
        [HttpPost]
        [Route("Guncelle")]
        public async Task<IActionResult> Update(UpdateEmployeeDto updateEmployeeDto)
        {  //todo canlıya taşınınca değiştirilecek
            updateEmployeeDto.EmployeeStatus = Request.Form["EmployeeStatus"] == "1" ? true : false;
            HttpClient client = _httpClientFactory.CreateClient();
            string jsonData = JsonConvert.SerializeObject(updateEmployeeDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:44312/api/Employees", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Liste", "AdminEmlakci", "");
            return View();
        }
    }
}