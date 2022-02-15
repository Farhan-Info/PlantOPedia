namespace PlantOPedia.Models.Request
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }
       
        public string Address { get; set; }
        
        public Guid UserId { get; set; }
        

        public Guid ProductId { get; set; }
        
    }
}
