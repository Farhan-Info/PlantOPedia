using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public class OrderEngine: IOrderEngine
    {
        readonly PlantdbContext _context;
        public OrderEngine(PlantdbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            var list = (_context.Orders.Include(order => order.Product)
                                      .Include(order => order.Users)
                                      .Where(order => order.IsDeleted == false)
                                      .ToList());
            return list;
        }

        public SuccessResponse AddOrder(List<Order> orders)
        {
            foreach (var order in orders)
            {
                order.OrderDate = order.OrderDate.ToLocalTime();
            }
            _context.Orders.AddRange(orders);
            _context.SaveChanges();
            SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
            return (successResponse);
        }

        public SuccessResponse Delete(Guid id)
        {
            var exists = _context.Orders.Find(id);
            {
                //hard delete
                /*_context.Orders.Remove(new Order() { OrderId = id});
                _context.SaveChanges();

                SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
                return Ok(successResponse);*/

                if (exists != null)
                {
                    exists.IsDeleted = true;
                    _context.Orders.Update(exists);
                    _context.SaveChanges();
                }
                else
                {
                    throw new BadHttpRequestException("Not Found", 400);

                }
                SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
                return (successResponse);
            }
        }
    }
}
