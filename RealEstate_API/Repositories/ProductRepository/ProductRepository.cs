using Dapper;
using RealEstate_API.Dtos.ProductDtos;
using RealEstate_API.Models.DapperContext;
using System.Data;

namespace RealEstate_API.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<ResultProductDto>("SELECT * FROM Products")).ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetByCategoryIDProductAsync()
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<ResultProductWithCategoryDto>("SELECT  \r\nCategoryName,\r\nProductTitle, \r\nProductDesc,\r\nProductPrice,\r\nProductCoverImage, \r\nProductCity, \r\nProductDistrict,\r\nProductAddress,\r\nProductStatus,ProductType FROM PRODUCTS  INNER JOIN \r\nCategories  ON CategoryID=ProductCategoryID ")).ToList();
            }
        }
    }
}