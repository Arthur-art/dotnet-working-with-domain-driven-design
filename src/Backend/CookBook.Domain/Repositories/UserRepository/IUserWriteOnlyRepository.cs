using CookBook.Domain.Entities;

namespace CookBook.Domain.Repositories.UserRepository;

public interface IUserWriteOnlyRepository
{
    Task Add(User user);
}
