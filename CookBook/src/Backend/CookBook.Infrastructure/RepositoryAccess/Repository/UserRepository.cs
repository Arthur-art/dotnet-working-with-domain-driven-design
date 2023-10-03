using CookBook.Domain.Entities;
using CookBook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoryAccess.Repository;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly CookBookContext _context;
    public UserRepository(CookBookContext context) 
    {
       _context = context;
    }
    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> UserExists(string email)
    {
       return await _context.Users.AnyAsync(c => c.Email.Equals(email));
    }
}
