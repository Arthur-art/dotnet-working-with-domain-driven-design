using CookBook.Application.Services.Cryptography;
using CookBook.Application.Services.LoggedUser;
using CookBook.Comunication.Request;
using CookBook.Domain.Repositories;
using CookBook.Domain.Repositories.UserRepository;
using CookBook.Exceptions;
using CookBook.Exceptions.ExceptionsBase;

namespace CookBook.Application.UseCases.User.UpdatePassword;

public class UserUpdatePassword : IUserUpdatePassword
{
    private readonly IUpdateOnlyRepository _context;
    private readonly ILoggedUser _loggedUser;
    private readonly PasswordCryptography _passwordCryptography;
    private readonly IUpdateOnlyRepository _updateOnlyRepository;
    private readonly IWorkUnit _workUnit;
    public UserUpdatePassword(IUpdateOnlyRepository context, ILoggedUser loggedUser, IUpdateOnlyRepository updateOnlyRepository,
        PasswordCryptography passwordCryptography, IWorkUnit workUnit)
    {
        _context = context;
        _loggedUser = loggedUser;
        _passwordCryptography = passwordCryptography;
        _updateOnlyRepository = updateOnlyRepository;
        _workUnit = workUnit;
    }
    public async Task Execute(RequestUserUpdatePasswordJson updatePasswordJson)
    {
        var loggedUser = await _loggedUser.RecoverUser();
        var userById = await _updateOnlyRepository.RecoverById(loggedUser.Id);

        Validate(updatePasswordJson, userById);

        userById.Password = _passwordCryptography.Encrypt(updatePasswordJson.NewPassword);

        _context.Update(userById);

        _workUnit.Commit();
    }

    private void Validate(RequestUserUpdatePasswordJson updatePasswordJson, Domain.Entities.User user)
    {

        var validator = new UpdatePasswordValidator();

        var result = validator.Validate(updatePasswordJson);

        var currentPassword = _passwordCryptography.Encrypt(updatePasswordJson.CurrentPassword);

        if(!user.Password.Equals(currentPassword)) 
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("currentPassword", ResourceExceptionsMessages.CURRENT_PASSWORD_INVALID));
        }

        if (!result.IsValid)
        {
            var messages = result.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ValidationErrosException(messages);
        }
    }
}
