using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CookBook.Infrastructure.Migrations
{
    public static class Database
    {
        public static void CreateDatabase(string connectionString, string databaseName)
        {
            using IDbConnection dbConnection = new SqlConnection(connectionString);

            // Verificar se o banco de dados já existe
            string checkDatabaseExistsQuery = "SELECT COUNT(*) FROM sys.databases WHERE name = @databaseName";
            var databaseExists = dbConnection.QuerySingle<int>(checkDatabaseExistsQuery, new { databaseName });

            if (databaseExists == 0)
            {
                // O banco de dados não existe, então criamos
                string createDatabaseQuery = $"CREATE DATABASE {databaseName}";
                dbConnection.Execute(createDatabaseQuery);
                Console.WriteLine($"Banco de dados '{databaseName}' criado com sucesso.");
            }
            else
            {
                Console.WriteLine($"O banco de dados '{databaseName}' já existe.");
            }
        }
    }
}
