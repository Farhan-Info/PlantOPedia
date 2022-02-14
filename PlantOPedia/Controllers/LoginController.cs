using Microsoft.AspNetCore.Mvc;
using PlantOPedia.Models;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using PlantOPedia.Data;
using Microsoft.EntityFrameworkCore;
using PlantOPedia.Engine;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlantOPedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginEngine _loginEngine;
        readonly PlantdbContext _context;
        public LoginController(PlantdbContext context, ILoginEngine loginEngine)
        {
            _context = context;
            _loginEngine = loginEngine;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
        // POST api/<LoginController>
        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.Login  login)
        {
            //var pass = login.password;
            //const string salt = "cgyzqen4plzeknc88umm1q==";
            //byte[] bytessalt = encoding.ascii.getbytes(salt);

            //string hashedpassword = convert.tobase64string(keyderivation.pbkdf2(
            //password: pass,
            //salt: bytessalt,
            //prf: keyderivationprf.hmacsha256,
            //iterationcount: 100000,
            //numbytesrequested: 32));
            //Console.WriteLine($"Hashed: {hashedPassword}");

            //var FindUser = _context.Users.Include(role => role.Role).FirstOrDefault(user => user.Email == login.Email && user.Password == hashedPassword);
            //if (FindUser != null)
            //{
            //    return Ok(FindUser);
            //}
            //else
            //{
            //    ErrorResponse errorResponse = new ErrorResponse() { Code = "400", Message = "Not Found" };
            //    return NotFound(errorResponse);
            //}
            

                return Ok(_loginEngine.CheckUser(login));
            
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
