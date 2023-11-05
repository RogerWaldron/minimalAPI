using Application.Products.Commands;
using Application.Products.Queries;
using Domain.Models;
using MediatR;
using WebApi.Config;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();


var app = builder.Build();

app.RegisterEndpoints();
app.MapGet("/", () => "Hello World!");
app.MapGet("/api/products/{id}", async (IMediator m, int id) =>
{
    var getProduct = new GetProductById { ProductId = id};
    var result = await m.Send(getProduct);

    return Results.Ok(result);
}).WithName("GetProductById");

app.MapPost("/api/products", async (IMediator m, Product product) =>
{
    var createProduct = new CreateProduct
    {
        Brand = product.Brand, Title = product.Title, Description = product.Description
    };
    var newProduct = await m.Send(createProduct);

    return Results.CreatedAtRoute("GetProductById", new { newProduct.Id }, newProduct);
});

app.Run();