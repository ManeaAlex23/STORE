using System.Linq;
using System.Security.Claims;


namespace WebApiGames.Infrastructure
{
    public static class IdentityExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user
                .Claims
                .FirstOrDefault(g => g.Type == ClaimTypes.NameIdentifier)
                ?.Value;


      
    }
}
