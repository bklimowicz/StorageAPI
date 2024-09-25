using UsersApi.Models;
using UsersApi.Repository;

namespace UsersApi.Services.UserService;

public class UserService(IUserRepository userRepository) : IUserService
{
    public void AddUser(User user) => userRepository.AddUser(user);

    public void UpdateUser(User user) => userRepository.UpdateUser(user);

    public void RemoveUser(User user) => userRepository.RemoveUser(user);

    public IEnumerable<User> GetUsers() => userRepository.GetUsers();

    public User GetUserByEmail(string email) => userRepository.GetUserByEmail(email);

    public User GetUserByName(string name) => userRepository.GetUserByName(name);

    public User GetUserById(Guid id) => userRepository.GetUserById(id);
}