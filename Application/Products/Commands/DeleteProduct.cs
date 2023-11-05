using MediatR;

namespace Application.Products.Commands;

public class DeleteProduct : IRequest
{
    public int ProductId { get; set; }
}