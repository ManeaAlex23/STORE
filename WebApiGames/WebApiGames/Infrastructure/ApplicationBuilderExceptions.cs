using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiGames.Features;
using WebApiGames.Migrations;

namespace WebApiGames.Infrastructure
{
    public static class ApplicationBuilderExceptions
    {

        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
        => app
            .UseSwagger()
                .UseSwaggerUI(options =>
                 {
                     options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                     options.RoutePrefix = string.Empty;
                 });


        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<UserDbContext>();

            // dbContext.Database.EnsureCreated();

            dbContext.Database.Migrate();
        }

    }
}
