using CookBook.Comunication.Response;
using CookBook.Exceptions;
using CookBook.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

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
        if(context.Exception is ValidationErrosException)
        {
            HandleValidationErrorsExceptions(context);
        }else if (context.Exception is InvalidLoginException)
        {
            HandleLoginException(context);
        }
    }

    private void HandleValidationErrorsExceptions(ExceptionContext context)
    {
        var validationErrorsExceptions = context.Exception as ValidationErrosException;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new ErrorResponseJson(validationErrorsExceptions.ErrorMessages));

    }

    private void HandleLoginException(ExceptionContext context)
    {
        var errorLogin = context.Exception as InvalidLoginException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        context.Result = new ObjectResult(new ErrorResponseJson(errorLogin.Message));
    }

    public void ThrowUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ErrorResponseJson(ResourceExceptionsMessages.UNKNOWN_ERROR));
    }
}
