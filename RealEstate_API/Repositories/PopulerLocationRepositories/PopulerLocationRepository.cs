using Dapper;
using RealEstate_API.Dtos.PopulerLocationDtos;
using RealEstate_API.Models.DapperContext;
using System.Data;

namespace RealEstate_API.Repositories.PopulerLocationRepositories
{
    public class PopulerLocationRepository : IPopulerLocationRepository
    {
        private readonly Context _context;
        public PopulerLocationRepository(Context context)
        {
            _context = context;
        }
        public async void AddPopulerLocation(CreatePopulerLocationDto createPopulerLocationDto)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@cityName", createPopulerLocationDto.CityName);
                parameters.Add("@imageURL", createPopulerLocationDto.ImageURL);
                await connection.ExecuteAsync("INSERT PopularLocation (CityName,ImageURL) VALUES (@cityName,@imageURL)", parameters);
            }
        }
        public async void DeletePopulerLocation(byte id)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@popularLocationID", id);
                await connection.ExecuteAsync("DELETE FROM PopularLocation WHERE PopularLocationID=@popularLocationID", parameters);
            }
        }
        public async Task<List<ResultPopulerLocationDto>> GetAllPopulerLocationAsync()
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<ResultPopulerLocationDto>("SELECT * FROM PopularLocation")).ToList();
            }
        }
        public async Task<ResultPopulerLocationDto> GetByIDPopulerLocationAsync(byte id)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@popularLocationID", id);
                return await connection.QueryFirstOrDefaultAsync<ResultPopulerLocationDto>("SELECT * FROM PopularLocation WHERE PopularLocationID=@popularLocationID", parameters);
            }
        }
        public async void UpdatePopulerLocation(UpdatePopulerLocationDto updatePopulerLocationDto)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@popularLocationID", updatePopulerLocationDto.CityName);
                parameters.Add("@cityName", updatePopulerLocationDto.CityName);
                parameters.Add("@imageURL", updatePopulerLocationDto.ImageURL);
                await connection.ExecuteAsync("UPDATE PopularLocation SET CityName=@cityName,ImageURL=@imageURL  WHERE PopularLocationID=@popularLocationID", parameters);
            }
        }
    }
}