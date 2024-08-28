namespace RealEstate_UI.Dtos.ProductDtos
{
    public class ResultProductDtos
    {
        public int productID { get; set; }
        public object CategoryName { get; set; }
        public string productTitle { get; set; }
        public string productDesc { get; set; }
        public decimal productPrice { get; set; }
        public object productCoverImage { get; set; }
        public string productCity { get; set; }
        public string productDistrict { get; set; }
        public string productAddress { get; set; }
        public bool productStatus { get; set; }
        public bool productType { get; set; }
    }
}