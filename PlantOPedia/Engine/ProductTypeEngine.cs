using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public class ProductTypeEngine : IProductTypeEngine
    {
        readonly PlantdbContext _context;
        public ProductTypeEngine(PlantdbContext context)
        {
            _context = context;
        }
        public List<ProductType> GetPlantType()
        {
            var pType = _context.ProductTypes.Include(c => c.Category).ToList();

            return pType;
        }
    }
}
