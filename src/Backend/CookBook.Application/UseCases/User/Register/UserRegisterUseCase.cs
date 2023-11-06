using AutoMapper;
using CookBook.Application.Services.Cryptography;
using CookBook.Comunication.Request;
using CookBook.Domain.Repositories;
using CookBook.Exceptions.ExceptionsBase;
using CookBook.Comunication.Response;
using CookBook.Application.Services.Token;
using CookBook.Exceptions;

namespace CookBook.Application.UseCases.User.Register;

public class UserRegisterUseCase : IUserRegisterUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUserWriteOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IWorkUnit _workUnit;
    private readonly PasswordCryptography _passwordCryptography;
    private readonly TokenController _tokenController;
    public UserRegisterUseCase(IUserWriteOnlyRepository repository, IMapper mapper, IWorkUnit workUnit, PasswordCryptography passwordCryptography,
       TokenController tokenController, IUserReadOnlyRepository userReadOnlyRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _workUnit = workUnit;
        _passwordCryptography = passwordCryptography;
        _tokenController = tokenController;
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<ResponseUserRegisterJson> Execute(RequestUserRegisterJson userRegisterJson)
    {
        await Validate(userRegisterJson);
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

    private async Task Validate(RequestUserRegisterJson userRegisterJson)
    {
        var validator = new UserRegisterValidate();
        var result = validator.Validate(userRegisterJson);

        var userExists = await _userReadOnlyRepository.UserExists(userRegisterJson.Email);

        if(userExists)
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("email", ResourceExceptionsMessages.USER_EXISTS_WITH_EMAIL));
        }

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ValidationErrosException(errorMessages);
        }
    }
}
