using CookBook.Api.Filters;
using CookBook.Application;
using CookBook.Application.Services.Automapper;
using CookBook.Domain.Extension;
using CookBook.Infrastructure;
using CookBook.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionStringDatabase();
string nameDataBase = builder.Configuration.GetNameDataBase();

// Add services to the container.
builder.Services.AddRouting(option => option.LowercaseUrls = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepository(connectionString);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddMvc((options) => options.Filters.Add(typeof(FiltersExceptions)));
builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutomapperConfiguration());
}).CreateMapper());

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
