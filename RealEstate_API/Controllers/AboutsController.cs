using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.AboutDtos;
using RealEstate_API.Repositories.AboutRepository;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutRepository _aboutRepository;
        public AboutsController(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AboutByID(byte id)
        {
            return Ok(await _aboutRepository.GetByIDAboutAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            return Ok(await _aboutRepository.GetAllAboutAsync());
        }
        [HttpPut]
        public async Task<IActionResult> AboutUpdate(UpdateAboutDto updateAboutDto)
        {
            _aboutRepository.UpdateAbout(updateAboutDto);
            return Ok("Hakkında Başarılı Bir Şekilde Güncellendi");
        }
    }
}