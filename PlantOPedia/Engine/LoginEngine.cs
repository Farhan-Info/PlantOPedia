using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Models;
using System.Text;
using AutoMapper;


namespace PlantOPedia.Engine
{
    public class LoginEngine : ILoginEngine
    {
        readonly PlantdbContext _context;
        private readonly IMapper _mapper;
        public LoginEngine(PlantdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Models.Response.Login CheckUser(Models.Request.Login userobj)
        {

            var pass = userobj.Password;
            const string Salt = "CGYzqeN4plZekNC88Umm1Q==";
            byte[] bytesSalt = Encoding.ASCII.GetBytes(Salt);

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: pass,
            salt: bytesSalt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 32));
            //Console.WriteLine($"Hashed: {hashedPassword}");

            var FindUser = _context.Users.Include(role => role.Role).FirstOrDefault(user => user.Email == userobj.Email && user.Password == hashedPassword);
            if (FindUser == null)
            {
                throw new BadHttpRequestException("Not Found", 400);
            }
            return _mapper.Map<Models.Response.Login>(FindUser);
        }
    }
}
