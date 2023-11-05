using Domain.Models;

namespace Application.Abstraction
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllProducts();

        Task<Product?> GetProductById(int productId);

        Task<Product> CreateProduct(Product toCreate);

        Task<Product?> UpdateProduct(Product toUpdate, int productId);

        Task DeleteProduct(int productId);
    }
}