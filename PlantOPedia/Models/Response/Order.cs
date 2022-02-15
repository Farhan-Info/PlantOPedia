namespace PlantOPedia.Models.Response
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }
       
        public string Address { get; set; }
        
        public Guid UserId { get; set; }
        public Users? Users { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
