using CookBook.Comunication.Request;
using CookBook.Comunication.Response;

namespace CookBook.Application.UseCases.Login.DoLogin;

public interface ILoginUseCase
{
    Task<ResponseLoginRequestJson> Execute(LoginRequestJson request);
}
