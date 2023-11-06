using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions opt) : base(opt)
    {
    }
    
    public DbSet<Product> Products { get; set; } 
}


