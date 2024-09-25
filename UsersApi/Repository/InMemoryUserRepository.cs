using UsersApi.Models;

namespace UsersApi.Repository;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        
        _users.Add(user);
    }

    public void UpdateUser(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        
        var userIndex = _users.FindIndex(u => u.Id == user.Id);
        
        if (userIndex == -1)
        {
            throw new Exception("User not found");
        }

        _users[userIndex] = user;
    }

    public void RemoveUser(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        
        var userToRemove = _users.Find(u => u.Id == user.Id);
        
        if (userToRemove is null)
        {
            throw new Exception("User not found");
        }
        
        _users.Remove(userToRemove);
    }

    public IEnumerable<User> GetUsers() => _users;

    public User GetUserByEmail(string email)
    {
        ArgumentNullException.ThrowIfNull(email);
        
        var user = _users.Find(u => u.Email == email);
        
        if (user is null)
        {
            throw new Exception("User not found");
        }
        
        return user;
    }

    public User GetUserByName(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        
        var user = _users.Find(u => u.Name == name);
        
        if (user is null)
        {
            throw new Exception("User not found");
        }
        
        return user;
    }

    public User GetUserById(Guid id)
    {
        var user = _users.Find(u => u.Id == id);
        
        if (user is null)
        {
            throw new Exception("User not found");
        }
        
        return user;
    }
}