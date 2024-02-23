using CookBook.Domain.Repositories.UserRepository;
using Moq;

namespace Tests.Utils.Repositories;

public class UserReadOnlyRepositoryBuilder
{
    private static UserReadOnlyRepositoryBuilder _instance;
    private readonly Mock<IUserReadOnlyRepository> _repository;

    private UserReadOnlyRepositoryBuilder()
    {
        _repository ??= new Mock<IUserReadOnlyRepository>();
    }

    public static UserReadOnlyRepositoryBuilder Instance()
    {
        _instance = new UserReadOnlyRepositoryBuilder();
        return _instance;
    }

    public UserReadOnlyRepositoryBuilder UserExists(string email)
    {
        _repository.Setup(i => i.UserExists(email)).ReturnsAsync(true);
        return this;
    }

    public IUserReadOnlyRepository Builder()
    {
        return _repository.Object;
    }
}
