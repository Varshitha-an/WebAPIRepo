﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebAPIProject.Models
{
    public class TokenService : ITokenService
    {
        readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration)
        {
            _key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        public string CreateToken(User user)
        {
            // throw new NotImplementedException();
            var claims = new List<Claim>
           {
               new Claim(JwtRegisteredClaimNames.NameId,user.Username)
           };
            var credential = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = credential
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
