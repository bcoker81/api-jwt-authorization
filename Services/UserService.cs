using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RoleBasedAuthentication.Entities;

namespace RoleBasedAuthentication.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>{
            new User {Id = 1, FirstName="John", MiddleName = "L", LastName = "Smith", UserName = "admin", Password = "admin", Role = Role.Admin},
            new User {Id = 2, FirstName="Henrietta", MiddleName = "S", LastName = "Johnson", UserName = "user", Password = "user", Role = Role.User},
            new User {Id = 3, FirstName="Branden", MiddleName = "S", LastName = "Coker", UserName = "bcoker", Password = "test", Role = Role.Admin},
            new User {Id = 4, FirstName="Aubrey", MiddleName = "J", LastName = "Coker", UserName = "aubs1", Password = "test", Role = Role.Readonly}
        };

        private readonly AppSettings _appsettings;

        public UserService(IOptions<AppSettings> appsettings)
        {
            _appsettings = appsettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            //return null is user is now found.
            if (user == null)
            {
                return null;
            }

            // Authentication successful generates a jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // return all users in array
            return _users.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }

        public User GetById(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            // return user without password
            if (user != null)
            {
                user.Password = null;
            }

            return user;
        }
    }
}