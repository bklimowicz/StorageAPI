namespace MyWebApi.Services;

public interface IDatabaseService<T>
{
    Task<List<T>> GetAsync();
    Task<T> GetAsync(string id);
    Task CreateAsync(T item);
    Task UpdateAsync(T item);
    Task RemoveAsync(string id);
}