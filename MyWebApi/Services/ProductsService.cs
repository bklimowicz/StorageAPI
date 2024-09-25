using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyWebApi.Configuration;
using MyWebApi.Models;

namespace MyWebApi.Services;

public class ProductsService(IOptions<DatabaseSettings> databaseSettings) : MongoService<Product>(databaseSettings), IProductsService
{
    public async Task<List<Product>> GetByNameAsync(string name) => await _collection.Find(item => item.Name.Contains(name)).ToListAsync();

    public async Task<List<Product>> GetByLocationAsync(string location) => await _collection.Find(item => item.Location == location).ToListAsync();
    
}