using CookBook.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Application;

public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserRegisterUseCase, UserRegisterUseCase>();
    }
}
