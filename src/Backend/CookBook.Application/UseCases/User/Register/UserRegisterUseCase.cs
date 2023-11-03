using AutoMapper;
using CookBook.Application.Services.Cryptography;
using CookBook.Comunication.Request;
using CookBook.Domain.Repositories;
using CookBook.Exceptions.ExceptionsBase;
using CookBook.Comunication.Response;
using CookBook.Application.Services.Token;

namespace CookBook.Application.UseCases.User.Register;

public class UserRegisterUseCase : IUserRegisterUseCase
{
    private readonly IUserWriteOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IWorkUnit _workUnit;
    private readonly PasswordCryptography _passwordCryptography;
    private readonly TokenController _tokenController;
    public UserRegisterUseCase(IUserWriteOnlyRepository repository, IMapper mapper, IWorkUnit workUnit, PasswordCryptography passwordCryptography,
       TokenController tokenController)
    {
        _repository = repository;
        _mapper = mapper;
        _workUnit = workUnit;
        _passwordCryptography = passwordCryptography;
        _tokenController = tokenController;
    }

    public async Task<ResponseUserRegisterJson> Execute(RequestUserRegisterJson userRegisterJson)
    {
        Validate(userRegisterJson);
        var userEntity = _mapper.Map<Domain.Entities.User>(userRegisterJson);
        userEntity.Password = _passwordCryptography.Encrypt(userEntity.Password);

        await _repository.Add(userEntity);
        await _workUnit.Commit();

        var token = _tokenController.GenerateToken(userEntity.Email);

        return new ResponseUserRegisterJson
        {
            Token = token,
        };
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
