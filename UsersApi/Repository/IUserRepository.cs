using UsersApi.Models;

namespace UsersApi.Repository;

public interface IUserRepository
{
    void AddUser(User user);
    void UpdateUser(User user);
    void RemoveUser(User user);
    IEnumerable<User> GetUsers();
    User GetUserByEmail(string email);
    User GetUserByName(string name);
    User GetUserById(Guid id);
}