using CookBook.Domain.Extension;
using CookBook.Infrastructure;
using CookBook.Infrastructure.Migrations;
using CookBook.Infrastructure.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionStringDatabase();
string nameDataBase = builder.Configuration.GetNameDataBase();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepository(connectionString);
builder.Services.AddDbContext<CookBookContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

UpdateDatabase();

app.Run();

void UpdateDatabase()
{
    Database.CreateDatabase(connectionString, nameDataBase);
    app.MigrationDatabase();
}
