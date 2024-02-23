using CookBook.Domain.Entities;

namespace CookBook.Domain.Repositories.UserRepository;

public interface IUpdateOnlyRepository
{
    void Update(User user);
}
