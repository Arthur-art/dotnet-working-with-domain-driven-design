using CookBook.Comunication.Request;
using CookBook.Comunication.Response;

namespace CookBook.Application.UseCases.User.Register;

public interface IUserRegisterUseCase
{
    Task<ResponseUserRegisterJson> Execute(RequestUserRegisterJson userRegisterJson);
}
