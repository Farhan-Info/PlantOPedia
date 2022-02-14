namespace PlantOPedia.Models.Response
{
    public class ProductDetail
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public Guid ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }
    }
}


//productTypeId: string;
//productType:
//{
//productSubType: string;
//category:
//    {
//    categoryId: string;
//    categoryType: string;
//    }