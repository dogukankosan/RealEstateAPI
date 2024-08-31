using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.PopularLocationDtos;

namespace RealEstate_UI.ViewComponents.HomePage
{
    public class HomePopularLocationPropertComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomePopularLocationPropertComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //todo canlıya taşınınca değiştirilecek
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44312/api/PopularLocations");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<ResultPopularLocationDto> values = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}