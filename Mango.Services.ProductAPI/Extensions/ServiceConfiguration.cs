using Mango.Services.ProductAPI.Infrastructure.Services;
using Mango.Services.ProductAPI.Persistence.repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Extensions
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices (this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IService<,>), typeof(ServiceDecorator<,>));
            
        }

        public static void AddApplicaitonConfiguration(this IServiceCollection Services, IConfiguration Configuration)
        {
            // define the authentication type
            Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.Authority = Configuration.GetValue<string>("IdentityServer");
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                };
            });


            Services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "mango");

                });
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            Services.AddEndpointsApiExplorer();

            Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "this the product API",
                    Description = "here you can find products and all related details to it",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "aelhariry78@gmail.com",
                        Name = "Faten Elhariry",
                    },
                    Version = "V1"

                });

                c.EnableAnnotations();

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Description = @"Enter the 'Bearer' [space] and your token",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",

                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()

                    }
                });
            });

            // auto mapper
            // builder.Services.AddSingleton(MapperConfig.RegisterMaps());
            Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



        }
    }
}
