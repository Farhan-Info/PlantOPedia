using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public interface ICartEngine
    {
        List<Cart> CartList(Guid id);
        SuccessResponse AddToCart(Cart cart);
        SuccessResponse DeleteFromCart(Guid id);
    }
}
