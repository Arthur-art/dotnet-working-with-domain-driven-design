using CookBook.Application.Services.Cryptography;
using CookBook.Application.Services.Token;
using CookBook.Comunication.Request;
using CookBook.Comunication.Response;
using CookBook.Domain.Repositories.UserRepository;
using CookBook.Exceptions.ExceptionsBase;

namespace CookBook.Application.UseCases.Login.DoLogin;

public class LoginUseCase : ILoginUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnly;
    private readonly PasswordCryptography _passwordCryptography;
    private readonly TokenController _tokenController;
    public LoginUseCase(IUserReadOnlyRepository userReadOnly, PasswordCryptography passwordCryptography, TokenController tokenController)
    {
        _userReadOnly = userReadOnly;
        _passwordCryptography = passwordCryptography;
        _tokenController = tokenController;
    }

    public async Task<ResponseLoginRequestJson> Execute(LoginRequestJson request)
    {
        var passwordCryptography = _passwordCryptography.Encrypt(request.Password);
        var userLogin = await _userReadOnly.Login(request.Email, passwordCryptography);

        if(userLogin == null)
        {
            throw new InvalidLoginException();
        }

        return new ResponseLoginRequestJson 
        { 
            Name = userLogin.Name,
            Token = _tokenController.GenerateToken(request.Email)
        };
    }
}
