using Mango.Services.ProductAPI.Controllers;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().ConfigureApplicationPartManager(manager =>
            {
                manager.FeatureProviders.Add(new MyControllerFeatureProvider());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // auto mapper
            // builder.Services.AddSingleton(MapperConfig.RegisterMaps());
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // DB 
            // builder.Services.AddIdentity

            builder.Services.AddDbContext<ApplicationDbContext>((option) =>
                            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            

            // Register Services 

            builder.Services.RegisterServices();
            var app = builder.Build();
            // builder.Services.BuildServiceProvider().GetService<ApplicationDbContext>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}