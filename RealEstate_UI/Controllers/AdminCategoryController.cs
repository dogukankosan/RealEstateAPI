using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.CategoryDtos;
using System.Text;

namespace RealEstate_UI.Controllers
{
    [Route("AdminKategori")]
    public class AdminCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Liste")]
        public async Task<IActionResult> ListAsync()
        {
            //todo canlıya taşınınca değiştirilecek
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44312/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<ResultCategoryDto> values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
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
        public async Task<IActionResult> Add(CreateCategoryDto createCategoryDto)
        {  //todo canlıya taşınınca değiştirilecek
            createCategoryDto.CategoryStatus = Request.Form["CategoryStatus"] == "1" ? true : false;
            HttpClient client = _httpClientFactory.CreateClient();
            string jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:44312/api/Categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Liste", "AdminKategori", "");
            return View();
        }
        [Route("Sil/{id:int}")]
        public async Task<IActionResult> Delete(byte id)
        {  //todo canlıya taşınınca değiştirilecek
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:44312/api/Categories/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Liste", "AdminKategori", "");
            return RedirectToAction("Liste", "AdminKategori", "");
        }
        [HttpGet]
        [Route("Guncelle/{id:int}")]
        public async Task<IActionResult> Update(byte id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:44312/api/Categories/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                UpdateCategoryDto values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("Liste", "AdminKategori", "");
        }
        [HttpPost]
        [Route("Guncelle")]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {  //todo canlıya taşınınca değiştirilecek
            updateCategoryDto.CategoryStatus = Request.Form["CategoryStatus"] == "1" ? true : false;
            HttpClient client = _httpClientFactory.CreateClient();
            string jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:44312/api/Categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Liste", "AdminKategori", "");
            return View();
        }
    }
}