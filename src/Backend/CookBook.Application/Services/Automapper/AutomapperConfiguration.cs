using AutoMapper;
using CookBook.Comunication.Request;

namespace CookBook.Application.Services.Automapper;

public class AutomapperConfiguration : Profile
{
    public AutomapperConfiguration() 
    {
        CreateMap<RequestUserRegisterJson, Domain.Entities.User>();
    }
}
