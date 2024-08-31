namespace RealEstate_UI.Dtos.TestimonialDtos
{
    public class ResultTestiMonialDto
    {
        public int TestimonialID { get; set; }
        public required string NameSurname { get; set; }
        public required string Title { get; set; }
        public required string Comment { get; set; }
        public bool Status { get; set; }
    }
}