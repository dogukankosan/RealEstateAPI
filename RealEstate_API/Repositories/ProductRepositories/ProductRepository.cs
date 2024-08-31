using Dapper;
using RealEstate_API.Dtos.ProductDtos;
using RealEstate_API.Models.DapperContext;
using RealEstate_API.Repositories.ProductRepositories;
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
        public async void AddProduct(CreateProductDto createProductDto)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@productCategoryID", createProductDto.ProductCategoryID);
                parameters.Add("@employeeID", 1);
                parameters.Add("@productTitle", createProductDto.ProductTitle);
                parameters.Add("@productDesc", createProductDto.ProductDesc);
                parameters.Add("@productPrice", createProductDto.ProductPrice);
                parameters.Add("@productCoverImage", createProductDto.ProductCoverImage);
                parameters.Add("@productCity", createProductDto.ProductCity);
                parameters.Add("@productDistrict", createProductDto.ProductDistrict);
                parameters.Add("@productAddress", createProductDto.ProductAddress);
                parameters.Add("@productType", createProductDto.ProductType);
                parameters.Add("@productStatus", createProductDto.ProductStatus);
                await connection.ExecuteAsync("INSERT Products VALUES (@productCategoryID,@em,ployeeID,@productTitle,@productDesc@productPrice,@productCoverImage,@productCity,@productDistrict,@productAddress,@productType,@productStatus,GETDATE())", parameters);
            }
        }
        public async void DeleteProduct(int id)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@productID", id);
                await connection.ExecuteAsync("DELETE FROM Products WHERE ProductID=@productID ", parameters);
            }
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
        public async void UpdateProduct(UpdateProductDto updateProductDto)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@productID", updateProductDto.ProductID);
                parameters.Add("@productCategoryID", updateProductDto.ProductCategoryID);
                parameters.Add("@employeeID", 1);
                parameters.Add("@productTitle", updateProductDto.ProductTitle);
                parameters.Add("@productDesc", updateProductDto.ProductDesc);
                parameters.Add("@productPrice", updateProductDto.ProductPrice);
                parameters.Add("@productCoverImage", updateProductDto.ProductCoverImage);
                parameters.Add("@productCity", updateProductDto.ProductCity);
                parameters.Add("@productDistrict", updateProductDto.ProductDistrict);
                parameters.Add("@productAddress", updateProductDto.ProductAddress);
                parameters.Add("@productType", updateProductDto.ProductType);
                parameters.Add("@productStatus", updateProductDto.ProductStatus);
                await connection.ExecuteAsync("UPDATE Products SET ProductCategoryID=@productCategoryID,EmployeeID=@employeeID ,ProductTitle='@productTitle' ,ProductDesc='@productDesc' ,ProductPrice=@productPrice, ProductCoverImage='@productCoverImage', ProductCity='@productCity' ,ProductDistrict='@productDistrict', ProductAddress='@productAddress', ProductType='@productType', ProductStatus=@productStatusWHERE ProductID= ", parameters);
            }
        }
    }
}