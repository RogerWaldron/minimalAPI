using System.Globalization;
using Application.Abstraction;
using Application.Products.Commands;
using Domain.Models;
using MediatR;

namespace Application.Products.CommandHandlers;

public class DeleteProductHandler : IRequestHandler<DeleteProduct, Product>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(DeleteProduct request, CancellationToken cancellationToken)
    {
        await _productRepository.DeleteProduct(request.ProductId);

        return null;
    }
}