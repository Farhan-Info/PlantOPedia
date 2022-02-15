using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface IProductEngine
    {
        List<Models.Response.Product> GetAllProduct();
        Models.Response.ProductDetail GetProduct(Guid id);
        SuccessResponse AddProduct(Models.Request.Product product);
        SuccessResponse UpdateProduct(Guid id, Models.Request.Product product);
        /*SuccessResponse UpdateProduct(Product product);*/
        SuccessResponse DeleteProduct(Guid id);
    }
}
