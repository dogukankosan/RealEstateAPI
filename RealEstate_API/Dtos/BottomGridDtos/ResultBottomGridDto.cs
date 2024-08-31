namespace RealEstate_API.Dtos.BottomGridDtos
{
    public class ResultBottomGridDto
    {
        public byte BottomGridID { get; set; }
        public required string Icon { get;set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}