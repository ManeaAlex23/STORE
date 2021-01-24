using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiGames.Infrastructure;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace WebApiGames
{
   

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;
     

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)

           => services
                .AddDatabase(this.Configuration)
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration))
                .AddSwagger()
                .AddApplicationServices()
                .AddControllers();
               
             

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }




            app
                .UseSwaggerUI()
                .UseRouting()
                .UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                 {
                     endpoints.MapControllers();
                 })
                .ApplyMigrations();
        }
    }
}