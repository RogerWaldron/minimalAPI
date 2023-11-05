using Domain.Models;
using MediatR;

namespace Application.Products.Queries;

public class GetProductById : IRequest<Product>
{
    public int ProductId { get; set; }
}