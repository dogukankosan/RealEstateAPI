using RealEstate_API.Dtos.AboutDtos;
using RealEstate_API.Dtos.BottomGridDtos;

namespace RealEstate_API.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        Task<GetBottomGridDto> GetByIDBottomGridAsync(byte id);
        void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);
        void CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
    }
}