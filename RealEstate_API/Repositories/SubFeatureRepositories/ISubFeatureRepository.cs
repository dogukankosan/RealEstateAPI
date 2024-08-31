using RealEstate_API.Dtos.SubFeatureDtos;

namespace RealEstate_API.Repositories.SubFeatureRepositories
{
    public interface ISubFeatureRepository
    {
        Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync();
        void AddSubFeature(CreateSubFeatureDto createSubFeatureDto);
        void UpdateSubFeature(UpdateSubFeatureDto updateSubFeatureDto);
        void DeleteSubFeature(byte id);
    }
}