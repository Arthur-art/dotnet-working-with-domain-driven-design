using CookBook.Comunication.Request;

namespace CookBook.Application.UseCases.User.Register;

public class UserRegisterUseCase
{
    public Task Execute(RequestUserRegisterJson userRegisterJson)
    {
        throw new System.NotImplementedException();
    }

    private void Validate(RequestUserRegisterJson userRegisterJson)
    {
        UserRegisterValidate validate = new UserRegisterValidate();

        var result = validate.Validate(userRegisterJson);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new Exception();
        }
    }
}
