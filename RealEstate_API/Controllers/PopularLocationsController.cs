using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Repositories.PopulerLocationRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopulerLocationRepository _populerLocationRepository;
        public PopularLocationsController(IPopulerLocationRepository populerLocationRepository)
        {
            _populerLocationRepository = populerLocationRepository;
        }
        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            return Ok(await _populerLocationRepository.GetAllPopulerLocationAsync());
        }
    }
}