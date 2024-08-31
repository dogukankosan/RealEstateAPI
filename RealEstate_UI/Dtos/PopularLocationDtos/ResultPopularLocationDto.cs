namespace RealEstate_UI.Dtos.PopularLocationDtos
{
    public class ResultPopularLocationDto
    {
        public byte PopularLocationID { get; set; }
        public required string CityName { get; set; }
        public required string ImageURL { get; set; }
    }
}