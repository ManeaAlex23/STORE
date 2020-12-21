using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApiGames.Features;
using WebApiGames.Features.Identity;
using WebApiGames.Features.Games;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApiGames.Infrastructure.Services;

namespace WebApiGames.Infrastructure
{
    public static class ServiceCollectionExtensions
    {

        public static AppSettings GetApplicationSettings(
         this IServiceCollection services,
         IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(appSettingsSection);
            return appSettingsSection.Get<AppSettings>();
        }


        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) =>
             services
                .AddDbContext<UserDbContext>(options => options
                .UseSqlServer(configuration.GetDefaultConnection()));
            
        
            
        
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;


                })
                    .AddEntityFrameworkStores<UserDbContext>();
            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,AppSettings appSettings)
        {

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
         => services
                 .AddTransient<IIdentityService, IdentityService>()
                 .AddScoped<ICurrentUserService,CurrentUserService>()
                 .AddTransient<IGameService, GameService>();


        public static IServiceCollection AddSwagger(this IServiceCollection services)
        =>
            services.AddSwaggerGen(c => c.SwaggerDoc("v1",
                new OpenApiInfo{
                    Title = "My Games API",
                    Version = "v1" }));

            
        
        
    }
}
