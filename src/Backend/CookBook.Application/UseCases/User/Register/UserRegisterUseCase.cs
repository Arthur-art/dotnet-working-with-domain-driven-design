using AutoMapper;
using CookBook.Comunication.Request;
using CookBook.Domain.Repositories;
using CookBook.Exceptions.ExceptionsBase;

namespace CookBook.Application.UseCases.User.Register;

public class UserRegisterUseCase : IUserRegisterUseCase
{
    private readonly IUserWriteOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IWorkUnit _workUnit;
    public UserRegisterUseCase(IUserWriteOnlyRepository repository, IMapper mapper, IWorkUnit workUnit)
    {
        _repository = repository;
        _mapper = mapper;
        _workUnit = workUnit;
    }

    public async Task Execute(RequestUserRegisterJson userRegisterJson)
    {
        Validate(userRegisterJson);
        var userEntity = _mapper.Map<Domain.Entities.User>(userRegisterJson);
        userEntity.Password = "cript";

        await _repository.Add(userEntity);
        await _workUnit.Commit();
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
