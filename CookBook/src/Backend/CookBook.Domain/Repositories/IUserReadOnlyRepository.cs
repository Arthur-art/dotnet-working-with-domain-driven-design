namespace CookBook.Domain.Repositories;

public interface IUserReadOnlyRepository
{
    Task<bool> UserExists(string email);
}
