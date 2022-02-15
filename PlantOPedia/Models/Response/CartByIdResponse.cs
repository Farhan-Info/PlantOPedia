namespace PlantOPedia.Models.Response
{
    public class CartByIdResponse
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public ProductDetail Product { get; set; }

      
    

    }
}
