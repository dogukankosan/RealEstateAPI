namespace RealEstate_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public byte ProductCategoryID { get; set; }
        public int EmployeeID { get; set; }
        public required string ProductTitle { get; set; }
        public required string ProductDesc { get; set; }
        public decimal ProductPrice { get; set; }
        public required string ProductCoverImage { get; set; }
        public required string ProductCity { get; set; }
        public required string ProductDistrict { get; set; }
        public required string ProductAddress { get; set; }
        public bool ProductStatus { get; set; }
        public bool ProductType { get; set; }
        public DateTime ProductCreateDate { get; set; } = DateTime.Now;
    }
}