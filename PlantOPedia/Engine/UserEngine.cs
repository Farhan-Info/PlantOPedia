using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Models;
using System.Text;

namespace PlantOPedia.Engine
{
    public class UserEngine : IUserEngine
    {
        readonly PlantdbContext _context;
        public UserEngine(PlantdbContext context)
        {
            _context = context;
        }

        public Users Get(Guid id)
        {
            var user =( _context.Users
                        .FirstOrDefault(User => User.UserId == id && User.IsDeleted == false));
            return user;
        }

        public SuccessResponse Post(Users user)
        {
            const string Salt = "CGYzqeN4plZekNC88Umm1Q==";
            byte[] bytesSalt = Encoding.ASCII.GetBytes(Salt);

            user.Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: user.Password,
            salt: bytesSalt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 32));

            _context.Users.Add(user);
            _context.SaveChanges();
            SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
            return (successResponse);
        }

        public SuccessResponse Put(Guid id, Users user)
        {
            var exists = _context.Users.AsNoTracking().FirstOrDefault(user => user.UserId == id && user.IsDeleted == false);
            if (exists != null)
            {
                _context.Users.Update(user);
                _context.SaveChanges();

                SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
                return (successResponse);
            }
            else
            {
                throw new BadHttpRequestException("Not Found", 400);
            }
           

        }
    }
}
