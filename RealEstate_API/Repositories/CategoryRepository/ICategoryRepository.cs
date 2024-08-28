using RealEstate_API.Dtos.CategoryDtos;

namespace RealEstate_API.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync(); 
        Task<ResultCategoryDto> GetByIDCategoryAsync(byte id);
        void AddCategory(CreateCategoryDto categoryDto);
        void UpdateCategory(UpdateCategoryDto categoryDto);
        void DeleteCategory(byte id);
    }
}