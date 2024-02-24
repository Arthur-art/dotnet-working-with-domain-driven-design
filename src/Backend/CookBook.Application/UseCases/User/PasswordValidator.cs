using CookBook.Exceptions;
using FluentValidation;

namespace CookBook.Application.UseCases.User;

public class PasswordValidator : AbstractValidator<string>
{
    public PasswordValidator() 
    {
        When(param => !string.IsNullOrWhiteSpace(param), () =>
        {
            RuleFor(param => param.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceExceptionsMessages.INVALID_USER_PASSWORD);
        });

        RuleFor(param => param).NotEmpty().WithMessage(ResourceExceptionsMessages.EMPTY_USER_PASSWORD);
    }
}
