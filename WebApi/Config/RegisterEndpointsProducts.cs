using Application.Products.Commands;
using Application.Products.Queries;
using Domain.Models;
using MediatR;

namespace WebApi.Config;

public static class RegisterEndpointsProducts
{
    public static void RegisterProductsApiEndpoints(this WebApplication app)
    {
        var groupUrl = app.MapGroup("/api/products");

        groupUrl.MapGet("/{id}", GetProductByIdAsync).WithName("GetProductById");

        groupUrl.MapGet("/", GetAllProductsAsync);

        groupUrl.MapPost("/", CreateProductAsync);

        groupUrl.MapPut("/{id}", UpdateProductAsync);

        groupUrl.MapDelete("/{id}", DeleteProductAsync);
    }

    private static async Task<IResult> GetAllProductsAsync(IMediator m)
    {
        var req = new GetAllProducts();
        var products = await m.Send(req);

        return Results.Ok(products);
    }

    private static async Task<IResult> GetProductByIdAsync(IMediator m, int id)
    {
        var getProduct = new GetProductById { ProductId = id };
        var result = await m.Send(getProduct);

        return Results.Ok(result);
    }

    private static async Task<IResult> CreateProductAsync(IMediator m, Product product)
    {
        var createProduct = new CreateProduct
        {
            Brand = product.Brand, Title = product.Title, Description = product.Description
        };
        var newProduct = await m.Send(createProduct);
        
        return Results.CreatedAtRoute("GetProductById", new { newProduct.Id }, newProduct);
    }

    private static async Task<IResult> UpdateProductAsync(IMediator m, Product product, int id)
    {
        var update = new UpdateProduct
        {
            ProductId = id,
            Brand = product.Brand,
            Title = product.Title,
            Description = product.Description
        };
        var updatedProduct = await m.Send(update);

        return Results.Ok(updatedProduct);
    }

    private static async Task<IResult> DeleteProductAsync(IMediator m, int id)
    {
        var delete = new DeleteProduct { ProductId = id };
        await m.Send(delete);

        return Results.NoContent();
    }
}
