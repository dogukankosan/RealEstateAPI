using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Repositories.SubFeatureRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeaturesController : ControllerBase
    {
        private readonly ISubFeatureRepository _subFeatureRepository;
        public SubFeaturesController(ISubFeatureRepository subFeatureRepository)
        {
            _subFeatureRepository = subFeatureRepository;
        }
        [HttpGet]
        public async Task<IActionResult> SubFeatureList()
        {
            return Ok(await _subFeatureRepository.GetAllSubFeatureAsync());
        }
    }
}