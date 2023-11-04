using Application.Abstraction;
using DataAccess.Context;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApi.Config;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(
    opt => opt.UseSqlServer(cs));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.RegisterEndpoints();
app.MapGet("/", () => "Hello World!");

app.Run();