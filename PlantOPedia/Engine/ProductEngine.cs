using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public class ProductEngine : IProductEngine
    {
        readonly PlantdbContext _context;
        public ProductEngine(PlantdbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProduct()
        {
            var pro = (_context.Products.Include(p => p.ProductType).
                                    ThenInclude(c => c.Category).Where(product => product.IsDeleted == false).ToList());
            return pro;
        }

        public Product GetProduct(Guid id)
        {
            var product=(_context.Products.Include(p => p.ProductType).
                                    ThenInclude(c => c.Category).FirstOrDefault(product => product.ProductId == id && product.IsDeleted == false));
            return product;
        }
        public SuccessResponse AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
            return (successResponse);
        }
    }

}
