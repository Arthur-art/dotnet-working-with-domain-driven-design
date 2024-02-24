using CookBook.Comunication.Request;

namespace CookBook.Application.UseCases.User.UpdatePassword;

public interface IUserUpdatePassword
{
    Task Execute(RequestUserUpdatePasswordJson updatePasswordJson);
}
