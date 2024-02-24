using CookBook.Domain.Entities;

namespace CookBook.Domain.Repositories.UserRepository;

public interface IUserReadOnlyRepository
{
    Task<bool> UserExists(string email);
    Task<User> RecoverUserByEmail(string email);
    Task<Entities.User> Login(string email, string password);
}
