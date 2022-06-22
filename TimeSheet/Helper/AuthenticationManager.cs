using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Entities;

namespace TimeSheet.Helper
{
    public interface IAuthenticationManager
    {
        Answer<string> Manager(string token);
    }

    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly DataContext _context;
        public AuthenticationManager(DataContext context)
        {
            _context = context;
        }

        public Answer<string> Manager(string token)
        {
            Answer<string> getFinishObject;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;

            var claim = tokenS.Claims.FirstOrDefault(x => x.Type == "Key").Value;

            var user = _context.Users.FirstOrDefault(x => x.fin == claim);

            if (user == null)
            {
                user = _context.Users.FirstOrDefault(x => x.email == claim);
            }
            if (user == null)
            {
                return getFinishObject = new Answer<string>(404, "User not found", null);
            }

            var currentRefreshToken = _context.RefreshTokens.FirstOrDefault(a => a.Userid == user.id);

            if (currentRefreshToken == null)
            {
                return getFinishObject = new Answer<string>(404, "Token not found", null);
            }

            if (tokenS.ValidTo < DateTime.UtcNow)
            {
                return getFinishObject = new Answer<string>(401, "Unauthorized", null);
            }

            return getFinishObject = new Answer<string>(200, "Token is active", null);
        }
    }
}

