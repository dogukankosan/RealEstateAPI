namespace RealEstate_API.Dtos.SubFeatureDtos
{
    public class UpdateSubFeatureDto
    {
        public byte SubFeatureID { get; set; }
        public required string Icon { get; set; }
        public required string TopTitle { get; set; }
        public required string MainTitle { get; set; }
        public required string Description { get; set; }
        public required string SubTitle { get; set; }
    }
}