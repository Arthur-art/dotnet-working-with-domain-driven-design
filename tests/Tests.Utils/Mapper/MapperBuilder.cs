using AutoMapper;
using CookBook.Application.Services.Automapper;

namespace Tests.Utils.Mapper;

public class MapperBuilder
{
    public static IMapper Instance()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutomapperConfiguration>();
        });

        return configuration.CreateMapper();
    }
}
