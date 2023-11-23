namespace CookBook.Domain.Repositories;

public interface IUserReadOnlyRepository
{
    Task<bool> UserExists(string email);
    Task<Entities.User> Login(string email, string password);
}
