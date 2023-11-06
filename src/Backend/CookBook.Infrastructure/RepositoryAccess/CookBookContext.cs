using CookBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoryAccess;

public class CookBookContext : DbContext
{
    public CookBookContext(DbContextOptions<CookBookContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CookBookContext).Assembly);
    }
}
