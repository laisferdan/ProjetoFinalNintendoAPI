using Microsoft.IdentityModel.Tokens;
using ProjetoFinalNintendoAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoFinalNintendoAPI.AuthorizationAndAuthentication
{
    public class GenerateToken
    {
        private readonly TokenConfiguration _tokenConfiguration;

        public GenerateToken(TokenConfiguration tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration;
        }

        public string GenerateJwt(UsersModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenConfiguration.Secret));
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                Expires = DateTime.UtcNow.AddHours(_tokenConfiguration.ExpirationTimeInHours),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,  _tokenConfiguration.Sub),
                    new Claim("Module", _tokenConfiguration.Module)
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}