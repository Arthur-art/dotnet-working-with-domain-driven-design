using CookBook.Application.UseCases.User.Register;
using FluentAssertions;
using Tests.Utils.Mapper;
using Tests.Utils.PasswordCryptographyBuilder;
using Tests.Utils.Repositories;
using Tests.Utils.Requests;
using Tests.Utils.TokenBuilder;
using Xunit;

namespace UseCases.Test.User.Register;

public class UserRegisterUseCaseTest
{
    [Fact]
    public async Task Validate_Success()
    {
        var request = UserRequestRegisterBuilder.Builder();
        var useCase = CreateUser();
        var response = await useCase.Execute(request);
        response.Should().NotBeNull();
        response.Token.Should().NotBeNullOrWhiteSpace();
    }

    private UserRegisterUseCase CreateUser(string email = "")
    {
        var tokenBuilder = TokenControllerBuilder.Instance();
        var passwordCryptography = PasswordCryptographyBuilder.Instance();
        var mapper = MapperBuilder.Instance();
        var workUnit = WorkUnitBuilder.Instance().Builder();
        var repository = UserWriteOnlyRepositoryBuilder.Instance().Builder();
        var repositoryUserReadOnly = UserReadOnlyRepositoryBuilder.Instance().UserExists(email).Builder();

        return new UserRegisterUseCase(repository, mapper, workUnit, passwordCryptography, tokenBuilder, repositoryUserReadOnly);
    }
}
