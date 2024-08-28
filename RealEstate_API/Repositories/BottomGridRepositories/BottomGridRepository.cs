using Dapper;
using RealEstate_API.Dtos.AboutDtos;
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
        public void CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            throw new NotImplementedException();
        }
        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<ResultBottomGridDto>("SELECT * FROM BottomGrid")).ToList();
            }
        }
        public Task<GetBottomGridDto> GetByIDBottomGridAsync(byte id)
        {
            throw new NotImplementedException();
        }
        public void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            throw new NotImplementedException();
        }
    }
}