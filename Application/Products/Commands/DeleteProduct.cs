using Domain.Models;
using MediatR;

namespace Application.Products.Commands;

public class DeleteProduct : IRequest<Product>
{
    public int ProductId { get; set; }
}