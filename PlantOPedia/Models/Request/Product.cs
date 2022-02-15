namespace PlantOPedia.Models.Request
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }

    }
}
