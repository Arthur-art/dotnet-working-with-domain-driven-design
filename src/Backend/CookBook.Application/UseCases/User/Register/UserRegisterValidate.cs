using CookBook.Comunication.Request;
using CookBook.Exceptions;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CookBook.Application.UseCases.User.Register;

public class UserRegisterValidate : AbstractValidator<RequestUserRegisterJson>
{
    public UserRegisterValidate()
    {
        RuleFor(param => param.Name).NotEmpty().WithMessage(ResourceExceptionsMessages.EMPTY_USER_NAME);
        RuleFor(param => param.Email).NotEmpty().WithMessage(ResourceExceptionsMessages.EMPTY_USER_EMAIL);
        RuleFor(param => param.PhoneNumber).NotEmpty().WithMessage(ResourceExceptionsMessages.EMPTY_USER_PHONE);
        RuleFor(param => param.Password).NotEmpty().WithMessage(ResourceExceptionsMessages.EMPTY_USER_PASSWORD);

        When(param => !string.IsNullOrWhiteSpace(param.Password), () =>
        {
            RuleFor(param => param.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceExceptionsMessages.INVALID_USER_PASSWORD);
        });
        When(param => !string.IsNullOrWhiteSpace(param.Email), () =>
        {
            RuleFor(param => param.Email).EmailAddress().WithMessage(ResourceExceptionsMessages.INVALID_USER_EMAIL);
        });
        When(param => !string.IsNullOrWhiteSpace(param.PhoneNumber), () =>
        {
            RuleFor(param => param.PhoneNumber).Custom((phoneNumber, context) =>
            {
                string phoneNumberDefault = "[0-9]{2} [0-9]{1} [0-9]{4}-[0-9]{4}";
                var phoneNumberValidation = Regex.IsMatch(phoneNumber, phoneNumberDefault);
                if (!phoneNumberValidation)
                {
                    context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(phoneNumber), ResourceExceptionsMessages.INVALID_USER_PHONE));
                }
            });
        });
    }
}
