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
    public class CartController : ControllerBase
    {
        readonly ICartEngine _cartEngine;
        readonly PlantdbContext _context;
        public CartController(PlantdbContext context, ICartEngine cartEngine)
        {
            _context = context;
            _cartEngine = cartEngine;
        }
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_cartEngine.CartList(id));
        }

        // POST api/<CartController>
        [HttpPost]
        public IActionResult Post([FromBody] Cart cart)
        {
            return Ok(_cartEngine.AddToCart(cart));
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {            
            return Ok(_cartEngine.DeleteFromCart(id));
        }
    }
}
