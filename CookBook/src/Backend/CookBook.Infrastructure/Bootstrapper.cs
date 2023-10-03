using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CookBook.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, string connectionString)
    {
        AddFluentMigrator(services, connectionString);
    }

    private static void AddFluentMigrator(IServiceCollection services, string connectionString)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c =>
        c.AddSqlServer()
        .WithGlobalConnectionString(connectionString).ScanIn(Assembly.Load("CookBook.Infrastructure"))
        .For.All());
    }
}
