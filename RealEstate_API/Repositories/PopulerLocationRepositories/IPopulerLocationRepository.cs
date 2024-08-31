using RealEstate_API.Dtos.PopulerLocationDtos;

namespace RealEstate_API.Repositories.PopulerLocationRepositories
{
    public interface IPopulerLocationRepository
    {
        Task<List<ResultPopulerLocationDto>> GetAllPopulerLocationAsync();
        Task<ResultPopulerLocationDto> GetByIDPopulerLocationAsync(byte id);
        void AddPopulerLocation(CreatePopulerLocationDto createPopulerLocationDto);
        void UpdatePopulerLocation(UpdatePopulerLocationDto updatePopulerLocationDto);
        void DeletePopulerLocation(byte id);
    }
}