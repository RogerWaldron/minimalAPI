using Application.Abstraction;
using Application.Products.Commands;
using Domain.Models;
using MediatR;

namespace Application.Products.CommandHandlers;

public class UpdateProductHandler : IRequestHandler<UpdateProduct, Product>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        var updatedProduct = new Product
        {
            Brand = request.Brand,
            Title = request.Title,
            Description = request.Description
        };

        await _productRepository.UpdateProduct(updatedProduct, request.ProductId);

        return updatedProduct;
    }
}