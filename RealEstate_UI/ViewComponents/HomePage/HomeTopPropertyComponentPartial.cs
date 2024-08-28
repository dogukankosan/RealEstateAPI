using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.ProductDtos;

namespace RealEstate_UI.ViewComponents.HomePage
{
    public class HomeTopPropertyComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeTopPropertyComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {  //todo canlıya taşınınca değiştirilecek
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44312/api/Products/GetByCategoryIDProduct");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<ResultProductDtos> values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}