using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services)
    {

    }

    private static void AddFluentMigrator(IServiceCollection services)
    {
        services.AddFluentMigratorCore();
    }
}
