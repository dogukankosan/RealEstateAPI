using Dapper;
using RealEstate_API.Dtos.AboutDtos;
using RealEstate_API.Models.DapperContext;
using System.Data;

namespace RealEstate_API.Repositories.AboutRepository
{
    public class AboutRepository : IAboutRepository
    {
        private readonly Context _context;
        public AboutRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<ResultAboutDto>("SELECT * FROM Abouts")).ToList();
            }
        }
        public async Task<ResultAboutDto> GetByIDAboutAsync(byte id)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@aboutID", id);
                return await connection.QueryFirstOrDefaultAsync<ResultAboutDto>("SELECT * FROM Abouts WHERE AboutID=@aboutID", parameters);
            }
        }
        public async void UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@aboutID", updateAboutDto.AboutID);
                parameters.Add("@aboutDesc1", updateAboutDto.AboutDesc1);
                parameters.Add("@aboutDesc2", updateAboutDto.AboutDesc2);
                parameters.Add("@aboutService1", updateAboutDto.AboutService1);
                parameters.Add("@aboutService2", updateAboutDto.AboutService2);
                parameters.Add("@aboutService3", updateAboutDto.AboutService3);
                parameters.Add("@aboutService4", updateAboutDto.AboutService4);
                parameters.Add("@aboutService5", updateAboutDto.AboutService5);
                parameters.Add("@aboutService6", updateAboutDto.AboutService6);
                await connection.ExecuteAsync("UPDATE Abouts SET \r\nAboutDesc1=@aboutDesc1,\r\nAboutDesc2=@aboutDesc2,\r\nAboutService1=@aboutService1,\r\nAboutService2=@aboutService2,\r\nAboutService3=@aboutService3,\r\nAboutService4=@aboutService4,\r\nAboutService5=@aboutService5,\r\nAboutService6=@aboutService6,\r\nWHERE AboutID=@aboutID", parameters);
            }
        }
    }
}