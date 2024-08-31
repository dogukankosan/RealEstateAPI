using RealEstate_API.Dtos.AboutDtos;

namespace RealEstate_API.Repositories.AboutRepositories
{
    public interface IAboutRepository
    {
        Task<List<ResultAboutDto>> GetAllAboutTop1Async();
        void UpdateAbout(UpdateAboutDto updateAboutDto);
    }
}