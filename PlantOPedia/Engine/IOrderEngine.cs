using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface IOrderEngine
    {
        SuccessResponse AddOrder(List<Order> orders);
        SuccessResponse Delete(Guid id);

        List<Order> GetAll();


    }
}
