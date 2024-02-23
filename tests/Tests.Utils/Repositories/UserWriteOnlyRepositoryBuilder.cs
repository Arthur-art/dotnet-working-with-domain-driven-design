using CookBook.Domain.Repositories.UserRepository;
using Moq;

namespace Tests.Utils.Repositories;

public class UserWriteOnlyRepositoryBuilder
{
    private static UserWriteOnlyRepositoryBuilder _instance;
    private readonly Mock<IUserWriteOnlyRepository> _repository;

    private UserWriteOnlyRepositoryBuilder()
    {
        _repository ??= new Mock<IUserWriteOnlyRepository>();
    }

    public static UserWriteOnlyRepositoryBuilder Instance()
    {
        _instance= new UserWriteOnlyRepositoryBuilder();
        return _instance;
    }

    public IUserWriteOnlyRepository Builder()
    {
        return _repository.Object;
    }
}
