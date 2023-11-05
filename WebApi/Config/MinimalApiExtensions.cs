using Application.Abstraction;
using DataAccess.Context;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Config
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("DB connection string not found!");
            builder.Services.AddDbContext<ProductDbContext>(opt => opt.UseSqlServer(cs));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();           
        }

        public static void RegisterEndpoints(this WebApplication app)
        {
            
        }
    }
}