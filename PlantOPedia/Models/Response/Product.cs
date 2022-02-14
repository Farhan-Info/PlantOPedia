namespace PlantOPedia.Models.Response
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
