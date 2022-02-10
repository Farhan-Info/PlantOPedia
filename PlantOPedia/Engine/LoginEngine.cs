using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Models;
using System.Text;

namespace PlantOPedia.Engine
{
    public class LoginEngine : ILoginEngine
    {
        readonly PlantdbContext _context;
        public LoginEngine(PlantdbContext context)
        {
            _context = context;
        }

        public Users CheckUser(LoginCredentials userobj)
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
            return FindUser;
        }
    }
}
