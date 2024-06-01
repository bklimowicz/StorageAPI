using MyWebApi.Models;

namespace MyWebApi.Services;

public interface IProductsService : IDatabaseService<Product>
{
    Task<List<Product>> GetByNameAsync(string name);
    Task<List<Product>> GetByLocationAsync(string location);
}