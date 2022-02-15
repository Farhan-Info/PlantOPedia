using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface ICartEngine
    {
        List<Models.Response.CartByIdResponse> CartList(Guid id);
        SuccessResponse AddToCart (Cart cart);
        SuccessResponse DeleteFromCart(Guid id);
    }
}
