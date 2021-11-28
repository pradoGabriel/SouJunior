using Microsoft.IdentityModel.Tokens;
using SouJunior.Domain.Entities;
using SouJunior.Infra.Helpers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SouJunior.Service.Services
{
    public static class AuthService
    {

        public static string GenerateToken(UsuarioEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthenticationHelper.Secret);
            var role = string.Empty;

            if (user.Empreendedor != null)
                role = "empreendedor";
            if (user.EmpresaJr != null)
                role = "empresajr";
            if (user.Estudante != null)
                role = "estudante";

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Nome.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, role),
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
