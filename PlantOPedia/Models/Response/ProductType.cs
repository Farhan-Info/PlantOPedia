namespace PlantOPedia.Models.Response
{
    public class ProductType
    {
        
        public Guid ProductTypeId { get; set; }
        public ProductSubType ProductSubType { get; set; }
       
        public Category Category { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
