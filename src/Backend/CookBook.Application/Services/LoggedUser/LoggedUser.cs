using CookBook.Application.Services.Token;
using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.UserRepository;
using Microsoft.AspNetCore.Http;
namespace CookBook.Application.Services.LoggedUser;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TokenController _tokenController;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    
    public LoggedUser(IHttpContextAccessor httpContextAccessor, TokenController tokenController, IUserReadOnlyRepository userReadOnlyRepository) 
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenController = tokenController;
        _userReadOnlyRepository = userReadOnlyRepository;
        
    }
    public async Task<User> RecoverUser()
    {

        var authorization = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

        var token = authorization["Bearer".Length..].Trim();

        var userEmail = _tokenController.RecoverEmail(token);

        var user = await _userReadOnlyRepository.RecoverUserByEmail(userEmail);

        return user;
    }
}
