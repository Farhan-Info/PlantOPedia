using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Engine;
using PlantOPedia.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlantOPedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductEngine _productEngine;
        readonly PlantdbContext _context;
        public ProductController(PlantdbContext context, IProductEngine productEngine)
        {
            _context = context;
            _productEngine = productEngine;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productEngine.GetAllProduct());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_productEngine.GetProduct(id));

        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            //_context.Products.Add(product);
            //_context.SaveChanges();
            //SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
            return Ok(_productEngine.AddProduct(product));
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Product product)
        {
            //var Productexists = _context.Products.FirstOrDefault(p => p.ProductId.Equals(id));

            /*var exists = _context.Products.AsNoTracking().FirstOrDefault(product => product.ProductId == id && product.IsDeleted == false);
            if(exists != null)
            {
                _context.Products.Update(product);
                _context.SaveChanges();

                SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };*/
            /*  return Ok(_productEngine.UpdateProduct(product));
          }

          ErrorResponse errorResponse = new ErrorResponse() { Code = "404", Message = "Not Found" };
          return NotFound(errorResponse);
*/
            return Ok(_productEngine.UpdateProduct(product));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            //Soft Delete
            /*var exists = _context.Products.Find(id);
            if (exists != null)
        {
                exists.IsDeleted = true;
                _context.Products.Update(exists);
                _context.SaveChanges();

                SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
                return Ok(successResponse);
            }
            else
            {
                ErrorResponse errorResponse = new ErrorResponse() { Code = "404", Message = "Not Found" };
                return NotFound(errorResponse);
            }

        }*/
            return Ok(_productEngine.DeleteProduct(id));
        }
    }
}
