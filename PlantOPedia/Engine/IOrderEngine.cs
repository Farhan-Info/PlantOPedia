using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface IOrderEngine
    {
        SuccessResponse AddOrder(List<Models.Request.Order> orders);
        SuccessResponse Delete(Guid id);

        List<Models.Response.Order> GetAll();


    }
}
