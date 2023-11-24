using CookBook.Application.Services.Cryptography;
using CookBook.Application.Services.Token;
using CookBook.Application.UseCases.Login.DoLogin;
using CookBook.Application.UseCases.User.Register;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Application;

public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var passwordKeySection = configuration.GetRequiredSection("Configurations:PasswordKey");
        var tokenLifeTime = configuration.GetRequiredSection("Configurations:LifeTimeToken");
        var tokenKeySection = configuration.GetRequiredSection("Configurations:TokenKey");
        

        services.AddScoped(option => new TokenController(int.Parse(tokenLifeTime.Value), tokenKeySection.Value));
        services.AddScoped(option => new PasswordCryptography(passwordKeySection.Value));
        services.AddScoped<IUserRegisterUseCase, UserRegisterUseCase>();
        services.AddScoped<ILoginUseCase, LoginUseCase>();
    }
}
