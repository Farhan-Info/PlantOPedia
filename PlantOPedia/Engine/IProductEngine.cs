using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface IProductEngine
    {
        List<Product> GetAllProduct();
        Product GetProduct(Guid id);
        SuccessResponse AddProduct(Product product);
    }
}
