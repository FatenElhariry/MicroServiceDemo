using Mango.Kernal.Models;
using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        ILogger<ApplicationDbContext> _logger;
        public ApplicationDbContext(DbContextOptions options, ILogger<ApplicationDbContext> logger): base(options)
        {
            _logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());
            //var assembiles = AppDomain.CurrentDomain.GetAssemblies().Where(c => c.FullName.StartsWith("Domain"));
            
            var entitiesModel = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Entity)).ToList();
            foreach (var entity in entitiesModel)
            {
               _logger.LogInformation( $"register Entity {entity.Name}");
                modelBuilder.Model.AddEntityType(entity);
            }

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                CategoryName = "test",
                Name = "First Seed item",
                Price = 1000,
                Description = "this item is added from seed data in the dbcontext"
            });

        }

    }
}
