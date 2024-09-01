using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.CategoryDtos;
using RealEstate_UI.Dtos.ProductDtos;
using System.Text;

namespace RealEstate_UI.Controllers
{
    [Route("AdminIlanlar")]
    public class AdminProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Liste")]
        public async Task<IActionResult> List()
        {//todo burası değişecek canlıda
            HttpClient client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44312/api/Products/GetByCategoryIDProduct");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<ResultProductDto> values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("Ekle")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44312/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<ResultCategoryDto> values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                List<SelectListItem> categories = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text=x.CategoryName,
                                                       Value=x.CategoryID.ToString()
                                                   }).ToList();
                ViewBag.Categories = categories;    
                return View();
            }
            return View();
        }
        [Route("Ekle")]
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDto createProductDto)
        {//todo canlıya taşınınca değiştirilecek
            createProductDto.ProductStatus = Request.Form["ProductStatus"] == "1" ? true : false;
            HttpClient client = _httpClientFactory.CreateClient();
            string jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:44312/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Liste", "AdminIlanlar", "");
            return View();
        }
    }
}