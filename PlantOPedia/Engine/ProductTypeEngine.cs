using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Models;

namespace PlantOPedia.Engine
{
    public class ProductTypeEngine : IProductTypeEngine
    {
        private readonly IMapper _mapper;

        readonly PlantdbContext _context;
        public ProductTypeEngine(PlantdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Models.Response.ProductType> GetPlantType()
        {
            var pType = _context.ProductTypes.Include(c => c.Category).ToList();

            return _mapper.Map<List<Models.Response.ProductType>>(pType);
        }
    }
}
