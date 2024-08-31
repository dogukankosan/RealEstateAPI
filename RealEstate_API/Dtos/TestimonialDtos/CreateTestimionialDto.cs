namespace RealEstate_API.Dtos.TestimonialDtos
{
    public class CreateTestimionialDto
    {
        public required string NameSurname { get; set; }
        public required string Title { get; set; }
        public required string Comment { get; set; }
        public bool Status { get; set; }
    }
}