using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Engine;
using PlantOPedia.Models;

namespace PlantOPedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController:ControllerBase
    {
        readonly IProductTypeEngine _productTypeEngine;
        readonly PlantdbContext _context;
        public ProductTypeController(PlantdbContext context, IProductTypeEngine productTypeEngine)
        {
            _context = context;
            _productTypeEngine = productTypeEngine;
            Console.WriteLine("Ptype");
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productTypeEngine.GetPlantType());
        }
    }
}
