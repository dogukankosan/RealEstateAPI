using Dapper;
using RealEstate_API.Dtos.BottomGridDtos;
using RealEstate_API.Models.DapperContext;
using System.Data;

namespace RealEstate_API.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;
        public BottomGridRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<ResultBottomGridDto>("SELECT * FROM BottomGrid")).ToList();
            }
        }
        public async Task<GetBottomGridDto> GetByIDBottomGridAsync(byte id)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@bottomGridID", id);
                return await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>("SELECT * FROM BottomGrid WHERE BottomGridID=@bottomGridID", parameters);
            }
        }
        public async void UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@bottomID", updateBottomGridDto.BottomGridID);
                parameters.Add("@bottomIcon", updateBottomGridDto.Icon);
                parameters.Add("@bottomTitle", updateBottomGridDto.Title);
                parameters.Add("@bottomDesc", updateBottomGridDto.Description);
                await connection.ExecuteAsync("UPDATE BottomGrid SET Icon='bottomIcon' , Title='@bottomTitle' ,Description='@bottomDesc' WHERE BottomGridID=@bottomID", parameters);
            }
        }
    }
}