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
            var product = (_context.Products.Include(p => p.ProductType).
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
        /*public SuccessResponse UpdateProduct(Guid id, Product product)
        {
            var exists = _context.Products.AsNoTracking().FirstOrDefault(product => product.ProductId == id && product.IsDeleted == false);
            if (exists != null)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            else
            {
                throw new BadHttpRequestException("Not Found", 400);
            }
            SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
            return (successResponse);
        }*/
        public SuccessResponse DeleteProduct(Guid id)
        {
            var exists = _context.Products.Find(id);
            if (exists != null)
            {
                exists.IsDeleted = true;
                _context.Products.Update(exists);
                _context.SaveChanges();
            }
            else
            {
                throw new BadHttpRequestException("Not Found", 400);
            }
            SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
            return (successResponse);
        }

        public SuccessResponse UpdateProduct( Guid id,Product product)
        {
            var exists = _context.Products.AsNoTracking().FirstOrDefault(product => product.ProductId == id && product.IsDeleted == false);
            if (exists != null)
            {
                _context.Products.Update(product);
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
