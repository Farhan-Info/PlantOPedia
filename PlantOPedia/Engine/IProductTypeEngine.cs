using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface IProductTypeEngine
    {
        List<Models.Response.ProductType> GetPlantType();
    }
}
