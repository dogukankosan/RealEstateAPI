using Dapper;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Models.DapperContext;
using System.Data;

namespace RealEstate_API.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<ResultCategoryDto>("SELECT * FROM Categories")).ToList();
            }
        }
        public async Task<ResultCategoryDto> GetByIDCategoryAsync(byte id)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@categoryID", id);
                return await connection.QueryFirstOrDefaultAsync<ResultCategoryDto>("SELECT * FROM Categories WHERE CategoryID=@categoryID", parameters);
            }
        }
        public async void AddCategory(CreateCategoryDto categoryDto)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@categoryName", categoryDto.CategoryName);
                parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
                await connection.ExecuteAsync("INSERT Categories (CategoryName,CategoryStatus) VALUES (@categoryName,@categoryStatus)", parameters);
            }
        }
        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@categoryID", categoryDto.CategoryID);
                parameters.Add("@categoryName", categoryDto.CategoryName);
                parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
                await connection.ExecuteAsync("UPDATE Categories SET CategoryName=@categoryName,CategoryStatus=@categoryStatus WHERE CategoryID=@categoryID", parameters);
            }
        }
        public async void DeleteCategory(byte id)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@categoryID", id);
                await connection.ExecuteAsync("DELETE FROM Categories WHERE CategoryID=@categoryID", parameters);
            }
        }
    }
}