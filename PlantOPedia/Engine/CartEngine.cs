using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Models;
using PlantOPedia.Engine;

namespace PlantOPedia.Engine
{
    public class CartEngine : ICartEngine
    {
        readonly PlantdbContext _context;

        public CartEngine(PlantdbContext context)
        {
            _context = context;
        }
        public List<Cart> CartList(Guid id)
        {
             var cart = _context.Carts.Include(p => p.Product).ThenInclude(p => p.ProductType).ThenInclude(c => c.Category).
                        Include(u => u.User).Where(user => user.UserId == id).ToList();

            return cart;
        }
        public SuccessResponse AddToCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
            SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
            return successResponse;
        }
        public SuccessResponse DeleteFromCart(Guid id)
        {
            _context.Carts.Remove(new Cart() { CartId = id });
            _context.SaveChanges();

            SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
            return successResponse;
        }

    }
}
