using CookBook.Domain.Entities;

namespace CookBook.Domain.Repositories;

public interface IUserWriteOnlyRepository
{
    Task Add(User user);
}
