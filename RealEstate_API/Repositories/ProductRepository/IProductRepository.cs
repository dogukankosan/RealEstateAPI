using RealEstate_API.Dtos.ProductDtos;

namespace RealEstate_API.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetByCategoryIDProductAsync();
    }
}