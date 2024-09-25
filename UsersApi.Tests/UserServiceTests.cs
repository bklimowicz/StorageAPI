using UsersApi.Models;
using UsersApi.Repository;
using UsersApi.Services.UserService;

namespace UsersApi.Tests;

public class UserServiceTests
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    
    public UserServiceTests()
    {
        
    }

    [Fact]
    public void AddUser_ShouldAddUser()
    {
        // Arrange
        var user = new User("John Doe", "johndoe@example.com");
        var userService = new UserService(_userRepository);
        
        // Act
        userService.AddUser(user);
    }
}