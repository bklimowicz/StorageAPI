using UsersApi.Services.UserService;

namespace UsersApi.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection builderServices)
    {
        builderServices.AddTransient<IUserService, UserService>();

        return builderServices;
    }
}