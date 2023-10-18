using CookBook.Comunication.Request;
using CookBook.Exceptions.ExceptionsBase;

namespace CookBook.Application.UseCases.User.Register;

public class UserRegisterUseCase
{
    public async Task Execute(RequestUserRegisterJson userRegisterJson)
    {
        Validate(userRegisterJson);
    }

    private void Validate(RequestUserRegisterJson userRegisterJson)
    {
        UserRegisterValidate validator = new UserRegisterValidate();

        var result = validator.Validate(userRegisterJson);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ValidationErrosException(errorMessages);
        }
    }
}
