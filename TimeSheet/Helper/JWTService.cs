using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TimeSheet.Dtos.LoginDtos;
using TimeSheet.Entities;

namespace TimeSheet.Helper
{
    public interface IJwtService
    {
        Token Generate(UserLoginDto item, IConfiguration _config, string keyStr);
    }
    public class JwtService : IJwtService
    {
        public Token Generate(UserLoginDto item, IConfiguration _config, string keyStr)
        {
            List<Claim> claimss = new List<Claim>
            {
                new Claim("Key",item.key)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(keyStr));

            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken
            (
                claims: claimss,
                signingCredentials: cred,
                expires: DateTime.Now.AddDays(Convert.ToInt32(_config.GetSection("JWT:expires").Value)),
                issuer: _config.GetSection("JWT:issuer").Value,
                audience: _config.GetSection("JWT:audience").Value
             );

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = CreateGuid();

            Token newToken = new Token()
            {
                token = tokenStr,
                RefreshToken = refreshToken,
                ExpiredTime = DateTime.Now.AddDays(Convert.ToInt32(_config.GetSection("JWT:expires").Value)) // this is equal to expires property of JwtSecurityToken object
            };
            return newToken;

        }

        public string CreateGuid()
        {
            var newKeyStr = Guid.NewGuid().ToString();

            return newKeyStr;
        }
    }
}