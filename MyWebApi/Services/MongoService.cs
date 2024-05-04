using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyWebApi.Configuration;
using MyWebApi.Models;

namespace MyWebApi.Services;

public class MongoService<T> : IDatabaseService<T> where T : CollectionBase
{
    private IMongoCollection<T> _collection;

    public MongoService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _collection = mongoDb.GetCollection<T>(typeof(T).Name);
    }

    public async Task<List<T>> GetAsync() => await _collection.Find(_ => true).ToListAsync();

    public async Task<T> GetAsync(string id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(T item) => await _collection.InsertOneAsync(item);

    public async Task UpdateAsync(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        await _collection.ReplaceOneAsync(x => x.Id == item.Id, item);
    }

    public async Task RemoveAsync(string id) => await _collection.DeleteOneAsync(x => x.Id == id);
}