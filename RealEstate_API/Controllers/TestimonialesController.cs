using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Repositories.TestimonialRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialesController : ControllerBase
    {
        private readonly ITestimonialRepository _testimonialRepository;
        public TestimonialesController(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            return Ok(await _testimonialRepository.GetAllTestimonialAsync());
        }
    }
}