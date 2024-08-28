using RealEstate_API.Dtos.AboutDtos;

namespace RealEstate_API.Repositories.AboutRepository
{
    public interface IAboutRepository
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task<ResultAboutDto> GetByIDAboutAsync(byte id);
        void UpdateAbout(UpdateAboutDto updateAboutDto);
    }
}