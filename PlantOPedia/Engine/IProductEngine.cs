using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface IProductEngine
    {
        List<Models.Response.Product> GetAllProduct();
        Models.Response.ProductDetail GetProduct(Guid id);
        SuccessResponse AddProduct(Product product);
        SuccessResponse UpdateProduct(Guid id,Product product);
        /*SuccessResponse UpdateProduct(Product product);*/
        SuccessResponse DeleteProduct(Guid id);
    }
}
