using RealEstate_API.Dtos.ProductDtos;

namespace RealEstate_API.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetByCategoryIDProductAsync();
        void AddProduct(CreateProductDto createProductDto);
        void UpdateProduct(UpdateProductDto updateProductDto);
        void DeleteProduct(int id);
    }
}