using CookBook.Application.Services.Token;
using CookBook.Comunication.Response;
using CookBook.Domain.Repositories.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace CookBook.Api.Filters;

public class AuthenticatedUserAttribute : AuthorizeAttribute,IAsyncAuthorizationFilter
{
    private readonly TokenController _tokenController;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;

    public AuthenticatedUserAttribute(TokenController tokenController, IUserReadOnlyRepository userReadOnlyRepository)
    {
        _tokenController = tokenController;
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenInRequest(context);
            var email = _tokenController.RecoverEmail(token);
            var getUserByEmail = _userReadOnlyRepository.RecoverUserByEmail(email);

            if (getUserByEmail is null)
            {
                throw new System.Exception();
            }
        }
        catch (SecurityTokenExpiredException)
        {
            TokenExpired(context);
        }
        catch
        {
            UnauthorizedUser(context);
        }
    }

    private string TokenInRequest(AuthorizationFilterContext context)
    {
        var authorization = context.HttpContext.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrWhiteSpace(authorization))
        {
            throw new System.Exception();
        }

        return authorization["Bearer".Length..].Trim();
    }

    private void TokenExpired(AuthorizationFilterContext context)
    {
        context.Result = new UnauthorizedObjectResult(new ErrorResponseJson("Token expirado, faça login novamente no app!"));
    }
    private void UnauthorizedUser(AuthorizationFilterContext context)
    {
        context.Result = new UnauthorizedObjectResult(new ErrorResponseJson("Token inválido, usuário não autorizado."));
    }
}
