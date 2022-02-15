using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Models;
using System.Text;

namespace PlantOPedia.Engine
{
    public class UserEngine : IUserEngine
    {
        private readonly IMapper _mapper;
        readonly PlantdbContext _context;
        public UserEngine(PlantdbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Models.Response.User Get(Guid id)
        {
            var user =( _context.Users
                        .FirstOrDefault(User => User.UserId == id && User.IsDeleted == false));
            return _mapper.Map<Models.Response.User>(user);
        }

        public SuccessResponse Post(Models.Request.User user)
        {
            const string Salt = "CGYzqeN4plZekNC88Umm1Q==";
            byte[] bytesSalt = Encoding.ASCII.GetBytes(Salt);

            user.Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: user.Password,
            salt: bytesSalt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 32));

            _context.Users.Add(_mapper.Map<Models.Users>(user));
            _context.SaveChanges();
            SuccessResponse successResponse = new SuccessResponse() { Code = "200", Message = "Success" };
            return (successResponse);
        }

        public SuccessResponse Put(Guid id, Models.Request.User user)
        {
            var exists = _context.Users.AsNoTracking().FirstOrDefault(user => user.UserId == id && user.IsDeleted == false);
            if (exists != null)
            {
                _context.Users.Update(_mapper.Map<Models.Users>(user));
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
