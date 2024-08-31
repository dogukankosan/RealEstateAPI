using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.AboutDtos;
using RealEstate_API.Repositories.AboutRepositories;


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
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            return Ok(await _aboutRepository.GetAllAboutTop1Async());
        }
        [HttpPut]
        public async Task<IActionResult> AboutUpdate(UpdateAboutDto updateAboutDto)
        {
            _aboutRepository.UpdateAbout(updateAboutDto);
            return Ok("Hakkında Başarılı Bir Şekilde Güncellendi");
        }
    }
}