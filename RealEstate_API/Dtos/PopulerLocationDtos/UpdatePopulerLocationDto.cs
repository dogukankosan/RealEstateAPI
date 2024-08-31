namespace RealEstate_API.Dtos.PopulerLocationDtos
{
    public class UpdatePopulerLocationDto
    {
        public byte PopularLocationID { get; set; }
        public required string CityName { get; set; }
        public required string ImageURL { get; set; }
    }
}