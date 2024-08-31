namespace RealEstate_API.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public required string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}