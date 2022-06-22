using Microsoft.Extensions.Configuration;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.LoginDtos;
using TimeSheet.Entities;

namespace TimeSheet.Helper
{
    public class TokenInit
    {
        private readonly IJwtService _jwtService;
        private readonly DataContext _context;
        public TokenInit(IJwtService jwtService, DataContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }

        public Token Init(UserLoginDto item, IConfiguration _config, int Userid)
        {
            string keyStr = "5698a018-d023-43a0-bc35-b57bba9ad800";

            Token Token = _jwtService.Generate(item, _config, keyStr);

            var hasToken = _context.RefreshTokens.FirstOrDefault(x => x.Userid == Userid);

            if (hasToken != null)
            {
                hasToken.RefreshTokenString = Token.RefreshToken;
                hasToken.RefreshTokenEndDate = Token.ExpiredTime.AddMinutes(5);
            }
            else
            {
                RefreshToken newRefreshToken = new RefreshToken()
                {
                    Userid = Userid,
                    RefreshTokenString = Token.RefreshToken,
                    RefreshTokenEndDate = Token.ExpiredTime.AddMinutes(5)

                };
                _context.RefreshTokens.Add(newRefreshToken);
            }

            _context.SaveChanges();

            return Token;
        }

    }
}
