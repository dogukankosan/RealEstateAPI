namespace RealEstate_API.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public int ProductID { get; set; }
        public string CategoryName { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductCoverImage { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public string ProductAddress { get; set; }
        public bool ProductStatus { get; set; }
        public bool ProductType { get; set; }
    }
}
