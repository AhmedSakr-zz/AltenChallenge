using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ui.Contracts;
using ui.ViewModels;

namespace ui.Services
{
    

    public class UserServices : IUserServices
    {
        private readonly IConfiguration _configuration;

        public UserServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool ValidatePassword(LoginViewModelForPostDto user)
        {
            var result = Queryable()
                .FirstOrDefault(t => t.Username == user.Username && t.Password == user.Password);

            if (result == null)
                return false;

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWtKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                _configuration["ValidIssuer"],
                _configuration["ValidAudience"],
                new List<Claim>(),
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signinCredentials
            )
            {
                Payload ={["Username"] = user.Username}
            };
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            user.Token = tokenString;
            return true;
        }

        public IQueryable<LoginViewModelForPostDto> Queryable()
        {
            //fake users list
            var users = new List<LoginViewModelForPostDto>
                {new LoginViewModelForPostDto {Username = "admin", Password = "admin"}};
            return users.AsQueryable();
        }
    }
}
