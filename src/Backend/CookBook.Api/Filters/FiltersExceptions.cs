using CookBook.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CookBook.Api.Filters;

public class FiltersExceptions : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is CookBookException)
        {
            ResolveCookBookExceptions(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    public void ResolveCookBookExceptions(ExceptionContext context)
    {

    }

    public void ThrowUnknownError(ExceptionContext context)
    {
        context.Result = new ObjectResult(new { message = "Erro desconhecido." });
    }
}
