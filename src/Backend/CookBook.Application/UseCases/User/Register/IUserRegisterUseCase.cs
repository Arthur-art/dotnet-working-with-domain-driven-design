using CookBook.Comunication.Request;

namespace CookBook.Application.UseCases.User.Register;

public interface IUserRegisterUseCase
{
    Task Execute(RequestUserRegisterJson userRegisterJson);
}
