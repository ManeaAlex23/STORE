using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace WebApiGames.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnection(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");

     
    }
}
