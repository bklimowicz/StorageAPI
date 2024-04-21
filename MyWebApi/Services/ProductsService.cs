using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyWebApi.Configuration;
using MyWebApi.Models;

namespace MyWebApi.Services;

public class ProductsService
{
    private readonly IMongoCollection<Product> _productCollection;

    public ProductsService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _productCollection = mongoDb.GetCollection<Product>(databaseSettings.Value.CollectionName);
    }

    public async Task<List<Product>> GetAsync() => await _productCollection.Find(_ => true).ToListAsync();

    public async Task<Product?> GetAsync(string id) =>
        await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();


    public async Task CreateAsync(Product product) => await _productCollection.InsertOneAsync(product);

    public async Task UpdateAsync(Product product) =>
        await _productCollection.ReplaceOneAsync(x => x.Id == product.Id, product);

    public async Task RemoveAsync(string id) => await _productCollection.DeleteOneAsync(x => x.Id == id);
}