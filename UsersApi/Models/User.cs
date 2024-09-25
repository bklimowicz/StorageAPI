namespace UsersApi.Models;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    
    public User(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    public User(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}