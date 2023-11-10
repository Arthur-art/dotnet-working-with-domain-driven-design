using CookBook.Application.UseCases.User.Register;
using CookBook.Exceptions;
using FluentAssertions;
using Tests.Utils.Requests;
using Xunit;

namespace Validators.Test.User.Register;

public class UserRegisterValidatorTest
{
    [Fact]
    public void Validate_Success()
    {
        var validator = new UserRegisterValidate();
        var request = UserRequestRegisterBuilder.Builder();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_Error_Empty_Name()
    {
        var validator = new UserRegisterValidate();
        var request = UserRequestRegisterBuilder.Builder();
        request.Name = "";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceExceptionsMessages.EMPTY_USER_NAME));
    }

    [Fact]
    public void Validate_Error_Empty_Email()
    {
        var validator = new UserRegisterValidate();
        var request = UserRequestRegisterBuilder.Builder();
        request.Email = "";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceExceptionsMessages.EMPTY_USER_EMAIL));
    }

    [Fact]
    public void Validate_Error_Empty_Password()
    {
        var validator = new UserRegisterValidate();
        var request = UserRequestRegisterBuilder.Builder();
        request.Password = "";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceExceptionsMessages.EMPTY_USER_PASSWORD));
    }

    [Fact]
    public void Validate_Error_Empty_PhoneNumber()
    {
        var validator = new UserRegisterValidate();
        var request = UserRequestRegisterBuilder.Builder();
        request.PhoneNumber = "";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceExceptionsMessages.EMPTY_USER_PHONE));
    }

    [Fact]
    public void Validate_Error_Invalid_Email()
    {
        var validator = new UserRegisterValidate();
        var request = UserRequestRegisterBuilder.Builder();
        request.Email = "arthurgmailcom";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceExceptionsMessages.INVALID_USER_EMAIL));
    }

    [Fact]
    public void Validate_Error_Invalid_Password()
    {
        var validator = new UserRegisterValidate();
        var request = UserRequestRegisterBuilder.Builder();
        request.Password = "12345";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceExceptionsMessages.INVALID_USER_PASSWORD));
    }

    [Fact]
    public void Validate_Error_Invalid_PhoneNumber()
    {
        var validator = new UserRegisterValidate();
        var request = UserRequestRegisterBuilder.Builder();
        request.PhoneNumber = "3199999-9999";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceExceptionsMessages.INVALID_USER_PHONE));
    }
}
