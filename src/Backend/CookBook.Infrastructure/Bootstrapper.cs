using CookBook.Domain.Repositories;
using CookBook.Infrastructure.RepositoryAccess;
using CookBook.Infrastructure.RepositoryAccess.Repository;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CookBook.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, string connectionString)
    {
        AddFluentMigrator(services, connectionString);
        AddRepositories(services);
        AddWorkUnit(services);
        AddContext(services, connectionString);
    }

    private static void AddContext(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CookBookContext>(options => options.UseSqlServer(connectionString));
    }

    private static void AddWorkUnit(IServiceCollection services)
    {
        services.AddScoped<IWorkUnit, WorkUnit>();
    }

    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>()
            .AddScoped<IUserReadOnlyRepository, UserRepository>();
    }

    private static void AddFluentMigrator(IServiceCollection services, string connectionString)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c =>
        c.AddSqlServer()
        .WithGlobalConnectionString(connectionString).ScanIn(Assembly.Load("CookBook.Infrastructure"))
        .For.All());
    }
}
