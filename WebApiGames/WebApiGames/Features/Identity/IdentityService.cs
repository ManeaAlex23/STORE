using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace WebApiGames.Features.Identity
{
    public class IdentityService : IIdentityService
    {
       public string GenerateJwtToken(string UserId,string UserName,string secret)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,UserId),
                    new Claim(ClaimTypes.Name,UserName)

                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
          
        }
    }
}
