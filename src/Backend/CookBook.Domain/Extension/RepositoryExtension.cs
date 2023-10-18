using Microsoft.Extensions.Configuration;

namespace CookBook.Domain.Extension;

public static class RepositoryExtension
{
    public static string GetConnectionStringDatabase(this IConfiguration configurationManager)
    {
        string connectionString = configurationManager.GetConnectionString("DefaultConnection");

        return connectionString;
    }

    public static string GetNameDataBase(this IConfiguration configurationManager)
    {
        string connectionString = configurationManager.GetConnectionString("NameDataBase");

        return connectionString;
    }
}
