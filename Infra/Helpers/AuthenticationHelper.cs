using Microsoft.IdentityModel.Tokens;
using SouJunior.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SouJunior.Infra.Helpers
{
    public class AuthenticationHelper
    {
        public static byte[] GetKeyBytes()
        {
            var key = AppSettingsConfigHelper.Config.GetSection("Authentication")["AuthenticationSaltKey"]
                ?? "bA5bPOJdwcTeTTET7iyDlHSe6gSO1gOMU4KDoF7f";
            return Encoding.ASCII.GetBytes(key);
        }

        public static int? ReturnValidToken(string token, bool validateLifetime = true)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationToken = new TokenValidationParameters()
            {
                ValidateLifetime = validateLifetime,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(GetKeyBytes())
            };

            SecurityToken validatedToken;
            ClaimsPrincipal principal;
            try
            {
                principal = tokenHandler.ValidateToken(token, validationToken, out validatedToken);
                return int.Parse(principal.Claims.Where(_ => _.Type == "Id").First().Value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static object GenerateToken(UsuarioEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var accessTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    user.Claims.Select(s => new Claim(s.Key, s.Value))
                    ),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(GetKeyBytes()), SecurityAlgorithms.HmacSha256Signature)
            };
            dynamic token = new
            {
                user.Nome,
                user.Email,
                Token = string.Empty
            };

            token.Token = tokenHandler.WriteToken(tokenHandler.CreateToken(accessTokenDescriptor));

            return token;
        }
    }
}
