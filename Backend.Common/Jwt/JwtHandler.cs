using Backend.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class JwtHandler : IJwtHandler
    {
        private const string BEARER = "Bearer ";

        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly SecurityKey _securityKey;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtHeader _jwtHeader;

        private readonly SecurityConfig _setting;

        public JwtHandler(IOptions<SecurityConfig> setting)
        {
            _setting = setting.Value;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_setting.TokenSymmetricKey));
            _signingCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
            _jwtHeader = new JwtHeader(_signingCredentials);
        }

        public string Create(string id, int expireToken, UserRole role)
        {
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, id),
                new Claim(Constants.ROLE, nameof(role)),
                new Claim(Constants.USERID, id),
                new Claim(ClaimTypes.Role, role.ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.UtcNow.AddDays(expireToken == 0 ? 1: expireToken)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()}")};

            var token = new JwtSecurityToken(
                issuer: Constants.API_ISSUER,
                audience: Constants.API_CLIENT,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(expireToken == 0 ? 1 : expireToken),
                signingCredentials: new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256)
            );

            return _jwtSecurityTokenHandler.WriteToken(token);
        }

        public UserRole GetRoleFromToken(string bearerToken)
        {
            var token = bearerToken;

            if (bearerToken.Contains(BEARER))
                token = token.Remove(bearerToken.IndexOf(BEARER), BEARER.Length);

            var jwtToken = _jwtSecurityTokenHandler.ReadJwtToken(token);

            var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == Constants.ROLE);
            if (roleClaim != null)
            {
                switch (roleClaim.Value)
                {
                    case nameof(UserRole.Administrator):
                        return UserRole.Administrator;
                    case nameof (UserRole.Manager):
                        return UserRole.Manager;
                    case nameof(UserRole.Employee):
                    default:
                        return UserRole.Employee;
                }
            }

            return UserRole.Employee;
        }

        public int GetUserIdFromToken(string bearerToken)
        {
            var token = bearerToken;

            if (bearerToken.Contains(BEARER))
                token = token.Remove(bearerToken.IndexOf(BEARER), BEARER.Length);

            var jwtToken = _jwtSecurityTokenHandler.ReadJwtToken(token);

            var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == Constants.USERID);

            int userId = 0;

            if (roleClaim != null)
            {
                try
                {
                    userId = Int32.Parse(roleClaim.Value);
                }
                catch (Exception ex)
                {
                    userId = 0;
                }
                
            }

            return userId;
        }
    }
}
