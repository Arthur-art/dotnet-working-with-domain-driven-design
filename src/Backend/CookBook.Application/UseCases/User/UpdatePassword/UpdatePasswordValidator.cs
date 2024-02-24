using CookBook.Comunication.Request;
using FluentValidation;

namespace CookBook.Application.UseCases.User.UpdatePassword;

public class UpdatePasswordValidator : AbstractValidator<RequestUserUpdatePasswordJson>
{
    public UpdatePasswordValidator()
    {
        RuleFor(param => param.NewPassword).SetValidator(new PasswordValidator());
    }
}
