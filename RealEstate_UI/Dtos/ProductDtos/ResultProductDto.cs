namespace RealEstate_UI.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int productID { get; set; }
        public object CategoryName { get; set; }
        public required string productTitle { get; set; }
        public required string productDesc { get; set; }
        public decimal productPrice { get; set; }
        public required string productCoverImage { get; set; }
        public required string productCity { get; set; }
        public required string productDistrict { get; set; }
        public required string productAddress { get; set; }
        public bool productStatus { get; set; }
        public bool productType { get; set; }
    }
}