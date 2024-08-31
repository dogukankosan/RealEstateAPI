using Dapper;
using RealEstate_API.Dtos.SubFeatureDtos;
using RealEstate_API.Models.DapperContext;
using System.Data;

namespace RealEstate_API.Repositories.SubFeatureRepositories
{
    public class SubFeatureRepository : ISubFeatureRepository
    {
        private readonly Context _context;
        public SubFeatureRepository(Context context)
        {
            _context = context;
        }
        public void AddSubFeature(CreateSubFeatureDto createSubFeatureDto)
        {
            throw new NotImplementedException();
        }
        public void DeleteSubFeature(byte id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync()
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<ResultSubFeatureDto>("SELECT * FROM SubFeature")).ToList();
            }
        }
        public void UpdateSubFeature(UpdateSubFeatureDto updateSubFeatureDto)
        {
            throw new NotImplementedException();
        }
    }
}