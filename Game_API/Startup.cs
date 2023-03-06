using Game_API.Repository;
using Game_API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Game_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Key Auth", Version = "v1" });
                 c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                 {
                     Description = "ApiKey must appear in header",
                     Type = SecuritySchemeType.ApiKey,
                     Name = "ApiKey",
                     In = ParameterLocation.Header,
                     Scheme = "ApiKeyScheme"
                 });
                 var key = new OpenApiSecurityScheme()
                 {
                     Reference = new OpenApiReference
                     {
                         Type = ReferenceType.SecurityScheme,
                         Id = "ApiKey"
                     },
                     In = ParameterLocation.Header
                 };
                 var requirement = new OpenApiSecurityRequirement
                     {
                             { key, new List<string>() }
                     };
                 c.AddSecurityRequirement(requirement);
             });

            var connectionString = Configuration.GetConnectionString("Game");

            services.AddDbContext<GameContext>(
                options => options.UseSqlServer(connectionString)
            );

            services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddScoped(typeof(IGameService), typeof(GameService));
            services.AddScoped(typeof(IGameRepository), typeof(GameRepository));
            services.AddScoped(typeof(IGameRepository), typeof(GameRepository));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Game_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
