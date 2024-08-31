namespace RealEstate_API.Dtos.PopulerLocationDtos
{
    public class ResultPopulerLocationDto
    {
        public byte PopularLocationID { get; set; }
        public required string CityName { get; set; }
        public required string ImageURL { get; set; }
    }
}