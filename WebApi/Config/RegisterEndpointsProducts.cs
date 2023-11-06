using Application.Products.Commands;
using Application.Products.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Config;

public static class RegisterEndpointsProducts
{
    public static void RegisterProductsApiEndpoints(this WebApplication app)
    {
        var groupUrl = app.MapGroup("/api/products");

        groupUrl.MapGet("/{id}", GetProductByIdAsync)
            .WithName("GetProductById")
            .WithTags("ProductsGroup")
            .WithOpenApi();

        groupUrl.MapGet("/", GetAllProductsAsync)
            .WithTags("ProductsGroup")
            .WithOpenApi();

        groupUrl.MapPost("/", CreateProductAsync)
            .WithTags("ProductsGroup")
            .WithOpenApi();

        groupUrl.MapPut("/{id}", UpdateProductAsync)
            .WithTags("ProductsGroup")
            .WithOpenApi();

        groupUrl.MapDelete("/{id}", DeleteProductAsync)
            .WithTags("ProductsGroup")
            .WithOpenApi();
    }

    private static async Task<Ok<ICollection<Product>>> GetAllProductsAsync(IMediator m)
    {
        var req = new GetAllProducts();
        var products = await m.Send(req);

        return TypedResults.Ok(products);
    }

    private static async Task<Ok<Product>> GetProductByIdAsync(IMediator m, int id)
    {
        var getProduct = new GetProductById { ProductId = id };
        var product = await m.Send(getProduct);
        
        return TypedResults.Ok(product);
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

    private static async Task<Ok<Product>> UpdateProductAsync(IMediator m, Product product, int id)
    {
        var update = new UpdateProduct
        {
            ProductId = id,
            Brand = product.Brand,
            Title = product.Title,
            Description = product.Description
        };
        var updatedProduct = await m.Send(update);

        return TypedResults.Ok(updatedProduct);
    }

    private static async Task<NoContent> DeleteProductAsync(IMediator m, int id)
    {
        var delete = new DeleteProduct { ProductId = id };
        await m.Send(delete);

        return TypedResults.NoContent();
    }
}
