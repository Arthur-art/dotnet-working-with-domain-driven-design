using CookBook.Domain.Repositories;
using Moq;

namespace Tests.Utils.Repositories;

public class WorkUnitBuilder
{
    private static WorkUnitBuilder _instance;
    private readonly Mock<IWorkUnit> _repository;

    private WorkUnitBuilder()
    {
        _repository ??= new Mock<IWorkUnit>();
    }

    public static WorkUnitBuilder Instance()
    {
        _instance = new WorkUnitBuilder();
        return _instance;
    }

    public IWorkUnit Builder()
    {
        return _repository.Object;
    }
}
