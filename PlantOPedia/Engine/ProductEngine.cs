using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public class ProductEngine : IProductEngine
    {
        private readonly IMapper _mapper;
        readonly PlantdbContext _context;
        public ProductEngine(PlantdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Models.Response.Product> GetAllProduct()
        {
            var pro = (_context.Products.Include(p => p.ProductType).
                                    ThenInclude(c => c.Category).Where(product => product.IsDeleted == false).ToList());
            return _mapper.Map<List<Models.Response.Product>>(pro);
        }

        public Models.Response.ProductDetail GetProduct(Guid id)
        {
            var product = (_context.Products.Include(p => p.ProductType).
                                    ThenInclude(c => c.Category).FirstOrDefault(product => product.ProductId == id && product.IsDeleted == false));
            return _mapper.Map<Models.Response.ProductDetail>(product);
        }
        public SuccessResponse AddProduct(Models.Request.Product product)
        {
            var pro = _mapper.Map<Models.Product>(product);
            _context.Products.Add(pro);
            _context.SaveChanges();
            SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
            return (successResponse);
        }
        public SuccessResponse UpdateProduct(Guid id, Models.Request.Product product)
        {
            var uproduct = _mapper.Map<Models.Product>(product);
            var exists = _context.Products.AsNoTracking().FirstOrDefault(product => product.ProductId == id && product.IsDeleted == false);
            if (exists != null)
            {
                _context.Products.Update(uproduct);
                _context.SaveChanges();
            }
            else
            {
                throw new BadHttpRequestException("Not Found", 400);
            }
            SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
            return (successResponse);
        }
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
