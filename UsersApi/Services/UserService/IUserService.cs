using UsersApi.Models;

namespace UsersApi.Services.UserService;

public interface IUserService
{
    void AddUser(User user);
    void UpdateUser(User user);
    void RemoveUser(User user);
    IEnumerable<User> GetUsers();
    User GetUserByEmail(string email);
    User GetUserByName(string name);
    User GetUserById(Guid id);
}